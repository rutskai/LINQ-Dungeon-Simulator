using Models;

namespace Data
{
    /**
    * Clase que contiene los datos estáticos del juego.
    * Define enemigos, objetos, tipos de eventos y artículos de tienda
    * disponibles para generar partidas y mazmorras.
    */
    public static class GameData
    {
        public static Random random = new Random();

       public static List<Enemy> EnemiesAvailable = new List<Enemy>
{
    new Enemy("Goblin",    10, 5,  "Goblin",    10),  
    new Enemy("Orco",      18, 8,  "Orco",      20),  
    new Enemy("Dragón",    20, 10, "Dragón",    50),  
    new Enemy("Esqueleto", 8,  4,  "No muerto",  8),  
    new Enemy("Bruja",     14, 7,  "Mágico",    15)   
};

        public static List<Item> ItemsAvailable = new List<Item>
        {
            new Item("Espada de Hierro", "Arma",    5,  "Común"),
            new Item("Hacha de Fuego",   "Arma",    10, "Raro"),
            new Item("Poción de Vida",   "Poción",  5,  "Común"),
            new Item("Poción de Fuerza", "Poción",  8,  "Raro"),
            new Item("Anillo Místico",   "Accesorio",12, "Épico")
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


        public static List<Item> ShopItems = new List<Item>
        {
            new Item("Poción de Vida Menor",  "Poción",  15, "Común"),
            new Item("Poción de Vida Mayor",  "Poción",  30, "Raro"),
            new Item("Elixir Épico",          "Poción",  50, "Épico"),
            new Item("Daga Envenenada",        "Arma",    20, "Común"),
            new Item("Espada Flamígera",       "Arma",    40, "Raro"),
            new Item("Mandoble del Caos",      "Arma",    70, "Épico"),
            new Item("Amuleto de Fuerza",      "Mejora",  25, "Común"),
            new Item("Tótem de Poder",         "Mejora",  45, "Raro"),
            new Item("Cristal Ancestral",      "Mejora",  80, "Épico"),
        };
    }
}