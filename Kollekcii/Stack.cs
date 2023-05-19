using Microsoft.VisualBasic;

Stack<object> stack = new();
ConsoleKeyInfo key;
while (true)
{
    Console.Clear();
    Console.WriteLine("Стэк");
    Console.WriteLine("1. Push - вставить элемент наверх стэка");
    Console.WriteLine("2. Peek - вернуть элемент без удаления");
    Console.WriteLine("3. TryPeek - попытаться вернуть элемент без удаления");
    Console.WriteLine("4. Pop - вернуть элемент с удалением");
    Console.WriteLine("5. TryPop - попытаться вернуть элемент с удалением");
    Console.WriteLine("6. Contains - проверить присутствие элемента в стэке");
    Console.WriteLine("7. EnsureCapacity - увеличить ёмкость стэка");
    Console.WriteLine("8. TrimExcess - установить ёмкость равной числу элементов(если их меньше 90% от ёмкости)");
    Console.WriteLine("9. Count - вернуть число элементов в стэке");
    Console.WriteLine("0. Задача со скобками");

    key = Console.ReadKey();
    Console.Clear();
    switch (key.Key)
    {
        case ConsoleKey.D1:
            {
                Console.Write("Введите элемент: ");
                stack.Push(Console.ReadLine());

                Console.WriteLine("Элемент добавлен");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D2:
            {
                object obj = stack.Peek();
                Console.WriteLine($"Взят объект {obj}");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D3:
            {
                if (stack.TryPeek(out object obj)) Console.WriteLine($"Взят объект {obj}");
                else Console.WriteLine("Стэк пуст");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D4:
            {
                object obj = stack.Pop();
                Console.WriteLine($"Изъят объект {obj}");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D5:
            {
                if (stack.TryPop(out object obj)) Console.WriteLine($"Изъят объект {obj}");
                else Console.WriteLine("Стэк пуст");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D6:
            {
                Console.Write("Введите элемент: ");
                if (stack.Contains(Console.ReadLine())) Console.WriteLine("Элемент содержится в стэке");
                else Console.WriteLine("Элемент не содержится в стэке");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D7:
            {
                Console.Write("Введите число: ");
                int capacity = Convert.ToInt32(Console.ReadLine());
                int ensured = stack.EnsureCapacity(capacity);
                Console.WriteLine($"Ёмкость стэка: {ensured}");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D8:
            {
                stack.TrimExcess();

                Console.WriteLine("Ёмкость изменена");
                Console.ReadKey();
                break;
            }
        case ConsoleKey.D9:
            {
                int count = stack.Count;
                Console.WriteLine($"Число элементов: {count}");

                Console.ReadKey();
                break;
            }
        case ConsoleKey.D0:
            {
                bool correctBrackets = true;
                Dictionary<char, char> openClose = new(3);
                openClose['('] = ')';
                openClose['['] = ']';
                openClose['{'] = '}';
                Stack<char> brackets = new();
                int closed = 0;
                int openned = 0;
                Console.Write("Введите строку: ");
                string str = Console.ReadLine();
                foreach(char symb in str)
                {
                    if (openClose.Keys.Contains(symb))
                    {
                        brackets.Push(openClose[symb]);
                        openned++;
                    }
                    else if (openClose.Values.Contains(symb))
                    {
                        closed++;
                        if (brackets.Count == 0 || brackets.Peek() != symb)
                        {
                            correctBrackets = false;
                            break;
                        }
                        brackets.Pop();
                    }
                }
                if (closed != openned) correctBrackets = false;
                if (correctBrackets) Console.WriteLine("Скобки расставлены верно");
                else Console.WriteLine("Скобки расставлены некорректно");

                Console.ReadKey();
                break;
            }
        default: break;
    }
} 