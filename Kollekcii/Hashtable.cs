using System.Collections;

ConsoleKeyInfo key;
Hashtable hashtable = new();
while (true)
{
    Console.Clear();
    Console.WriteLine("1. Add - добавить элемент с ключом и значением");
    Console.WriteLine("2. ContainsKey - определить, содержится ли ключ");
    Console.WriteLine("3. ContainsValue - определить, содержится ли значение");
    Console.WriteLine("4. Contains - определить, содержится ли ключ");
    Console.WriteLine("5. Remove - удалить элемент с указанным ключом");
    Console.WriteLine("6. Item[Object] - вернуть значение по ключу");
    Console.WriteLine("7. Item[Object] - задать значение по ключу");
    Console.WriteLine("8. Keys - вернуть коллекцию ключей");
    Console.WriteLine("9. Values - вернуть коллекцию значений");
    Console.WriteLine("0. Count - вернуть число пар ключ-значение");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                Console.Write("Введите значение: ");
                object value = Console.ReadLine();
                hashtable.Add(klyuch, value);
                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                if (hashtable.ContainsKey(klyuch)) Console.WriteLine("Ключ содержится в Hashtable");
                else Console.WriteLine("Ключ не содержится в Hashtable");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                Console.Write("Введите значение: ");
                object value = Console.ReadLine();
                if (hashtable.ContainsKey(value)) Console.WriteLine("Значение содержится в Hashtable");
                else Console.WriteLine("Значение не содержится в Hashtable");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                if (hashtable.Contains(klyuch)) Console.WriteLine("Ключ содержится в Hashtable");
                else Console.WriteLine("Ключ не содержится в Hashtable");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                hashtable.Remove(klyuch);
                Console.WriteLine("Элемент удалён");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                Console.WriteLine($"Значение: {hashtable[klyuch]}");
                Console.ReadKey();
                break;

            }
        case ConsoleKey.D7:
            {
                Console.Write("Введите ключ: ");
                object klyuch = Console.ReadLine();
                Console.Write("Введите значение: ");
                object value = Console.ReadLine();
                hashtable[klyuch] = value;
                Console.WriteLine("Пара добавлена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                Console.WriteLine($"Ключи:");
                foreach (object klyuch in hashtable.Keys) Console.WriteLine($"{klyuch}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                Console.WriteLine($"Значения:");
                foreach (object value in hashtable.Values) Console.WriteLine($"{value}");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                Console.WriteLine($"Число пар ключ-значение: {hashtable.Count}");
                Console.ReadKey();
                break;
            }
    }
}

