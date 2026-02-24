using Models;
using Utils;

namespace Functions
{
    /**
    * Clase que maneja los eventos especiales dentro de una habitación.
    * Cada evento afecta al jugador de manera diferente, como curación,
    * aumento de daño, daño por trampas, puzzles o emboscadas.
    */
    public static class RoomEventHandler
    {

    /**
     * Procesa el evento de la habitación actual y aplica sus efectos al jugador.
     * - Healing Fountain: cura 15 puntos de vida.
     * - Merchant: aumenta el daño base del jugador en 2.
     * - Trap: inflige 10 de daño al jugador.
     * - Puzzle: cura 15 puntos de vida.
     * - Ambush: notifica emboscada sin daño.
     * - Boss Fight: notifica encuentro con el jefe.
     *
     * @param room   Instancia de la habitación actual con el evento.
     * @param player Instancia del jugador que recibe el efecto del evento.
     */
        public static void HandleRoomEvent(Room room, Player player)
        {
            switch (room.Event)
            {
                case "Healing Fountain":
                    Typewriter.WriteLine("Encontraste una fuente de vida!! Recuperas 15 de vida.", ConsoleColor.Cyan, Typewriter.Speed.Slow);
                    
                    player.Health = Math.Min(100, player.Health + 15);
                    break;

                case "Merchant":
                    Typewriter.WriteLine("Un misterioso mercader aparece...", ConsoleColor.Yellow, Typewriter.Speed.Slow);
                    Typewriter.WriteLine("   'Puedo aumentar tu daño por 2!'", ConsoleColor.Yellow, Typewriter.Speed.Normal, 500);
                    player.BaseDamage += 2;
                    break;

                case "Trap":
                    Typewriter.WriteLine("Activaste una trampa. Recibes 10 de daño.", ConsoleColor.Red, Typewriter.Speed.Slow, 500);
                    player.Health -= 10;
                    break;

                case "Puzzle":
                    Typewriter.WriteLine("Resolviste un puzzle ancestral! +15 de vida.", ConsoleColor.Magenta, Typewriter.Speed.Slow, 500);
                    player.Health = Math.Min(100, player.Health + 15);
                    break;

                case "Ambush":
                    Typewriter.WriteLine("Una emboscada! Pero lograste escapar...", ConsoleColor.Red, Typewriter.Speed.Slow, 500);
                    break;

                case "Boss Fight":
                    Typewriter.WriteLine("HABITACIÓN DEL BOSS DETECTEDA!", ConsoleColor.Red, Typewriter.Speed.Slow, 500);
                    break;
            }

            Typewriter.Pause(300);
        }
    }
}