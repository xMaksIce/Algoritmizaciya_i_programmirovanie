HashSet<object> hashSet = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Множество");
    Console.WriteLine("1. Add - добавить значение");
    Console.WriteLine("2. Remove - удалить значение");
    Console.WriteLine("3. Contains - проверить, содержится ли элемент в множестве");
    Console.WriteLine("4. UnionWith - объединить с коллекцией");
    Console.WriteLine("5. IntersectWith - пересечь с коллекцией");
    Console.WriteLine("6. ExceptWith - исключить коллекцию");
    Console.WriteLine("7. SymmetricExceptWith - найти симметрическую разность с коллекцией");
    Console.WriteLine("8. Overlaps - проверить, есть ли общие элементы с коллекцией");
    Console.WriteLine("9. IsSubsetOf - проверить, является ли множество помножеством коллекции");
    Console.WriteLine("0. SetEquals - проверить, состоит ли множество и коллекция из одних элементов");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                hashSet.Add(obj);

                Console.WriteLine("Объект добавлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                hashSet.Remove(obj);

                Console.WriteLine("Объект удалён");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите элемент: ");
                object obj = Console.ReadLine();
                if (hashSet.Contains(obj)) Console.WriteLine("Значение содержится в множестве");
                else Console.WriteLine("Значение не содержится в множестве");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                hashSet.UnionWith(collection);
                Console.WriteLine("Элементы объединения:");
                foreach (object obj in hashSet) Console.WriteLine(obj);

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                hashSet.IntersectWith(collection);
                Console.WriteLine("Элементы пересечения:");
                foreach (object obj in hashSet) Console.WriteLine(obj);

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                hashSet.ExceptWith(collection);
                Console.WriteLine("Элементы разности:");
                foreach (object obj in hashSet) Console.WriteLine(obj);

                Console.ReadKey();
                break;
            }

        case ConsoleKey.D7:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                hashSet.SymmetricExceptWith(collection);
                Console.WriteLine("Элементы симметрической разности:");
                foreach (object obj in hashSet) Console.WriteLine(obj);

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                if (hashSet.Overlaps(collection)) Console.WriteLine("Общие элементы имеются");
                else Console.WriteLine("Общих элементов нет");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                if (hashSet.IsSubsetOf(collection)) Console.WriteLine("Множество является подмножеством коллекции");
                else Console.WriteLine("Множество не является подмножеством коллекции");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Console.Write("Введите элементы коллекции через пробел: ");
                object[] collection = Console.ReadLine().Split().ToArray();
                if (hashSet.SetEquals(collection)) Console.WriteLine("Множество и коллекция состоят из одних элементов");
                else Console.WriteLine("Множество и коллекция не состоят из одних элементов");

                Console.ReadKey();
                break;
            }
        default: break;
    }
}