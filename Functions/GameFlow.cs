using Models;
using Data;
using Generators;
using MenuManager;


namespace Functions
{
    public class GameFlow
    {
        private Game game;
        private Player player;

        private Room room;
        private bool isRunning;

        public GameFlow()
        {
            isRunning = false;
        }

        public void Start()
        {
            Console.Clear();
            WelcomeScreen.Display();
            string playerName = Input.GetPlayerName();
            
            Console.Clear();
            game = GameGenerator.GenerateGame(playerName, 10);
            player=game.Player;
            room=game.GetCurrentRoom();
            isRunning = true;

            MainGameLoop();
        }

        private void MainGameLoop()
        {
            while (!game.IsGameOver)
            {
                Console.Clear();
                ShowStatsGame.Display(player,game, room);
                DisplayCurrentRoom();
                RoomAction.ProcessRoomActions(game,player);

                if (!game.IsGameOver && game.IsLastRoom())
                {
                    HandleBossRoom();
                }

                if (!game.IsGameOver && game.RoomsRemaining() > 0)
                {
                    PromptContinue();
                }
            }

           EndGame.DisplayGameEnd(player);
        }

        

        private void DisplayCurrentRoom()
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

        private ConsoleColor GetRarityColor(string rarity)
        {
            return rarity switch
            {
                "Común" => ConsoleColor.White,
                "Raro" => ConsoleColor.Cyan,
                "Épico" => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }

        private void HandleBossRoom()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                    ⚡ FINAL BOSS APPEARS ⚡                 ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║                   The ancient guardian awakens...          ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            var boss = new Enemy("Ancient Guardian", 80, 12, "Boss");
            Console.WriteLine();

            while (boss.Health > 0 && game.Player.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"➤ Attack the boss! ");
                Console.ResetColor();
                Console.ReadLine();

                int playerDamage = game.Player.BaseDamage + GameData.random.Next(-1, 4);
                boss.Health -= playerDamage;

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"You deal {playerDamage} damage! Boss HP: {Math.Max(0, boss.Health)}");
                Console.ResetColor();

                if (boss.Health <= 0) break;

                int bossDamage = boss.Attack + GameData.random.Next(0, 3);
                game.Player.Health -= bossDamage;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The boss strikes back for {bossDamage} damage! Your HP: {Math.Max(0, game.Player.Health)}");
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
                Console.WriteLine("\n✓ YOU DEFEATED THE BOSS! YOU WON THE GAME!\n");
                Console.ResetColor();
                game.IsGameOver = true;
            }
        }

        private void PromptContinue()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n➤ Press any key to continue to the next room...");
            Console.ResetColor();
            Console.ReadKey();
            game.MoveToNextRoom();
        }

        

       
    }
}