using Models;
using Utils;
using Functions;

namespace MenuManager
{

/**
 * Clase que muestra el final del juego con un mensaje de victoria o derrota,
 * y luego despliega las estadísticas finales del jugador.
 */
    public static class GameEnd
    {
        
    /**
     * Muestra la pantalla final del juego en consola:
     * - Mensaje de victoria si el jugador sobrevive.
     * - Mensaje de derrota si el jugador muere.
     * - Llama a {@code EndGame.DisplayFinalStats} para mostrar las estadísticas finales.
     *
     * @param player Instancia del jugador cuyo estado y estadísticas se mostrarán.
     */
        public static void DisplayGameEnd(Player player)
        {
          
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");

            if (player.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("║                     🎉 VICTORIA! 🎉                        ║");
                
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("║                    💀 PARTIDA TERMINADA 💀                 ║");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
            Typewriter.Pause(2000);

           EndGame.DisplayFinalStats(player);
        }
    }
}