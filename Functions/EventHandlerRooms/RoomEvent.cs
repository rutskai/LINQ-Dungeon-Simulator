using Models;
namespace Functions
{
    public static class RoomEventHandler
    {
        public static void HandleRoomEvent(Room room,Player player)
        {
            switch (room.Event)
            {
                case "Healing Fountain":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Encontraste una fuente de vida!! Recuperas 30 de vida.");
                    Console.ResetColor();
                    player.Health = Math.Min(100, player.Health + 30);
                    break;

                case "Merchant":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Un misterioso mercader aparece...");
                    Console.WriteLine("   'Puedo aumentar tu daño por 2!'");
                    Console.ResetColor();
                    player.BaseDamage += 2;
                    break;

                case "Trap":
                    Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Activaste una trampa. Recibes 10 de daño.");
                    Console.ResetColor();
                    player.Health -= 10;
                    break;

                case "Treasure Room":
                    Console.ForegroundColor = ConsoleColor.Green;
                   Console.WriteLine("Esta es una sala de tesoros legendaria! Hay artículos geniales aquí!");
                    Console.ResetColor();
                    break;

                case "Puzzle":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("🧩 Resolviste un puzzle ancestral! +15 de vida.");
                    Console.ResetColor();
                    player.Health = Math.Min(100, player.Health + 15);
                    break;

                case "Ambush":
                    Console.ForegroundColor = ConsoleColor.Red;
                   Console.WriteLine("Una emboscada! Pero lograste escapar...");
                    Console.ResetColor();
                    break;

                case "Boss Fight":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("HABITACIÓN DEL BOSS DETECTEDA!");
                    Console.ResetColor();
                    break;
            }
            Console.WriteLine();
        }
    }
}