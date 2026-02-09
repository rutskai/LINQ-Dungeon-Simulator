using Functions;
using Generators;
using MenuManager;

namespace MenuHelpers
{
     public static class ShowOptions
    {
        public static void Display()
        {
            string name= Input.GetPlayerName();
            ShowMainMenu.Display();
            int option =InputOption.GetPlayerOption(name);

            switch (option)
            {
                case 1:
                var GameFlow= new GameFlow();
                GameFlow.MainGameLoop(name);
                
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