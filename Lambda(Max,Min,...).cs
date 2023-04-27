// с использованием делегата реализовать лямбда-выражение минимального, максимального, суммы, произведения и ср. арифметического трёх чисел
// один делегат со всеми методами
Action<double, double, double> operations = (a, b, c) => Console.WriteLine("Минимальное: " + Math.Min(Math.Min(a, b), c));
operations += (a, b, c) => Console.WriteLine("Максимальное: " + Math.Max(Math.Max(a, b), c));
operations += (a, b, c) => Console.WriteLine("Сумма: " + (a + b + c));
operations += (a, b, c) => Console.WriteLine("Произведение: " + a * b * c);
operations += (a, b, c) => Console.WriteLine("Среднее арифметическое: " + (a + b + c) / 3);

operations(3, 4, 5);