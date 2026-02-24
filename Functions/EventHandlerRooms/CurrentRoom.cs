using Models;

namespace Functions
{

    /**
    * Clase que se encarga de mostrar la información de la habitación actual.
    * Incluye enemigos, objetos y tipo de evento, con formato visual en consola.
    */
    public static class CurrentRoom
    {

        /**
         * Muestra en consola los detalles de la habitación actual del juego.
         * - Nombre y tipo de evento de la habitación.
         * - Lista de enemigos con vida y ataque.
         * - Lista de objetos con tipo y rareza, coloreados según rareza.
         * - Mensaje si la habitación está vacía.
         *
         * @param game Instancia de {@code Game} que contiene la habitación actual.
         */
        public static void Display(Game game)
        {
            var room = game.GetCurrentRoom();
            if (room == null) return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🚪 HABITACIÓN {room.Id}: {room.Event}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("─────────────────────────────────────────────────────────────\n");
            Console.ResetColor();


            if (room.Enemies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚔️  ENEMIGOS:");
                Console.ResetColor();
                foreach (var enemy in room.Enemies)
                {
                    Console.Write($"   • {enemy.Name} ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"[VIDA: {enemy.Health} | ATQ: {enemy.Attack}]");
                    Console.ResetColor();
                }
            }


            if (room.Items.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n💎 OBJETOS:");
                Console.ResetColor();
                foreach (var item in room.Items)
                {
                    Console.ForegroundColor = GetRarityColor(item.Rarity);
                    Console.WriteLine($"   • {item.Name} ({item.Type}) - {item.Rarity}");
                    Console.ResetColor();
                }
            }

            if (room.Enemies.Count == 0 && room.Items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   (Habitación vacía)");
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        public static ConsoleColor GetRarityColor(string rarity)
        {
            return rarity switch
            {
                "Común" => ConsoleColor.White,
                "Raro" => ConsoleColor.Cyan,
                "Épico" => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }
    }


}