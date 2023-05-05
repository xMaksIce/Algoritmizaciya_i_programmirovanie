// реализовать автоматическое управление списком вызовов обработчиков событий (event) (+-*/)

MyEvent evt = new MyEvent();
evt.eventCalculator += IMath.Plus;
evt.eventCalculator += IMath.Minus;
evt.eventCalculator += IMath.Multiply;
evt.eventCalculator += IMath.Divide;
evt.StartEvent(3, 8);

class MyEvent
{
    public event Action<double, double> eventCalculator;
    public void StartEvent(int left, int right)
    {
        if (eventCalculator != null)
        {
            eventCalculator(left, right);
        }
    }
}
interface IMath
{
    public static void Plus(double left, double right)
    {
        Console.WriteLine($"Сумма: {left + right}");
    }
    public static void Minus(double left, double right)
    {
        Console.WriteLine($"Разность: {left - right}");
    }
    public static void Multiply(double left, double right)
    {
        Console.WriteLine($"Произведение: {left * right}");
    }
    public static void Divide(double left, double right)
    {
        if (right == 0)
        {
            Console.WriteLine($"Частное: {double.NaN}");
        }
        Console.WriteLine($"Частное: {left / right}");
    }
}