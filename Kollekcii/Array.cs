ConsoleKeyInfo key;
Console.Write("Введите длину массива: ");
int length = Convert.ToInt32(Console.ReadLine());
Array arr = Array.CreateInstance(typeof(object), length);
Console.WriteLine("Введите построчно элементы");
for (int i = 0; i < length; i++)
{
    arr.SetValue(Console.ReadLine(), i);
}

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Length - длина");
    Console.WriteLine("2. Rank - размерность");
    Console.WriteLine("3. BinarySearch - бинарный поиск");
    Console.WriteLine("4. Clear - очистка");
    Console.WriteLine("5. Reverse - переворот");
    Console.WriteLine("6. IndexOf - индекс первого вхождения");
    Console.WriteLine("7. LastIndexOf - индекс последнего вхождения");
    Console.WriteLine("8. Sort - сортировка");
    Console.WriteLine("9. SetValue - задать значение");
    Console.WriteLine("0. Выход");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.WriteLine($"Длина массива равна {arr.Length}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.WriteLine($"Размерность массива равна {arr.Rank}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите элемент для поиска: ");
                int result = Array.BinarySearch(arr, Console.ReadLine());
                Console.WriteLine($"Индекс элемента: {result}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Array.Clear(arr);
                Console.WriteLine("Массив очищен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Array.Reverse(arr);
                Console.WriteLine("Массив перевёрнут");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите элемент: ");
                int result = Array.IndexOf(arr, Console.ReadLine());
                Console.WriteLine("Индекс первого вхождения элемента: " + result);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D7:
            {
                Console.Write("Введите элемент: ");
                int result = Array.LastIndexOf(arr, Console.ReadLine());
                Console.WriteLine("Индекс последнего вхождения элемента: " + result);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Array.Sort(arr);
                Console.WriteLine("Массив отсортирован");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите элемент: ");
                object str = Console.ReadLine();
                arr.SetValue(str, index);
                Console.WriteLine("Значение установлено");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Environment.Exit(0);
                break;
            }

    }
}

