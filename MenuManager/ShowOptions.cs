using Functions;
using Generators;

namespace MenuHelpers
{
     public static class ShowOptions
    {
        public static void Display()
        {
            Console.WriteLine("Cuál es tu nombre?");
            string name= Console.ReadLine() ?? "";
            int option =int.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                
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