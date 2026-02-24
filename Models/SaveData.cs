using Models;

/**
 * Contiene las clases responsables de la serialización y
 * transferencia de datos necesarios para guardar y cargar la partida.
 * Incluye objetos DTO (Data Transfer Object) que permiten convertir
 * entidades del modelo a formatos persistibles.
 */
namespace Save
{

    public class SaveData
    {
        public string PlayerName       { get; set; } = "";
        public int    PlayerHealth     { get; set; }
        public int    PlayerBaseDamage { get; set; }
        public int    PlayerGold       { get; set; }
        public int    CurrentRoomIndex { get; set; }
        public int    TotalDamageDealt { get; set; }

      
        public List<ItemDTO>  Inventory        { get; set; } = new();
        public List<EnemyDTO> DefeatedEnemies  { get; set; } = new();
        public DateTime       SavedAt          { get; set; } = DateTime.Now;
    }

    public class ItemDTO
    {
        public string Name   { get; set; } = "";
        public string Type   { get; set; } = "";
        public int    Value  { get; set; }
        public string Rarity { get; set; } = "";

        public static ItemDTO FromItem(Item i)   => new() { Name = i.Name, Type = i.Type, Value = i.Value, Rarity = i.Rarity };
        public Item ToItem()                      => new(Name, Type, Value, Rarity);
    }

    public class EnemyDTO
    {
        public string Name       { get; set; } = "";
        public int    Health     { get; set; }
        public int    Attack     { get; set; }
        public string Type       { get; set; } = "";
        public int    GoldReward { get; set; }

        public static EnemyDTO FromEnemy(Enemy e) => new() { Name = e.Name, Health = e.Health, Attack = e.Attack, Type = e.Type, GoldReward = e.GoldReward };
        public Enemy ToEnemy()                     => new(Name, Health, Attack, Type, GoldReward);
    }
}