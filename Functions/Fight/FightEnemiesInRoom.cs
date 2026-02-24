using Models;
using Data;

namespace Functions{

/**
 * Clase que gestiona los combates entre el jugador y los enemigos.
 * Controla turnos, cálculo de daño, vida de ambos y recompensas.
 */
    public class Fight
    {

    /**
     * Ejecuta un combate entre el jugador y una lista de enemigos.
     * - Aplica daño al enemigo según el ataque del jugador y un factor aleatorio.
     * - Aplica daño al jugador según el ataque del enemigo y un factor aleatorio.
     * - Actualiza vida, oro, daño total y enemigos derrotados.
     * - Finaliza la partida si la vida del jugador llega a 0.
     *
     * @param enemies Lista de enemigos a enfrentar.
     * @param player  Instancia del jugador que combate.
     * @param game    Instancia del juego que controla estado general (game over).
     */

        public static void FightEnemies(List<Enemy> enemies, Player player, Game game)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n   El combate empieza!   \n");
            Console.ResetColor();

            foreach (var enemy in enemies.ToList())
            {
                while (enemy.Health > 0 && player.Health > 0)
                {
    
                    int playerDamage = player.BaseDamage + GameData.random.Next(-2, 3);
                    enemy.Health -= playerDamage;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"→ Atacas a {enemy.Name} por {playerDamage} de daño!");
                    Console.ResetColor();
                    Console.WriteLine($" (Vida del enemigo: {Math.Max(0, enemy.Health)})");

                    if (enemy.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"✓ {enemy.Name} derrotado!\n");
                        Console.ResetColor();
                        player.TotalDamageDealt += playerDamage;
                        player.DefeatedEnemies.Add(enemy);


                        int goldEarned = enemies
                            .Where(e => e.Health <= 0)
                            .Sum(e => e.GoldReward);
                        player.Gold += enemy.GoldReward;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"💰 +{enemy.GoldReward} oro! (Total: {player.Gold} oro)");
                        Console.ResetColor();
                        break;
                    }

        
                    int enemyDamage = enemy.Attack + GameData.random.Next(-1, 2);
                    player.Health -= enemyDamage;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"← {enemy.Name} te ataca por {enemyDamage} de daño!");
                    Console.ResetColor();
                    Console.WriteLine($" (Tu vida: {Math.Max(0, player.Health)})");

                    if (player.Health <= 0)
                    {
                        game.IsGameOver = true;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n💀 HAS SIDO DERROTADO!\n");
                        Console.ResetColor();
                        return;
                    }

                    System.Threading.Thread.Sleep(800);
                }
            }

            enemies.RemoveAll(e => e.Health <= 0);
        }
    }
}