namespace MenuHelpers
{
    /**
    * Clase de ayuda para la visualización de menús.
    * Proporciona métodos utilitarios para formatear y mostrar opciones
    * en consola con colores específicos.
    */
    public class Helper
    {
    /**
     * Muestra una opción de menú en consola con un color específico.
     *
     * @param number Número de la opción que se mostrará.
     * @param text   Texto descriptivo de la opción.
     * @param color  Color de la fuente para la opción en consola.
     */
         public static void PrintOption(string number, string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"   {number}. {text}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}