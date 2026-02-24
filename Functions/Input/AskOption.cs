namespace Functions
{

/**
 * Clase utilitaria para manejar la entrada de opciones del jugador desde consola.
 * Permite solicitar un número correspondiente a la opción deseada
 * y valida que la entrada sea correcta.
 */
    public static class InputOption
    {
        
    /**
     * Solicita al jugador elegir una opción y valida que sea un número.
     * En caso de entrada inválida, vuelve a pedirla de forma recursiva.
     *
     * @param name Nombre del jugador para personalizar el mensaje.
     * @return Número de la opción elegida por el jugador.
     */
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