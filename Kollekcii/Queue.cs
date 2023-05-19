Queue<object> queue = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Очередь");
    Console.WriteLine("1. Enqueue - добавить элемент в конец");
    Console.WriteLine("2. Dequeue - удалить и вернуть элемент из начала");
    Console.WriteLine("3. Peek - вернуть элемент из начала без удаления");
    Console.WriteLine("4. TryDequeue - попытаться удалить и вернуть элемент из начала");
    Console.WriteLine("5. TryPeek - попытаться вернуть элемент из начала без удаления");
    Console.WriteLine("6. Count - вернуть число элементов");
    Console.WriteLine("7. Clear - очистить очередь");
    Console.WriteLine("8. Contains - проверить, содержится ли элемент в очереди");
    Console.WriteLine("9. EnsureCapacity - увеличить ёмкость очереди");
    Console.WriteLine("0. TrimExcess - установить ёмкость равной числу элементов(если их меньше 90% от ёмкости)");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                queue.Enqueue(obj);

                Console.WriteLine("Объект добавлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                object obj = queue.Dequeue();

                Console.WriteLine(obj);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                object obj = queue.Peek();

                Console.WriteLine(obj);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                queue.TryDequeue(out object obj);

                Console.WriteLine(obj);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                queue.TryPeek(out object obj);

                Console.WriteLine(obj);
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                int count = queue.Count();

                Console.WriteLine("Число элементов равно " + count);
                Console.ReadKey();
                break;
            }

        case ConsoleKey.D7:
            {
                queue.Clear();

                Console.WriteLine("Очередь очищена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                bool contains = queue.Contains(obj);

                if (contains) Console.WriteLine("Объект находится в очереди");
                else Console.WriteLine("Объект не находится в очереди");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите число: ");
                int capacity = Convert.ToInt32(Console.ReadLine());
                int ensured = queue.EnsureCapacity(capacity);
                Console.WriteLine($"Ёмкость очереди: {ensured}");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                queue.TrimExcess();

                Console.WriteLine("Ёмкость изменена");
                Console.ReadKey();
                break;
            }
        default: break;
    }
}