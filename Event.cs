// реализовать автоматическое управление списком вызовов обработчиков событий (event) (+-*/)

MyEvent evt = new MyEvent();
evt.eventCalculator += Plus;
evt.eventCalculator += Minus;
evt.eventCalculator += Multiply;
evt.eventCalculator += Divide;
evt.StartEvent(3, 8);

void Plus(double left, double right) => Console.WriteLine($"Сумма: {left + right}");
void Minus(double left, double right) => Console.WriteLine($"Разность: {left - right}");
void Multiply(double left, double right) => Console.WriteLine($"Произведение: {left * right}");
void Divide(double left, double right)
{
    if (right == 0)
    {
        Console.WriteLine($"Частное: {double.NaN}");
    }
    Console.WriteLine($"Частное: {left / right}");
};

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
