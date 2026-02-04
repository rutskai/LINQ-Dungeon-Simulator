using MenuHelpers;

namespace MenuManager
{
    public class ShowVictoryMenu
    {
        public static void Display()
        {
            Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("        ╔═══════════════════════════════════════════════╗");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        ║                                               ║");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("        ║           🏆  ¡VICTORIA ÉPICA!  🏆            ║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        ║                                               ║");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("        ║        ¡Has conquistado la mazmorra!          ║");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("        ║                                               ║");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("        ╚═══════════════════════════════════════════════╝");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("               El héroe ha triunfado sobre las");
            Console.WriteLine("               sombras de la oscuridad...");

         
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("               ═══════════════════════════════");
            Console.WriteLine();

            // Opciones con iconos mejorados
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                    ¿Qué deseas hacer?");
            Console.WriteLine();
            
            Helper.PrintOption("1", "📊 Ver estadísticas finales", ConsoleColor.Cyan);
            Helper.PrintOption("2", "🔄 Comenzar nueva aventura", ConsoleColor.Green);
            Helper.PrintOption("3", "🏠 Regresar al menú principal", ConsoleColor.Magenta);

            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  ➤  Selecciona tu destino: ");
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}