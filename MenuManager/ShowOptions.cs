using Functions;

namespace MenuHelpers
{
     public static class ShowOptions
    {
        public static void Display()
        {
            int option =int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                Game.GenerateGame();
                break;
                case 2:
                break;
                case 3:
                break;
                default:
                Console.WriteLine("Solo puedes elegir entre la opción 1 y 3.");
                break;
            }
        }
    }
    
}