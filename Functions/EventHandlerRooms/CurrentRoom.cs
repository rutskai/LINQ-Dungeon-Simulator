using Models;

namespace Functions{
 
 public static class CurrentRoom{
 public static void Display(Game game)
        {
            var room = game.GetCurrentRoom();
            if (room == null) return;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🚪 ROOM {room.Id}: {room.Event}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("─────────────────────────────────────────────────────────────\n");
            Console.ResetColor();

            // Mostrar enemigos
            if (room.Enemies.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚔️  ENEMIES:");
                Console.ResetColor();
                foreach (var enemy in room.Enemies)
                {
                    Console.Write($"   • {enemy.Name} ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"[HP: {enemy.Health} | ATK: {enemy.Attack}]");
                    Console.ResetColor();
                }
            }

            // Mostrar items
            if (room.Items.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n💎 ITEMS:");
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
                Console.WriteLine("   (Empty room)");
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