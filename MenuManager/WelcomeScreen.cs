namespace MenuManager
{
    public class WelcomeScreen
    {
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
        }
    }
}

