using Models;
using Utils;

namespace Functions
{

/**
 * Clase que muestra las estadísticas finales del jugador al terminar la partida.
 * Incluye vida final, daño total, enemigos derrotados y objetos recogidos.
 */
    public static class EndGame
    {
        
    /**
     * Muestra en consola los detalles finales del jugador.
     * - Estadísticas básicas: nombre, vida, daño total, enemigos derrotados y cantidad de objetos.
     * - Lista de objetos recogidos si el jugador posee alguno.
     *
     * @param player Instancia del jugador cuyas estadísticas se mostrarán.
     */

        public static void DisplayFinalStats(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════════\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ESTADÍSTICAS FINALES:");
            Console.ResetColor();

            Console.WriteLine($"  Nombre: {player.Name}");
            Console.WriteLine($"  Vida final: {player.Health}");
            Console.WriteLine($"  Daño total infligido: {player.TotalDamageDealt}");
            Console.WriteLine($"  Enemigos derrotados: {player.DefeatedEnemies.Count}");
            Console.WriteLine($"  Objetos recogidos: {player.Inventory.Count}");

            if (player.Inventory.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n  Inventario:");
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



    }
}