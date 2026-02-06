namespace Models
{
    public class Game
    {
        public Player Player { get; set; }
        public List<Room> Rooms { get; set; }
        public int CurrentRoomIndex { get; set; }
        public bool IsGameOver { get; set; }

        public Game()
        {
            Player = new Player();
            Rooms = new List<Room>();
            CurrentRoomIndex = 0;
            IsGameOver = false;
        }

        public Game(Player player, List<Room> rooms)
        {
            Player = player;
            Rooms = rooms;
            CurrentRoomIndex = 0;
            IsGameOver = false;
        }

        public Room GetCurrentRoom()
        {
            if (CurrentRoomIndex >= 0 && CurrentRoomIndex < Rooms.Count)
            {
                return Rooms[CurrentRoomIndex];
            }
            return null;
        }

        public bool MoveToNextRoom()
        {
            if (CurrentRoomIndex < Rooms.Count - 1)
            {
                CurrentRoomIndex++;
                return true;
            }
            return false;
        }

        public bool IsLastRoom()
        {
            return CurrentRoomIndex == Rooms.Count - 1;
        }

        public int RoomsRemaining()
        {
            return Rooms.Count - CurrentRoomIndex - 1;
        }
    }
}