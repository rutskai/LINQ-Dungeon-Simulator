using Models;
using Data;

namespace Functions
{

/**
 * Clase que gestiona la tienda del juego.
 * Permite al jugador comprar objetos, pociones, armas y mejoras,
 * aplicando efectos al jugador y descontando el oro correspondiente.
 */
    public static class Shop
    {
      
        private const int DamageBonusPerUpgrade = 3;
      
        private static readonly Dictionary<string, int> PotionHealing = new()
        {
            { "Poción de Vida Menor", 20 },
            { "Poción de Vida Mayor", 40 },
            { "Elixir Épico",        70 }
        };

    /**
     * Abre la tienda para el jugador.
     * Muestra los objetos disponibles, verifica si puede comprarlos,
     * aplica los efectos de cada ítem y actualiza el inventario y oro.
     *
     * @param player Instancia de {@code Player} que interactúa con la tienda.
     */

        public static void OpenShop(Player player)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                  🏪  TIENDA DEL AVENTURERO  🏪            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();

         
            var availableItems = GameData.ShopItems
                .OrderBy(_ => GameData.random.Next())
                .Take(4)
                .ToList();

            bool shopping = true;
            while (shopping)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n  💰 Tu oro: {player.Gold}G");
                Console.ResetColor();
                Console.WriteLine();

              
                var affordable = availableItems
                    .Select((item, index) => new { item, index, canAfford = player.Gold >= item.Value })
                    .ToList();

                affordable.ForEach(entry =>
                {
                    Console.ForegroundColor = entry.canAfford ? ConsoleColor.White : ConsoleColor.DarkGray;
                    string rarityTag = $"[{entry.item.Rarity}]";
                    string affordTag = entry.canAfford ? "" : " (sin fondos)";
                    Console.WriteLine($"  {entry.index + 1}. {entry.item.Name} ({entry.item.Type}) {rarityTag} - {entry.item.Value}G{affordTag}");
                    Console.ResetColor();
                });

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"  {availableItems.Count + 1}. Salir de la tienda");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\n➤ ¿Qué deseas comprar? ");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Opción inválida.");
                    Console.ResetColor();
                    continue;
                }

                if (choice == availableItems.Count + 1)
                {
                    shopping = false;
                    continue;
                }

           
                var selected = availableItems
                    .Select((item, index) => new { item, index })
                    .FirstOrDefault(e => e.index == choice - 1);

                if (selected == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  Opción no válida.");
                    Console.ResetColor();
                    continue;
                }

                if (player.Gold < selected.item.Value)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  ¡No tienes suficiente gold!");
                    Console.ResetColor();
                    continue;
                }

              
                player.Gold -= selected.item.Value;
                ApplyItemEffect(player, selected.item);
                player.Inventory.Add(selected.item);
                availableItems.RemoveAt(selected.index);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n  ✓ Compraste: {selected.item.Name}!");
                Console.ResetColor();

               
                bool anyAffordable = availableItems.Any(i => player.Gold >= i.Value);
                if (!availableItems.Any() || !anyAffordable)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(availableItems.Any()
                        ? "\n  No puedes permitirte más artículos. ¡Vuelve con más gold!"
                        : "\n  ¡La tienda se ha quedado sin stock!");
                    Console.ResetColor();
                    shopping = false;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  ¡Hasta la próxima, aventurero! 👋");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1000);
        }

    /**
     * Aplica los efectos de un objeto comprado sobre el jugador.
     * - Poción: restaura vida.
     * - Mejora: aumenta daño base fijo.
     * - Arma: aumenta daño base según rareza.
     *
     * @param player Instancia del jugador que recibe el efecto.
     * @param item   Objeto que se aplicará sobre el jugador.
     */
        private static void ApplyItemEffect(Player player, Item item)
        {
            switch (item.Type)
            {
                case "Poción":
                   
                    int healing = PotionHealing
                        .Where(kvp => kvp.Key == item.Name)
                        .Select(kvp => kvp.Value)
                        .FirstOrDefault(20);
                    int oldHp = player.Health;
                    player.Health = Math.Min(100, player.Health + healing);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"  ❤️  HP restaurado: {oldHp} → {player.Health}");
                    Console.ResetColor();
                    break;

                case "Mejora":
                    player.BaseDamage += DamageBonusPerUpgrade;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"  ⚔️  Daño base aumentado: +{DamageBonusPerUpgrade} (Total: {player.BaseDamage})");
                    Console.ResetColor();
                    break;

                case "Arma":
              
                    int weaponBonus = new Dictionary<string, int>
                    {
                        { "Común", 2 }, { "Raro", 4 }, { "Épico", 7 }
                    }
                    .Where(kvp => kvp.Key == item.Rarity)
                    .Select(kvp => kvp.Value)
                    .FirstOrDefault(2);
                    player.BaseDamage += weaponBonus;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  🗡️  Arma equipada! Daño base +{weaponBonus} (Total: {player.BaseDamage})");
                    Console.ResetColor();
                    break;
            }
        }
    }
}