using Models;
using Data;

namespace Functions{

    public class Fight
    {

        public static void FightEnemies(List<Enemy> enemies, Player player, Game game)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n   El combate empieza!   \n");
            Console.ResetColor();

            foreach (var enemy in enemies.ToList())
            {
                while (enemy.Health > 0 && player.Health > 0)
                {
                    // Ataque del jugador
                    int playerDamage = player.BaseDamage + GameData.random.Next(-2, 3);
                    enemy.Health -= playerDamage;

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"→ You attack {enemy.Name} for {playerDamage} damage!");
                    Console.ResetColor();
                    Console.WriteLine($" (Enemy HP: {Math.Max(0, enemy.Health)})");

                    if (enemy.Health <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"✓ {enemy.Name} defeated!\n");
                        Console.ResetColor();
                        player.TotalDamageDealt += playerDamage;
                        player.DefeatedEnemies.Add(enemy);
                        break;
                    }

                    // Ataque del enemigo
                    int enemyDamage = enemy.Attack + GameData.random.Next(-1, 2);
                    player.Health -= enemyDamage;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"← {enemy.Name} attacks you for {enemyDamage} damage!");
                    Console.ResetColor();
                    Console.WriteLine($" (Your HP: {Math.Max(0, player.Health)})");

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