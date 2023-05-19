List<object> list = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Список");
    Console.WriteLine("1. Add - добавить значение");
    Console.WriteLine("2. Item[Int32] - вернуть значение");
    Console.WriteLine("3. Item[Int32] - задать значение");
    Console.WriteLine("4. Contains - проверить присутствует ли значение");
    Console.WriteLine("5. Sort - отсортировать список");
    Console.WriteLine("6. BinarySearch - выполнить поиск в отсортированном списке");
    Console.WriteLine("7. Reverse - обратить порядок элементов");
    Console.WriteLine("8. Remove - удалить первое вхождения элемента");
    Console.WriteLine("9. RemoveAt - удалить значение по индексу");
    Console.WriteLine("0. Insert - вставить значение по индексу");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                list.Add(obj);

                Console.WriteLine("Объект добавлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                object obj = list[index];
                Console.WriteLine("Значение равно: " + obj);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                list[index] = obj;

                Console.WriteLine("Объект добавлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                if (list.Contains(obj)) Console.WriteLine("Значение содержится в списке");
                else Console.WriteLine("Значение не содержится в списке");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                list.Sort();

                Console.WriteLine("Список отсортирован");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                int index = list.BinarySearch(obj);
                if (index != -1) Console.WriteLine("Индекс элемента: " + index);
                else Console.WriteLine("Элемент найти не удалось");

                Console.ReadKey();
                break;
            }
            
        case ConsoleKey.D7:
            {
                list.Reverse();

                Console.WriteLine("Список перевёрнут");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                if (list.Remove(obj)) Console.WriteLine("Элемент удалён");
                else Console.WriteLine("Элемент не удалось удалить");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                list.RemoveAt(index);

                Console.WriteLine("Элемент удалён");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                list.Insert(index, obj);

                Console.WriteLine("Элемент вставлен в список");
                Console.ReadKey();
                break;
            }
        default: break;
    }
}