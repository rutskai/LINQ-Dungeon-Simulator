using Models;
using Data;

namespace Generators
{
    /**
    * Clase responsable de generar la mazmorra del juego.
    * Crea una lista de habitaciones con enemigos, objetos y eventos
    * aleatorios, respetando la estructura del dungeon y colocando
    * un jefe en la última habitación.
    */
    public static class DungeonGenerator
    {

        /**
        * Genera una mazmorra con un número determinado de habitaciones.
        * Cada habitación contiene enemigos, objetos y un evento aleatorio.
        * La última habitación siempre contiene un "Boss Fight".
        *
        * @param roomCount Número de habitaciones que tendrá la mazmorra. Por defecto 10.
        * @return Lista de {@code Room} que conforman la mazmorra generada.
        */
        public static List<Room> GenerateDungeon(int roomCount = 10)
        {
          
            var normalEvents = GameData.EventTypes
                .Where(e => e != "Boss Fight")
                .ToList();

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

                  
                    Event = normalEvents[GameData.random.Next(normalEvents.Count)]
                })
                .ToList();

            var lastRoom = dungeon.Last();
            lastRoom.Event   = "Boss Fight";
            lastRoom.Enemies.Clear();
            lastRoom.Items.Clear();

            return dungeon;
        }
    }
}