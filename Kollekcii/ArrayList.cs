using System.Collections;

ArrayList arrayList = new();
ConsoleKeyInfo key;

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Add - добавить элемент в конец");
    Console.WriteLine("2. AddRange - добавить коллекцию в конец");
    Console.WriteLine("3. Remove - удалить первое вхождение элемента");
    Console.WriteLine("4. RemoveAt - удалить элемент по индексу");
    Console.WriteLine("5. RemoveRange - удалить диапазон элементов");
    Console.WriteLine("6. Insert - вставить элемент по индексу");
    Console.WriteLine("7. InsertRange - вставить коллекцию по индексу");
    Console.WriteLine("8. Contains - определить входит ли элемент");
    Console.WriteLine("9. Capacity - задать вместимость");
    Console.WriteLine("0. IndexOf - вернуть индекс элемента");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите элемент: ");
                arrayList.Add(Console.ReadLine());
                Console.WriteLine("Элемент добавлен в конец ArrayList");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите через пробел список элементов: ");
                arrayList.AddRange(Console.ReadLine().Split().ToArray());
                Console.WriteLine("Элементы добавлены в конец ArrayList");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите элемент: ");
                arrayList.Remove(Console.ReadLine());
                Console.WriteLine("Элемент удалён, если он вообще был");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите индекс: ");
                arrayList.RemoveAt(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Элемент удалён");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Console.Write("Введите индекс первого удаляемого элемента: ");
                int startIndex = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите количество удаляемых элементов: ");
                arrayList.RemoveRange(startIndex, Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Элементы удалены");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                Console.Write("Введите индекс: ");
                arrayList.Insert(Convert.ToInt32(Console.ReadLine()), obj);
                Console.WriteLine("Элемент вставлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D7:
            {
                Console.Write("Введите через пробел список элементов: ");
                Array array = Console.ReadLine().Split().ToArray();
                Console.Write("Введите индекс: ");
                arrayList.InsertRange(Convert.ToInt32(Console.ReadLine()), array);
                Console.WriteLine("Элементы добавлены в конец ArrayList");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите элемент: ");
                if (arrayList.Contains(Console.ReadLine())) Console.WriteLine("Элемент содержится в ArrayList");
                else Console.WriteLine("Элемент не содержится в коллекции");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите вместимость: ");
                arrayList.Capacity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Вместимость ArrayList теперь равна {arrayList.Capacity}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Console.Write("Введите элемент: ");
                Console.WriteLine($"Индекс элемента: {arrayList.IndexOf(Console.ReadLine())}");
                Console.ReadKey();
                break;
            }

    }
}
