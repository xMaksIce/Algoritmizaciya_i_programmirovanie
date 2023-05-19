SortedList<object, object> sortedList = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Сортированный список");
    Console.WriteLine("1. Add - добавить пару");
    Console.WriteLine("2. Item[TKey] - вернуть значение по ключу");
    Console.WriteLine("3. Item[TKey] - задать значение по ключу");
    Console.WriteLine("4. ContainsKey - проверить присутствуе ключа в списке");
    Console.WriteLine("5. ContainsValue - проверить присутсвтвие значения в списке");
    Console.WriteLine("6. GetKeyAtIndex - вернуть ключ по индексу");
    Console.WriteLine("7. GetValueAtIndex - вернуть значение по индексу");
    Console.WriteLine("8. Remove - удалить пару по ключу");
    Console.WriteLine("9. RemoveAt - удалить пару по индексу");
    Console.WriteLine("0. SetValueAtIndex - обновить значение по индексу");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                sortedList.Add(objKey, objValue);

                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.WriteLine("Значение: " + sortedList[objKey]);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                sortedList[objKey] = objValue;

                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (sortedList.ContainsKey(objKey)) Console.WriteLine("Ключ присутствует в списке");
                else Console.WriteLine("Ключ отсутствует в списке");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                if (sortedList.ContainsValue(objValue)) Console.WriteLine("Значение присутствует в словаре");
                else Console.WriteLine("Значение отсутствует в словаре");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                object objKey = sortedList.GetKeyAtIndex(index);

                Console.WriteLine("Ключ элемента: " + objKey);
                Console.ReadKey();
                break;
            }

        case ConsoleKey.D7:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                object objValue = sortedList.GetValueAtIndex(index);

                Console.WriteLine("Ключ элемента: " + objValue);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (sortedList.Remove(objKey)) Console.WriteLine("Пара удалена");
                else Console.WriteLine("Не удалось удалить пару");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                sortedList.RemoveAt(index);

                Console.WriteLine("Пара удалена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Console.Write("Введите индекс: ");
                int index = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                sortedList.SetValueAtIndex(index, objValue);

                Console.WriteLine("Объект добавлен");
                Console.ReadKey();
                break;
            }
        default: break;
    }
}