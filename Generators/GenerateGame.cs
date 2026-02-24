using Models;

namespace Generators
{
    /**
    * Clase responsable de generar una nueva partida del juego.
    * Se encarga de crear el jugador y el conjunto de habitaciones
    * que conforman la mazmorra.
    */
    public static class GameGenerator
    {
        
    /**
     * Genera un nuevo juego con un jugador y una mazmorra de tamaño especificado.
     *
     * @param playerName Nombre del jugador que participará en la partida.
     * @param dungeonSize Número de habitaciones que tendrá la mazmorra. Por defecto 10.
     * @return Una instancia de {@code Game} con el jugador y las habitaciones generadas.
     */
        public static Game GenerateGame(string playerName, int dungeonSize = 10)
        {
            var player = new Player(playerName, 100, 10);
            var rooms = DungeonGenerator.GenerateDungeon(dungeonSize);

            return new Game(player, rooms);
        }

    }
}