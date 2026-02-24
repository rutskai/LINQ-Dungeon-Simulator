using MenuHelpers;

namespace MenuManager{

    public static class ShowMainMenu
    {
        
    /**
     * Muestra en consola el menú principal con las siguientes opciones:
     * - Nueva Partida
     * - Cargar Partida
     * - Eliminar Partida Guardada
     * - Salir
     * Aplica colores y separadores para mejorar la visualización.
     */
        public static void Display()
        {
       
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Helper.PrintOption("1", "Nueva Partida", ConsoleColor.Green);
            Helper.PrintOption("2", "Cargar Partida", ConsoleColor.Cyan);
            Helper.PrintOption("3", "Eliminar Partida Guardada", ConsoleColor.Blue);
            Helper.PrintOption("4", "Salir", ConsoleColor.Red);

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("═══════════════════════════════════════════════════════════");

          }
    }
}
