namespace MenuHelpers
{
    public class Helper
    {
         public static void PrintOption(string number, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"   {number}. {text}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}