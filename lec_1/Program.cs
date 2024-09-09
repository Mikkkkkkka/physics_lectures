namespace lec_1;

class Program
{
    record CartesianCoords(double X, double Y);
    record PolarCoords(double Distance, double Angle);
    
    static CartesianCoords ConvertPolarToCartesian(PolarCoords coords, int precision)
    {
        return new CartesianCoords(
            coords.Distance * Math.Round(Math.Cos((Math.PI / 180) * coords.Angle), precision),
            coords.Distance * Math.Round(Math.Sin((Math.PI / 180) * coords.Angle), precision));
    }
    
    static PolarCoords ConvertCartesianToPolar(CartesianCoords coords, int precision)
    {
        return new PolarCoords(
            Math.Sqrt(Math.Pow(coords.X, 2) + Math.Pow(coords.Y, 2)),
            Math.Round(Math.Atan(coords.X / coords.Y) * (180 / Math.PI), precision));
    }

    static bool TryOperation1()
    {
        Console.WriteLine("Ввод координат в Декартовой системе счисления");
        
        Console.WriteLine("Введите координату по X:");
        var input = Console.ReadLine();
        if (!double.TryParse(input, out var x))
            return false;
        
        Console.WriteLine("Введите координату по Y");
        input = Console.ReadLine();
        if (!double.TryParse(input, out var y))
            return false;
        
        Console.WriteLine("Введите точность исчисления:");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var precision))
            return false;
        
        var polared = ConvertCartesianToPolar(new CartesianCoords(x, y), precision);
        Console.WriteLine($"Координаты ({x}, {y}) в полярной систее соответствуют: ({polared.Distance}, {polared.Angle}) в декартовой.");
        
        return true;
    }
    
    static bool TryOperation2()
    {
        Console.WriteLine("Ввод координат в полярной системе счисления");
        
        Console.WriteLine("Введите расстояние:");
        var input = Console.ReadLine();
        if (!double.TryParse(input, out var distance))
            return false;
            
        Console.WriteLine("Введите угол в градусах:");
        input = Console.ReadLine();
        if (!double.TryParse(input, out var angle))
            return false;
        
        Console.WriteLine("Введите точность исчисления:");
        input = Console.ReadLine();
        if (!int.TryParse(input, out var precision))
            return false;
        
        var decarded = ConvertPolarToCartesian(new PolarCoords(distance, angle), precision);
        Console.WriteLine($"Координаты ({distance}, {angle}) в полярной систее соответствуют: ({decarded.X}, {decarded.Y}) в декартовой.");

        return true;
    }
    
    static void Main()
    {
        Console.WriteLine("Выберете преобразование:");
        Console.WriteLine("1. Из Декартовых координат в полярные.");
        Console.WriteLine("2. Из полярных координат в Декартовые.");
        
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int operation))
        {
            Console.WriteLine("Ошибка ввода");
            return;
        }

        var success = operation switch
        {
            1 => TryOperation1(),
            2 => TryOperation2(),
            _ => false
        };
        
        if (!success)
            Console.WriteLine("Ошибка ввода");
        
        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey();
    }
}