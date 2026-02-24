using Utils;
namespace Functions
{

    /**
     * Clase utilitaria para manejar confirmaciones de sí/no en consola.
     * Utiliza el efecto typewriter para mostrar mensajes y valida la entrada
     * recursivamente hasta obtener una respuesta válida.
     */
    public static class Confirmation
    {

        /**
         * Solicita al usuario una confirmación con el mensaje proporcionado.
         * Solo acepta "s" (sí) o "n" (no), y repite la solicitud hasta que se ingrese correctamente.
         *
         * @param message Mensaje de confirmación que se mostrará al usuario.
         * @return {@code true} si el usuario responde "s", {@code false} si responde "n".
         */
        public static bool AskConfirmation(string message)
        {
            Typewriter.WriteLine(message, ConsoleColor.Yellow, Typewriter.Speed.Fast, 0);
            Typewriter.FlushInput();
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "s") return true;
            if (input == "n") return false;

            Typewriter.WriteLine("Solo puedes responder 's' o 'n'.", ConsoleColor.Red, Typewriter.Speed.Fast, 300);
            return AskConfirmation(message);
        }

    }
}