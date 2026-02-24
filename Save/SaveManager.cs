using System.Text.Json;
using Models;
using Utils;


namespace Save
{
    public static class SaveManager
    {
        private static readonly string SavePath = "savegame.json";
        private static readonly JsonSerializerOptions JsonOptions = new() { WriteIndented = true };

        /**
         * Guarda el estado actual del jugador y del juego en un archivo JSON.
         *
         * @param player Instancia del jugador que contiene su estado actual
         *               (vida, oro, inventario, enemigos derrotados, etc.).
         * @param game   Instancia del juego que contiene el índice de la habitación actual.
         */

        public static void Save(Player player, Game game)
        {


            var saveData = new SaveData
            {
                PlayerName = player.Name,
                PlayerHealth = player.Health,
                PlayerBaseDamage = player.BaseDamage,
                PlayerGold = player.Gold,
                CurrentRoomIndex = game.CurrentRoomIndex,
                TotalDamageDealt = player.TotalDamageDealt,
                SavedAt = DateTime.Now,

                Inventory = player.Inventory
                                    .Select(ItemDTO.FromItem)
                                    .ToList(),

                DefeatedEnemies = player.DefeatedEnemies
                                    .Select(EnemyDTO.FromEnemy)
                                    .ToList()
            };

            string json = JsonSerializer.Serialize(saveData, JsonOptions);
            File.WriteAllText(SavePath, json);

            Typewriter.Pause(200);
            Typewriter.WriteLine("💾 Partida guardada correctamente.", ConsoleColor.DarkGreen, Typewriter.Speed.Fast, 400);
        }

        /**
         * Carga la partida desde el archivo de guardado si existe.
         *
         * @return Una tupla que contiene el jugador reconstruido y el índice de la
         *         habitación actual. Devuelve null si no existe archivo
         *         de guardado o si está corrupto.
         */

        public static (Player player, int roomIndex)? Load()
        {
            if (!File.Exists(SavePath))
            {
                Typewriter.WriteLine("⚠️  No se encontró ninguna partida guardada.", ConsoleColor.Red, Typewriter.Speed.Fast, 400);
                return null;
            }

            string json = File.ReadAllText(SavePath);
            var saveData = JsonSerializer.Deserialize<SaveData>(json);

            if (saveData == null)
            {
                Typewriter.WriteLine("⚠️  El archivo de guardado está corrupto.", ConsoleColor.Red, Typewriter.Speed.Fast, 400);
                return null;
            }

            var player = new Player(saveData.PlayerName, saveData.PlayerHealth, saveData.PlayerBaseDamage)
            {
                Gold = saveData.PlayerGold,
                TotalDamageDealt = saveData.TotalDamageDealt,

                Inventory = saveData.Inventory
                                     .Select(dto => dto.ToItem())
                                     .ToList(),

                DefeatedEnemies = saveData.DefeatedEnemies
                                     .Select(dto => dto.ToEnemy())
                                     .ToList()
            };

            Typewriter.Pause(200);
            Typewriter.WriteLine($"✅ Partida de {player.Name} cargada!", ConsoleColor.Green, Typewriter.Speed.Fast, 200);
            Typewriter.WriteLine($"   Habitación {saveData.CurrentRoomIndex + 1} | ❤️ {player.Health} | 💰 {player.Gold} oro", ConsoleColor.Cyan, Typewriter.Speed.Fast, 400);

            return (player, saveData.CurrentRoomIndex);
        }

        /**
             * Comprueba si existe un archivo de guardado.
             *
             * @return {@code true} si existe una partida guardada,
             *         {@code false} en caso contrario.
             */
        public static bool SaveExists() => File.Exists(SavePath);

        /**
        * Obtiene información básica de la partida guardada sin cargar
        * completamente el jugador en memoria.
        *
        * @return Un objeto {@code SaveData} con la información almacenada,
        *         o {@code null} si no existe archivo de guardado.
        */

        public static SaveData? GetSaveInfo()
        {
            if (!File.Exists(SavePath)) return null;
            string json = File.ReadAllText(SavePath);
            return JsonSerializer.Deserialize<SaveData>(json);
        }

        /**
        * Muestra por consola información resumida sobre la partida guardada,
        * incluyendo nombre del jugador, habitación actual, vida, oro y fecha
        * de guardado.
        */

        public static void ShowSaveInfo()
        {
            if (!SaveExists())
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   (Sin partida guardada)");
                Console.ResetColor();
                return;
            }

            string json = File.ReadAllText(SavePath);
            var saveData = JsonSerializer.Deserialize<SaveData>(json);
            if (saveData == null) return;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"   Última partida: {saveData.PlayerName} | Hab. {saveData.CurrentRoomIndex + 1} | ❤️ {saveData.PlayerHealth} | 💰 {saveData.PlayerGold}G");
            Console.WriteLine($"   Guardada el {saveData.SavedAt:dd/MM/yyyy HH:mm}");
            Console.ResetColor();
        }

    /**
    * Elimina el archivo de guardado si existe.
    *
    */

        public static void DeleteSave()
        {



            if (File.Exists(SavePath))
                File.Delete(SavePath);

            Typewriter.WriteLine("Partida eliminada.", ConsoleColor.Green, Typewriter.Speed.Fast, 400);
        }
    }
}