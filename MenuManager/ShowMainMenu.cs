using MenuHelpers;

namespace MenuManager{

    public static class ShowMainMenu
    {
        public static void Display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

          
            Console.WriteLine("╔═══════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                       ║");
            Console.WriteLine("║                ⚔️  DUNGEON ADVENTURE ⚔️                 ║");
            Console.WriteLine("║                                                       ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Helper.PrintOption("1", "Nueva Partida", ConsoleColor.Green);
            Helper.PrintOption("2", "Cargar Partida", ConsoleColor.Cyan);
            Helper.PrintOption("3", "Opciones", ConsoleColor.Magenta);
            Helper.PrintOption("4", "Créditos", ConsoleColor.Blue);
            Helper.PrintOption("5", "Salir", ConsoleColor.Red);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("   Selecciona una opción: ");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    
    }
}
