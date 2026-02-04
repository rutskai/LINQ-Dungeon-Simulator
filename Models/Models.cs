namespace Models
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int BaseDamage { get; set; }
        public List<Item> Inventory { get; set; }
        public int TotalDamageDealt { get; set; }
        public List<Enemy> DefeatedEnemies { get; set; }

        public Player()
        {
            Name = "Hero";
            Health = 100;
            BaseDamage = 10;
            Inventory = new List<Item>();
            TotalDamageDealt = 0;
            DefeatedEnemies = new List<Enemy>();
        }

        public Player(string name, int health, int baseDamage)
        {
            Name = name;
            Health = health;
            BaseDamage = baseDamage;
            Inventory = new List<Item>();
            TotalDamageDealt = 0;
            DefeatedEnemies = new List<Enemy>();
        }
    }

    public class Enemy
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public string Type { get; set; }

        // Constructor por defecto
        public Enemy()
        {
            Name = "Goblin";
            Health = 20;
            Attack = 5;
            Type = "Goblin";
        }

        // Constructor personalizado
        public Enemy(string name, int health, int attack, string type)
        {
            Name = name;
            Health = health;
            Attack = attack;
            Type = type;
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Value { get; set; }
        public string Rarity { get; set; }

        public Item()
        {
            Name = "Unknown Item";
            Type = "Misc";
            Value = 0;
            Rarity = "Common";
        }

        public Item(string name, string type, int value, string rarity)
        {
            Name = name;
            Type = type;
            Value = value;
            Rarity = rarity;
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Item> Items { get; set; }
        public string Event { get; set; }

        public Room()
        {
            Id = 1;
            Enemies = new List<Enemy>();
            Items = new List<Item>();
            Event = "Nothing";
        }

        public Room(int id, string eventType)
        {
            Id = id;
            Enemies = new List<Enemy>();
            Items = new List<Item>();
            Event = eventType;
        }

        public Room(int id, List<Enemy> enemies, List<Item> items, string eventType)
        {
            Id = id;
            Enemies = enemies ?? new List<Enemy>();
            Items = items ?? new List<Item>();
            Event = eventType;
        }
    }
}