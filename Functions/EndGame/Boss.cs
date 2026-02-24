using Models;

using Data;
using Utils;

namespace Funcions
{

/**
 * Clase que gestiona el combate contra el jefe final del juego.
 * Controla turnos de ataque del jugador y del jefe, la vida de ambos
 * y determina el final de la partida.
 */
    public class Boss
    {

    /**
     * Inicia y maneja la habitación del jefe final:
     * - Muestra un mensaje visual de aparición del jefe.
     * - Ejecuta el combate hasta que el jugador o el jefe queden sin vida.
     * - Actualiza el estado del juego a {@code IsGameOver} cuando termina.
     *
     * @param game Instancia del juego que contiene al jugador y controla el estado general.
     */
         public static void HandleBossRoom(Game game)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                  ⚡ JEFE FINAL APARECE ⚡                  ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                El guardian ancestral despierta...          ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            var boss = new Enemy("Ancient Guardian", 80, 12, "Boss");
            Console.WriteLine();

            while (boss.Health > 0 && game!.Player.Health > 0)
            {
                Typewriter.FlushInput(); 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"➤ Ataca al jefe! ");
                Console.ResetColor();
                Console.ReadLine();

                int playerDamage = game.Player.BaseDamage + GameData.random.Next(-1, 4);
                boss.Health -= playerDamage;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Haces {playerDamage} de daño! Vida del Jefe: {Math.Max(0, boss.Health)}");
                Console.ResetColor();

                if (boss.Health <= 0) break;

                int bossDamage = boss.Attack + GameData.random.Next(0, 3);
                game.Player.Health -= bossDamage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"El Jefe devuelve el ataque y hace {bossDamage} de daño! Tu vida: {Math.Max(0, game.Player.Health)}");
                Console.ResetColor();

                if (game.Player.Health <= 0)
                {
                    game.IsGameOver = true;
                    break;
                }

                System.Threading.Thread.Sleep(1000);
            }

            if (boss.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ HAS DERROTADO AL JEFE! GANAS EL JUEGO!\n");
                Console.ResetColor();
                game!.IsGameOver = true;
            }
        }

    }
}