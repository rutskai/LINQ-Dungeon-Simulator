using Models;
using Utils;

namespace Functions
{

/**
 * Clase que procesa todas las acciones que ocurren dentro de una habitación.
 * Incluye combate contra enemigos, recolección de objetos y manejo de eventos.
 */
    public class RoomAction
    {
        
    /**
     * Ejecuta las acciones correspondientes a la habitación actual:
     * - Si hay enemigos, inicia el combate con {@code FightEnemies}.
     * - Si hay objetos, los añade al inventario del jugador.
     * - Procesa el evento de la habitación mediante {@code RoomEventHandler}.
     *
     * @param game   Instancia del juego que contiene la habitación actual.
     * @param player Instancia del jugador que interactúa con la habitación.
     */
        public static void ProcessRoomActions(Game game, Player player)
        {
            var room = game.GetCurrentRoom();
            if (room == null) return;

        
            if (room.Enemies.Any())
            {
                Typewriter.Pause(600);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("   [Presiona ENTER para entrar en combate]");
                Console.ResetColor();
                Console.ReadLine();

                Fight.FightEnemies(room.Enemies, player, game);

                if (game.IsGameOver) return;

                Typewriter.Pause(500);
                Typewriter.PrintSeparator();
            }

       
            if (room.Items.Any())
            {
                Typewriter.Pause(400);
                Typewriter.WriteLine("Inspeccionas la sala...", ConsoleColor.DarkYellow, Typewriter.Speed.Slow, 400);

                room.Items
                    .ToList()
                    .ForEach(item =>
                    {
                        Typewriter.Pause(300);
                        game.Player.Inventory.Add(item);
                        Typewriter.WriteLine($"   ✓ Recogiste: {item.Name} [{item.Rarity}]",
                            ConsoleColor.Green, Typewriter.Speed.Normal, 350);
                    });

                room.Items.Clear();
                Typewriter.Pause(400);
                Typewriter.PrintSeparator();
            }

         
            Typewriter.Pause(500);
            RoomEventHandler.HandleRoomEvent(room, player);
        }
    }
}