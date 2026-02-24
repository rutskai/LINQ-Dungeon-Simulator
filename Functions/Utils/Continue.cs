using Models;

namespace Utils
{

/**
 * Clase utilitaria para manejar la pausa entre habitaciones.
 * Permite al jugador continuar a la siguiente habitación al presionar una tecla.
 */
    public static class Continue
    {
        
    /**
     * Muestra un mensaje en consola indicando que el jugador
     * debe presionar cualquier tecla para avanzar a la siguiente habitación.
     * Limpia cualquier entrada pendiente antes de esperar la interacción.
     *
     * @param game Instancia de {@code Game} que permitirá avanzar de habitación.
     */
    public static void PromptContinue(Game game)
        {
            Typewriter.FlushInput();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n➤ Presiona cualquier tecla apara continuar a la siguiente habitación...");
            Console.ResetColor();
            Console.ReadKey();
            game!.MoveToNextRoom();
        }
    }
}