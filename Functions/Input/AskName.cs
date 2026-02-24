namespace Functions
{

/**
 * Clase utilitaria para manejar la entrada de datos del jugador desde consola.
 * Actualmente se encarga de solicitar el nombre del jugador.
 */
    public static class Input
    {
        
    /**
     * Solicita al jugador que ingrese su nombre.
     * Si no se ingresa ningún valor, devuelve "Hero" por defecto.
     *
     * @return Nombre del jugador ingresado o "Hero" si no se proporciona ninguno.
     */
        public static string GetPlayerName()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n➤ Cuál es tu nombre, aventurero? ");
            Console.ResetColor();
            return Console.ReadLine() ?? "Hero";
        }
    }
}


