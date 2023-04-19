// Написать программу, имеющую список делегатов для математических операций(+ - * /). 
// Пользователь должен иметь возможность выбрать операцию и ввести два числа. 
// Программа должна вызвать соответсвующий делегат и вывести результат. 
// В программе должен присутствовать интерфейс IMath, который будет содержать методы для всех 4 математических операций
// Интерфейс прописываем самостоятельно.


Math Plus = IMath.Plus;
Math Minus = IMath.Minus;
Math Multiply = IMath.Multiply;
Math Divide = IMath.Divide;
void Menu()
{
    ConsoleKeyInfo key;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Выберите операцию");
        Console.WriteLine("1. Сложение");
        Console.WriteLine("2. Вычитание");
        Console.WriteLine("3. Умножение");
        Console.WriteLine("4. Деление");

        double[] nums = new double[2];
        double result;
        key = Console.ReadKey();
        Disappear();
        switch (key.Key)
        {
            case ConsoleKey.D1:
                {
                    Console.Write("Введите два числа через пробел: ");
                    while (true)
                    {
                        try
                        {
                            nums = Console.ReadLine().Split(' ').Select(Double.Parse).ToArray();
                            result = Plus(nums[0], nums[1]);
                            break;
                        }
                        catch
                        {
                            Console.Write("Введите два числа через пробел: ");
                        }
                    }
                    Console.WriteLine($"Сумма двух чисел равна: {result}");
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D2:
                {
                    Console.Write("Введите два числа через пробел: ");
                    while (true) 
                    { 
                        try
                        {
                            nums = Console.ReadLine().Split(' ').Select(Double.Parse).ToArray();
                            result = Minus(nums[0], nums[1]);
                            break;
                        }
                        catch
                        {
                            Console.Write("Введите два числа через пробел: ");
                        }
                    }
                    Console.WriteLine($"Разность двух чисел равна: {result}");
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D3:
                {
                    Console.Write("Введите два числа через пробел: ");
                    while (true)
                    {
                        try
                        {
                            nums = Console.ReadLine().Split(' ').Select(Double.Parse).ToArray();
                            result = Multiply(nums[0], nums[1]);
                            break;
                        }
                        catch
                        {
                            Console.Write("Введите два числа через пробел: ");
                        }
                    }

                    Console.WriteLine($"Произведение двух чисел равно: {result}");
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D4:
                {
                    Console.Write("Введите два числа через пробел: ");
                    while (true)
                    {
                        try
                        {
                            nums = Console.ReadLine().Split(' ').Select(Double.Parse).ToArray();
                            result = Divide(nums[0], nums[1]);
                            break;
                        }
                        catch
                        {
                            Console.Write("Введите два числа через пробел: ");
                        }
                    }
                    Console.WriteLine($"Частное двух чисел равно: {result}");
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            default: break;
        }
    }
}
void Disappear()
{
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(" ");
    Console.SetCursorPosition(0, Console.CursorTop);
}

Menu();

delegate double Math(double left, double right);

interface IMath
{
    static double Plus(double left, double right)
    {
        return left + right;
    }
    static double Minus(double left, double right)
    {
        return left - right;
    }
    static double Multiply(double left, double right)
    {
        return left * right;
    }
    static double Divide(double left, double right)
    {
        if (right == 0)
        {
            return double.NaN;
        }
        return left / right; 
    }
}