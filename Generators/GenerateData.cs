using Models;

namespace Data
{
    public static class GameData
    {
        public static Random random = new Random();

        public static List<Enemy> EnemiesAvailable = new List<Enemy>
        {
            new Enemy("Goblin", 20, 5, "Goblin"),
            new Enemy("Orco", 30, 8, "Orco"),
            new Enemy("Dragón", 50, 15, "Dragón"),
            new Enemy("Esqueleto", 15, 4, "No muerto"),
            new Enemy("Bruja", 25, 7, "Mágico")
        };

        public static List<Item> ItemsAvailable = new List<Item>
        {
            new Item("Espada de Hierro", "Arma", 5, "Común"),
            new Item("Hacha de Fuego", "Arma", 10, "Raro"),
            new Item("Poción de Vida", "Poción", 5, "Común"),
            new Item("Poción de Fuerza", "Poción", 8, "Raro"),
            new Item("Anillo Místico", "Accesorio", 12, "Épico")
        };

          public static List<string> EventTypes = new List<string>
        {
            "Treasure Room",
            "Trap",
            "Merchant",
            "Healing Fountain",
            "Boss Fight",
            "Ambush",
            "Puzzle"
        };
    }
}
