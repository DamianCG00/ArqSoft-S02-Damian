namespace Ahorcado
{
    public class ConsolaUI
    {
        private readonly MotorAhorcado _motor;
        public ConsolaUI(MotorAhorcado motor)
        {
            _motor = motor;
        }

        public void MostrarTablero()
        {
            Console.Clear();
            MostrarAhorcado();
            Console.WriteLine($"Intentos restantes: {_motor.IntentosRestantes}");
            Console.WriteLine($"Letras usadas: {string.Join(",", _motor.LetrasUsadas)}");
            if (_motor.MostrarPista)
                Console.WriteLine($"Pista: la palabra empieza con '{_motor.PalabraSecreta[0]}'");
            
            Console.Write("Palabra: ");
            foreach (char c in _motor.PalabraSecreta)
                Console.Write(_motor.LetrasUsadas.Contains(c) ? c : '_');
            Console.WriteLine();
        }

        public char PedirLetra()
        {
            Console.Write("\nIngresa una letra: ");
            return Console.ReadLine()[0];
        }

        public void MostrarMensaje(string mensaje) => Console.WriteLine(mensaje);

        public bool PreguntarOtraVez()
        {
            Console.Write("\n¿Jugar otra vez? (s/n): ");
            return Console.ReadLine()?.ToLower() == "s";
        }

        public static int PedirCategoria()
        {
            Console.Clear();
            Console.WriteLine("=== SELECCIONA UNA CATEGORÍA ===");
            Console.WriteLine("1. Arquitectura");
            Console.WriteLine("2. POO");
            Console.WriteLine("3. .NET");
            Console.Write("\nElige una opción (1-3): ");

            // Validamos que el usuario ingrese un número del 1 al 3
            if (int.TryParse(Console.ReadLine(), out int opcion) && opcion >= 1 && opcion <= 3)
            {
                return opcion;
            }

            return 1; // Si introduce un error, por defecto seleccionamos la 1
        }


        private void MostrarAhorcado()
        {
            string[] etapas = new string[]
            {
                " -----\n |   |\n     |\n     |\n     |\n     |\n=========",
                " -----\n |   |\n O   |\n     |\n     |\n     |\n=========",
                " -----\n |   |\n O   |\n |   |\n     |\n     |\n=========",
                " -----\n |   |\n O   |\n/|   |\n     |\n     |\n=========",
                " -----\n |   |\n O   |\n/|\\  |\n     |\n     |\n=========",
                " -----\n |   |\n O   |\n/|\\  |\n/    |\n     |\n=========",
                " -----\n |   |\n O   |\n/|\\  |\n/ \\  |\n     |\n========="
            };
            Console.WriteLine(etapas[6 - _motor.IntentosRestantes]);
        }
    }
}