namespace Utils
{
    /**
    * Clase de utilidades para mostrar texto en consola con efecto
    * de máquina de escribir ("typewriter").
    * Permite controlar velocidad, colores, pausas y separación de líneas.
    */
    public static class Typewriter
    {

        public static class Speed
        {
            public const int Fast = 15;
            public const int Normal = 30;
            public const int Slow = 55;
            public const int Dramatic = 90;
        }

        /**
         * Escribe texto en la consola con un color y velocidad específicos,
         * sin salto de línea.
         *
         * @param text  Texto a mostrar.
         * @param color Color del texto. Por defecto blanco.
         * @param speed Velocidad de escritura en milisegundos por carácter.
         */
        public static void Write(string text, ConsoleColor color = ConsoleColor.White, int speed = Speed.Normal)
        {
            Console.ForegroundColor = color;
            text.ToList().ForEach(c =>
            {
                Console.Write(c);
                if (!Console.KeyAvailable)
                    Thread.Sleep(speed);
            });
            Console.ResetColor();
        }

        /**
         * Escribe texto en la consola con un salto de línea al final,
         * con color, velocidad y pausa posterior configurables.
         *
         * @param text       Texto a mostrar.
         * @param color      Color del texto. Por defecto blanco.
         * @param speed      Velocidad de escritura en milisegundos por carácter.
         * @param pauseAfter Pausa en milisegundos después de escribir la línea. Por defecto 300ms.
         */
        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, int speed = Speed.Normal, int pauseAfter = 300)
        {
            Write(text, color, speed);
            Console.WriteLine();
            Thread.Sleep(pauseAfter);
        }

        /**
         * Pausa la ejecución por un tiempo determinado en milisegundos.
         *
         * @param ms Tiempo en milisegundos. Por defecto 400ms.
         */

        public static void Pause(int ms = 400)
        {
            if (!Console.KeyAvailable)
                Thread.Sleep(ms);
            Console.WriteLine();
        }

        /**
         * Imprime un separador en consola usando un carácter específico,
         * con longitud, color y velocidad configurables.
         *
         * @param symbol Carácter del separador. Por defecto '─'.
         * @param length Longitud del separador. Por defecto 61.
         * @param color  Color del separador. Por defecto amarillo oscuro.
         * @param speed  Velocidad de escritura en milisegundos por carácter.
         */
        public static void PrintSeparator(char symbol = '─', int length = 61, ConsoleColor color = ConsoleColor.DarkYellow, int speed = Speed.Fast)
        {
            Write(new string(symbol, length), color, speed);
            Console.WriteLine();
            Thread.Sleep(200);
        }

        /**
         * Limpia cualquier entrada pendiente en el buffer de consola.
         */
        public static void FlushInput()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(intercept: true);
        }

    }
}