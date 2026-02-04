using Models;
using Data;

namespace Generators
{

   /* Mezcla la lista completa de enemigos disponibles.

Toma 1 a 3 enemigos al azar para la sala.

Clona cada enemigo para que tenga vida propia y no afecte a otras salas.

Devuelve una lista lista para asignarla a Room.Enemies.*/

    public static class DungeonGenerator
    {
        public static List<Room> GenerateDungeon(int roomCount = 10)
        {
            var dungeon = Enumerable.Range(1, roomCount)
                .Select(id => new Room
                {
                    Id = id,

                    
                    Enemies = GameData.EnemiesAvailable
                        .OrderBy(_ => GameData.random.Next())
                        .Take(GameData.random.Next(1, 4))
                        .Select(e => new Enemy(e.Name, e.Health, e.Attack, e.Type))
                        .ToList(),

                   
                    Items = GameData.ItemsAvailable
                        .Where(o => o.Value > 0)
                        .OrderBy(_ => GameData.random.Next())
                        .Take(GameData.random.Next(0, 2))
                        .Select(i => new Item(i.Name, i.Type, i.Value, i.Rarity))
                        .ToList(),

                    
                    Event = GameData.EventTypes[GameData.random.Next(GameData.EventTypes.Count)]
                })
                .ToList();

            return dungeon;
        }
    }
}
