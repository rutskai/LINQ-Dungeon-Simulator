namespace Functions
{
    public static class InputOption
    {
        public static int GetPlayerOption(string name)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\n➤ Elige una opción, {name}: ");
            Console.ResetColor();

            string input = Console.ReadLine()!;

            if (int.TryParse(input, out int option))
            {
                return option; 
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Eso no es un número. Intenta de nuevo.");
            Console.ResetColor();

       
            return GetPlayerOption(name);
        }
    }
}