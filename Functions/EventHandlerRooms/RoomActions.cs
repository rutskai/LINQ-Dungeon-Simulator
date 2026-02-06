using Models;

namespace Functions
{
    public class RoomAction
    {
        public static void ProcessRoomActions(Game game, Player player)
        {
            var room = game.GetCurrentRoom();
            if (room == null) return;

            // Pelear con enemigos
            if (room.Enemies.Count > 0)
            {
               Fight.FightEnemies(room.Enemies, player, game);
                
            }

            // Recoger items
            if (room.Items.Count > 0)
            {
                foreach (var item in room.Items)
                {
                    game.Player.Inventory.Add(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"✓ Picked up: {item.Name}");
                    Console.ResetColor();
                }
                room.Items.Clear();
            }
            RoomEventHandler.HandleRoomEvent(room, player);
        }
    }



}