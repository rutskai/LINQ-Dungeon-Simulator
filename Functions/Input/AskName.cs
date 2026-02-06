namespace Functions
{
    public static class Input
    {
        public static string GetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n➤ Cuál es tu nombre, aventurero? ");
            Console.ResetColor();
            return Console.ReadLine() ?? "Hero";
        }
    }
}


