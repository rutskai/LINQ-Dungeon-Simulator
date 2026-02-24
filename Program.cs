using MenuHelpers;
using MenuManager;
public class Program
{

  /**
     * Método principal que inicia la ejecución del programa.
     * Primero muestra la pantalla de bienvenida y después muestra
     * las opciones disponibles en el menú.
     *
     */
  public static void Main()
    {
      WelcomeScreen.Display();
      ShowOptions.Display();       
    }
}

