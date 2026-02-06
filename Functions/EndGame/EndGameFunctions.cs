using Models;

namespace Functions
{
    public static  class EndGame
    {

         public static void DisplayFinalStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════════\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FINAL STATISTICS:");
            Console.ResetColor();

            Console.WriteLine($"  Player Name: {player.Name}");
            Console.WriteLine($"  Final HP: {player.Health}");
            Console.WriteLine($"  Total Damage Dealt: {player.TotalDamageDealt}");
            Console.WriteLine($"  Enemies Defeated: {player.DefeatedEnemies.Count}");
            Console.WriteLine($"  Items Collected: {player.Inventory.Count}");

            if (player.Inventory.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n  Inventory:");
                Console.ResetColor();
                foreach (var item in player.Inventory)
                {
                    Console.WriteLine($"    • {item.Name}");
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n═══════════════════════════════════════════════════════════\n");
            Console.ResetColor();
        }

        public static void DisplayGameEnd(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");

            if (player.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("║                    🎉 VICTORY! 🎉                          ║");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("║                    💀 GAME OVER 💀                       ║");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();

           EndGame.DisplayFinalStats(player);
        }
        
    }
}