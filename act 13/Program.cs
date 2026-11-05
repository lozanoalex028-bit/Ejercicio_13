Console.WriteLine("SISTEMA DE CONTROL DE MOTORES");
Console.WriteLine();

// Seleccionar el tipo de motor
Console.WriteLine("Seleccione el tipo de motor que desea verificar:");
Console.WriteLine("1. Motor de corriente directa (CD)");
Console.WriteLine("2. Motor de corriente alterna (AC)");
Console.WriteLine("3. Servomotor");
Console.Write("Opcion: ");

int opcion;

if (!int.TryParse(Console.ReadLine(), out opcion))
{
    Console.WriteLine("Error: debe ingresar un numero.");
    return;
}
Console.WriteLine();

switch (opcion)
{
    case 1:
        // Crear objeto MotorCD
        MotorCD motorCD1 = new MotorCD();

        Console.WriteLine("DATOS DEL MOTOR CD");

        Console.Write("Ingrese el identificador del motor: ");
        motorCD1.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la temperatura del motor: ");
        motorCD1.Temperatura = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la corriente del motor: ");
        motorCD1.Corriente = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la velocidad del motor en rpm: ");
        motorCD1.Velocidad = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el voltaje del motor: ");
        motorCD1.Voltaje = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("RESULTADOS DEL MOTOR CD");
        Console.WriteLine($"Identificador: {motorCD1.Identificador}");
        Console.WriteLine($"Temperatura: {motorCD1.Temperatura} °C");
        Console.WriteLine($"Corriente: {motorCD1.Corriente} A");
        Console.WriteLine($"Velocidad: {motorCD1.Velocidad} rpm");
        Console.WriteLine($"Voltaje: {motorCD1.Voltaje} V");
        Console.WriteLine($"Estado: {motorCD1.ObtenerEstado()}");
        Console.WriteLine($"Revision de temperatura: {motorCD1.RevisarTemperatura()}");
        break;

    case 2:
        // Crear objeto MotorAC
        MotorAC motorAC1 = new MotorAC();

        Console.WriteLine("DATOS DEL MOTOR AC");

        Console.Write("Ingrese el identificador del motor: ");
        motorAC1.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la temperatura del motor: ");
        motorAC1.Temperatura = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la corriente del motor: ");
        motorAC1.Corriente = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la velocidad del motor en rpm: ");
        motorAC1.Velocidad = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese las fases de operacion (1, 2 o 3): ");
        motorAC1.Fases = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("RESULTADOS DEL MOTOR AC");
        Console.WriteLine($"Identificador: {motorAC1.Identificador}");
        Console.WriteLine($"Temperatura: {motorAC1.Temperatura} °C");
        Console.WriteLine($"Corriente: {motorAC1.Corriente} A");
        Console.WriteLine($"Velocidad: {motorAC1.Velocidad} rpm");
        Console.WriteLine($"Fases: {motorAC1.Fases}");
        Console.WriteLine($"Tipo de alimentacion: {motorAC1.ObtenerTipoFase()}");
        Console.WriteLine($"Estado: {motorAC1.ObtenerEstado()}");
        Console.WriteLine($"Revision de temperatura: {motorAC1.RevisarTemperatura()}");
        break;

    case 3:
        // Crear objeto Servomotor
        Servomotor servo1 = new Servomotor();

        Console.WriteLine("DATOS DEL SERVOMOTOR");

        Console.Write("Ingrese el identificador del motor: ");
        servo1.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la temperatura del motor: ");
        servo1.Temperatura = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la corriente del motor: ");
        servo1.Corriente = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la velocidad del motor en rpm: ");
        servo1.Velocidad = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese la posicion angular en grados: ");
        servo1.PosicionAngular = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("RESULTADOS DEL SERVOMOTOR");
        Console.WriteLine($"Identificador: {servo1.Identificador}");
        Console.WriteLine($"Temperatura: {servo1.Temperatura} °C");
        Console.WriteLine($"Corriente: {servo1.Corriente} A");
        Console.WriteLine($"Velocidad: {servo1.Velocidad} rpm");
        Console.WriteLine($"Posicion angular: {servo1.PosicionAngular} grados");
        Console.WriteLine($"Estado: {servo1.ObtenerEstado()}");
        Console.WriteLine($"Revision de temperatura: {servo1.RevisarTemperatura()}");
        break;

    default:
        Console.WriteLine("Opcion no valida. Seleccione 1, 2 o 3.");
        break;
}


// CLASE BASE
class Motor
{
    // Propiedades comunes a todos los motores
    public string Identificador { get; set; } = "";
    public double Temperatura { get; set; }
    public double Corriente { get; set; }
    public double Velocidad { get; set; }

    // Metodo para determinar el estado
    public string ObtenerEstado()
    {
        if (Velocidad > 0)
            return "Motor en marcha";
        else
            return "Motor detenido";
    }

    // Metodo para revisar la temperatura
    public string RevisarTemperatura()
    {
        if (Temperatura > 70)
            return "ALERTA: Temperatura elevada";

        return "Temperatura normal";
    }
}


// SUBCLASE 1: MOTOR DE CORRIENTE DIRECTA
class MotorCD : Motor
{
    public double Voltaje { get; set; }
}


// SUBCLASE 2: MOTOR DE CORRIENTE ALTERNA
class MotorAC : Motor
{
    public int Fases { get; set; }

    public string ObtenerTipoFase()
    {
        switch (Fases)
        {
            case 1:
                return "Monofasico";

            case 2:
                return "Bifasico";

            case 3:
                return "Trifasico";

            default:
                return "Numero de fases no valido";
        }
    }
}


// SUBCLASE 3: SERVOMOTOR
class Servomotor : Motor
{
    public double PosicionAngular { get; set; }
}