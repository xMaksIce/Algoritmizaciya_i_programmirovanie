Dictionary<object, object> dict = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Словарь");
    Console.WriteLine("1. Add - добавить пару");
    Console.WriteLine("2. Item[TKey] - вернуть значение по ключу");
    Console.WriteLine("3. Item[TKey] - задать значение по ключу");
    Console.WriteLine("4. ContainsKey - проверить присутствует ли ключ в словаре");
    Console.WriteLine("5. ContainsValue - проверить присутствует ли значение в словаре");
    Console.WriteLine("6. TryAdd - попытаться добавить пару");
    Console.WriteLine("7. TryGetValue - попытаться вернуть значение");
    Console.WriteLine("8. Remove - удалить пару по ключу");
    Console.WriteLine("9. Remove - удалить пару и положить её значение в переменную");
    Console.WriteLine("0. Keys - вернуть коллекцию ключей");

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
                dict.Add(objKey, objValue);

                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.WriteLine("Значение: " + dict[objKey]);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                dict[objKey] = objValue;

                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (dict.ContainsKey(objKey)) Console.WriteLine("Ключ присутствует в словаре");
                else Console.WriteLine("Ключ отсутствует в словаре");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                if (dict.ContainsValue(objValue)) Console.WriteLine("Значение присутствует в словаре");
                else Console.WriteLine("Значение отсутствует в словаре");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                Console.Write("Введите значение: ");
                object objValue = Console.ReadLine();
                if (dict.TryAdd(objKey, objValue)) Console.WriteLine("Пара добавлена");
                else Console.WriteLine("Не удалось добавить пару");

                Console.ReadKey();
                break;
            }

        case ConsoleKey.D7:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (dict.TryGetValue(objKey, out object objValue)) Console.WriteLine("Значение равно: " + objValue);
                else Console.WriteLine("Не удалось вернуть значение");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (dict.Remove(objKey)) Console.WriteLine("Пара удалена");
                else Console.WriteLine("Не удалось удалить пару");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите ключ: ");
                object objKey = Console.ReadLine();
                if (dict.Remove(objKey, out object objValue)) Console.WriteLine("Пара удалена, значение равно: " + objValue);
                else Console.WriteLine("Не удалось удалить пару");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                object[] objFromDict = dict.Keys.ToArray();
                Console.WriteLine("Ключи:");
                foreach (object objKey in objFromDict) Console.WriteLine(objKey);

                Console.ReadKey();
                break;
            }
        default: break;
    }
}