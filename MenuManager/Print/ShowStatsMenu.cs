using Models;

namespace MenuManager
{
    public static class ShowStatsGame
    {

    /**
     * Muestra por consola la información del jugador y del juego.
     * Incluye:
     * - Nombre del jugador y vida.
     * - Habitación actual, habitaciones restantes y daño total hecho.
     * - Oro, daño base y cantidad de objetos en el inventario.
     * Aplica colores y bordes decorativos para mejorar la visualización.
     *
     * @param player Instancia del jugador cuyas estadísticas se mostrarán.
     * @param game   Instancia del juego para mostrar la habitación y progreso.
     * @param room   Instancia de la habitación actual (puede usarse para detalles adicionales).
     */
        public static void Display(Player player, Game game, Room room)
        {
           
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"║ 🧙 {player.Name,-28} 💚 Vida: {player.Health,3}/{100,-3}           ║");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"║ 🏛️  Habitación {game.CurrentRoomIndex + 1,2}/{game.Rooms.Count,-2}  |  Quedan: {game.RoomsRemaining(),-2}  |  Daño hecho: {player.TotalDamageDealt,-6}  ║");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╠════════════════════════════════════════════════════════════╣"); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"║ 💰 Oro: {player.Gold,-5}  |  ⚔️  Daño base: {player.BaseDamage,-3}  |  Objetos: {player.Inventory.Count,-3}       ║"); 
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
        }
    }
}