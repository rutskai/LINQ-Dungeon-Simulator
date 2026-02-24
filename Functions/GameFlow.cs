using Models;
using Generators;
using MenuManager;
using Utils;
using Funcions;
using Save;


namespace Functions
{

    /**
    * Clase que gestiona el flujo principal del juego.
    * Controla el ciclo de la partida, incluyendo nueva partida,
    * carga de partidas guardadas, interacción con habitaciones,
    * combate con jefes, tiendas y guardado automático.
    */
    public class GameFlow
    {
        private static Game? game;
        private static Player? player;
        private static Room? room;

    /**
     * Inicia una nueva partida con un jugador de nombre especificado.
     * Genera el juego y la mazmorra y ejecuta el bucle principal.
     *
     * @param playerName Nombre del jugador que iniciará la partida.
     */
        public static void MainGameLoop(string playerName)
        {
            game = GameGenerator.GenerateGame(playerName, 10);
            player = game.Player;
            room = game.GetCurrentRoom();

            RunLoop();
        }
        /**
        * Carga una partida existente desde el archivo de guardado.
        * Reconstruye el jugador y la posición en la mazmorra,
        * luego ejecuta el bucle principal del juego.
        */
        public static void LoadGameLoop()
        {
            Console.Clear();
            var result = SaveManager.Load();
            if (result == null) return;

            var (loadedPlayer, roomIndex) = result.Value;
            game = GameGenerator.GenerateGame(loadedPlayer.Name, 10);
            game.Player = loadedPlayer;
            game.CurrentRoomIndex = roomIndex;
            player = game.Player;
            room = game.GetCurrentRoom();

            RunLoop();
        }

    /**
     * Ejecuta el bucle principal de la partida.
     * Controla:
     * - Visualización de estadísticas y habitación actual.
     * - Procesamiento de acciones en la habitación.
     * - Manejo de la habitación del jefe.
     * - Tiendas cada dos habitaciones.
     * - Guardado automático entre habitaciones.
     * - Finalización del juego.
     */

        public static void RunLoop()
        {
            while (!game!.IsGameOver)
            {
                Console.Clear();
                ShowStatsGame.Display(player!, game, room!);
                Typewriter.Pause(2000);
                CurrentRoom.Display(game);
                RoomAction.ProcessRoomActions(game, player!);

                if (!game.IsGameOver && game.IsLastRoom())
                {
                    Boss.HandleBossRoom(game);
                }

                bool isShopRoom = !game.IsGameOver
                    && !game.IsLastRoom()
                    && new[] { game.GetCurrentRoom()?.Id }
                        .Where(id => id.HasValue)
                        .Any(id => id!.Value % 2 == 0);

                if (isShopRoom)
                {
                    if (Confirmation.AskConfirmation("\n🏪 ¡Hay una tienda cerca! ¿Entrar? (s/n): "))
                    {
                        Shop.OpenShop(player!);
                    }
                        
                }

                if (!game.IsGameOver && game.RoomsRemaining() > 0)
                {
                    Typewriter.FlushInput();
                    SaveManager.Save(player!, game);
                    Continue.PromptContinue(game);
                }
            }
            GameEnd.DisplayGameEnd(player!);
        }
    }
}