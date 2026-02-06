using Models;

namespace Generators
{
    public static class GameGenerator
    {
        public static Game GenerateGame(string playerName, int dungeonSize = 10)
        {
            var player = new Player(playerName, 100, 10);
            var rooms = DungeonGenerator.GenerateDungeon(dungeonSize);

            return new Game(player, rooms);
        }

    }
}