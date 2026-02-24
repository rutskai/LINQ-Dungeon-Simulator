namespace Models

/**
* Representa el estado general de la partida.
* Gestiona el jugador, las habitaciones del juego,
* la habitación actual y el estado de finalización.
*/
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Room> Rooms { get; set; }
        public int CurrentRoomIndex { get; set; }
        public bool IsGameOver { get; set; }

        /**
         * Constructor por defecto.
         * Inicializa un nuevo jugador, una lista vacía de habitaciones
         * y establece la partida como no finalizada.
         */
        public Game()
        {
            Player = new Player();
            Rooms = new List<Room>();
            CurrentRoomIndex = 0;
            IsGameOver = false;
        }

        /**
        * Constructor que inicializa la partida con un jugador
        * y una lista de habitaciones existentes.
        *
        * @param player Instancia del jugador que participará en la partida.
        * @param rooms  Lista de habitaciones que compondrán el recorrido del juego.
         */
        public Game(Player player, List<Room> rooms)
        {
            Player = player;
            Rooms = rooms;
            CurrentRoomIndex = 0;
            IsGameOver = false;
        }

        /**
        * Obtiene la habitación actual en la que se encuentra el jugador.
        *
        * @return La habitación correspondiente al índice actual si es válido,
        *         {@code null} si el índice está fuera de rango.
        */
        public Room? GetCurrentRoom()
        {
            if (CurrentRoomIndex >= 0 && CurrentRoomIndex < Rooms.Count)
            {
                return Rooms[CurrentRoomIndex];
            }
            return null;
        }

         /**
        * Avanza al jugador a la siguiente habitación si existe.
        *
        * @return {@code true} si se pudo avanzar a la siguiente habitación;
        *         {@code false} si ya se encuentra en la última.
        */
        public bool MoveToNextRoom()
        {
            if (CurrentRoomIndex < Rooms.Count - 1)
            {
                CurrentRoomIndex++;
                return true;
            }
            return false;
        }

         /**
        * Indica si el jugador se encuentra en la última habitación del juego.
        *
        * @return {@code true} si es la última habitación;
        *         {@code false} en caso contrario.
        */

        public bool IsLastRoom()
        {
            return CurrentRoomIndex == Rooms.Count - 1;
        }

         /**
        * Calcula cuántas habitaciones quedan por recorrer.
        *
        * @return Número de habitaciones restantes.
        */
        public int RoomsRemaining()
        {
            return Rooms.Count - CurrentRoomIndex - 1;
        }
    }
}