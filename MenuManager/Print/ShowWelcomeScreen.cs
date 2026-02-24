using Utils;
namespace MenuManager
{
    public class WelcomeScreen
    {

    /**
     * Muestra en consola la pantalla de bienvenida del juego.
     * Incluye bordes decorativos, historia introductoria con efecto de escritura,
     * colores y pausas para mejorar la experiencia visual.
     *
     */
        public static void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n");
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║      ⚔️  Bienvenido a la mazmorra CRAWLER ⚔️                 ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║  Explora las profundidades, derrota enemigos, sobrevive!   ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Typewriter.Pause(800);
            Typewriter.PrintSeparator('═', 62, ConsoleColor.DarkCyan);

            Typewriter.WriteLine("  Hace mucho tiempo, bajo las montañas de Valdrak,", ConsoleColor.DarkGray, Typewriter.Speed.Slow);
            Typewriter.WriteLine("  existía una mazmorra sin fondo llamada el CRAWLER.", ConsoleColor.DarkGray, Typewriter.Speed.Slow, 500);

            Typewriter.Pause(400);
            Typewriter.WriteLine("  Cuentan los ancianos que en sus entrañas duerme un mal", ConsoleColor.Gray, Typewriter.Speed.Normal);
            Typewriter.WriteLine("  antiguo... un Guardián que no conoce la piedad.", ConsoleColor.Gray, Typewriter.Speed.Normal, 500);

            Typewriter.Pause(400);
            Typewriter.WriteLine("  Cientos de aventureros han intentado llegar al fondo.", ConsoleColor.White, Typewriter.Speed.Normal);
            Typewriter.WriteLine("  Ninguno ha regresado para contarlo.", ConsoleColor.Red, Typewriter.Speed.Slow, 600);

            Typewriter.Pause(500);
            Typewriter.WriteLine("  Hoy... ese aventurero eres tú.", ConsoleColor.Yellow, Typewriter.Speed.Dramatic, 800);

            Typewriter.Pause(400);
            Typewriter.PrintSeparator('═', 62, ConsoleColor.DarkCyan);
            Typewriter.Pause(500);
            Typewriter.FlushInput();
        }
    }
}

