using Models;

namespace MenuManager
{
    public static class ShowStatsMenu
    {
        public static void Display(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("════════════════ ESTADÍSTICAS DEL HÉROE ════════════════\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Nombre: {player.Name}");
            Console.WriteLine($"Salud actual: {player.Health}");
            Console.WriteLine($"Daño base: {player.BaseDamage}");
            Console.WriteLine($"Daño total realizado: {player.TotalDamageDealt}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nEnemigos derrotados:");

            if (player.DefeatedEnemies.Any())
            {
                foreach (var enemy in player.DefeatedEnemies)
                {
                    Console.WriteLine($"  - {enemy.Name} ({enemy.Type})");
                }
            }
            else
            {
                Console.WriteLine("  Ninguno");
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nInventario:");

            if (player.Inventory.Any())
            {
                foreach (var item in player.Inventory)
                {
                    Console.WriteLine($"  - {item.Name} [{item.Type}] Valor: {item.Value}, Rareza: {item.Rarity}");
                }
            }
            else
            {
                Console.WriteLine("  Vacío");
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n═════════════════════════════════════════════════════");

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPresiona cualquier tecla para regresar al menú principal...");
            Console.ReadKey();
        }
    }
}
