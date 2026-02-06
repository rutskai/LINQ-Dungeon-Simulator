using Models;

namespace MenuManager
{
    public static class ShowStatsGame
    {
        public static void Display(Player player, Game game, Room room)
        {
             Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ 🧙 {player.Name,-28} 💚 HP: {player.Health,3}/{100,-3}      ║");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"║ 🏛️  Room {game.CurrentRoomIndex + 1,2}/{game.Rooms.Count,-2}  |  Remaining: {game.RoomsRemaining(),-2}  |  Damage Dealt: {player.TotalDamageDealt,-6} ║");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
    }
    }
}
