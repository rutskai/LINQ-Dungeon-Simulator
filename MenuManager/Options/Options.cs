using Functions;
using MenuManager;
using Save;
using Utils;

namespace MenuHelpers
{

    /**
    * Clase encargada de gestionar y mostrar las opciones del juego.
    * Controla el flujo del menú principal, incluyendo:
    * - Inicio de nueva partida.
    * - Carga de partida existente.
    * - Eliminación de partida guardada.
    * - Salida del juego.
    * 
    * Interactúa con {@code SaveManager}, {@code InputOption} y {@code GameFlow}.
    */
    public static class ShowOptions
    {

    /**
     * Muestra el menú de opciones y gestiona la interacción del jugador.
     * Permite seleccionar entre crear nueva partida, cargar una partida
     * existente, eliminar la partida guardada o salir del juego.
     * 
     * El método valida la existencia de partidas guardadas y utiliza confirmaciones
     * para acciones destructivas. Aplica colores y efectos de escritura tipo
     * "typewriter" para mejorar la experiencia visual.
     */
        public static void Display()
        {
            string name;
            if (SaveManager.SaveExists())
            {
                var info = SaveManager.GetSaveInfo();
                name = info!.PlayerName;
            }
            else
            {
                name = Input.GetPlayerName();
            }
            int option;

            do
            {
                ShowMainMenu.Display();
                option = InputOption.GetPlayerOption(name);

                switch (option)
                {
                    case 1:
                        GameFlow.MainGameLoop(name);
                        break;

                    case 2:
                        if (!SaveManager.SaveExists())
                        {
                            Typewriter.WriteLine("No hay ninguna partida guardada.", ConsoleColor.Red, Typewriter.Speed.Slow, 600);
                            Typewriter.FlushInput();
                            break;
                        }

                        GameFlow.LoadGameLoop();
                        break;

                    case 3:
                        if (!SaveManager.SaveExists())
                        {
                            Typewriter.WriteLine("No hay ninguna partida guardada.", ConsoleColor.Red, Typewriter.Speed.Fast, 400);
                            break;
                        }
                        if (Confirmation.AskConfirmation("¿Seguro que quieres eliminar la partida? (s/n): "))
                        {
                            SaveManager.DeleteSave();
                            name = Input.GetPlayerName();
                        }
                        break;

                    case 4:
                        Typewriter.WriteLine("Saliendo...", ConsoleColor.Red, Typewriter.Speed.Fast, 400);
                        return;

                    default:
                        Typewriter.WriteLine("Solo puedes elegir entre la opción 1 y 4.", ConsoleColor.Red, Typewriter.Speed.Fast, 400);
                        Typewriter.FlushInput();
                        break;
                }

            } while (option != 4);
        }
    }

}