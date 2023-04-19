// описать класс и реализовать методы, позволяющие работать с данными следующий струкруры: (фио автора, название произв., id, год издания, имя издательства, жанр) 
// поле, которое будет отображать дату выдачи книги и дату сдачи книги (список или массив)
// реализовать заполнение, все выборки делать только после заполнения(отслеживать информацию, что база пустая)
// выборки по издательству, автору, книги на руках, книги, которые в определённый интервал были на руках и по жанру
// меню из выборок + выход.

//int[,] status = { { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}, { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 } };
//Book Pepega = new Book("Автор", "Книга", 228, 1337, "Издательство", "Жанр", status);

List<Book> Bookshelf = new();

void Menu()
{
    do
    {
        Console.Clear();
        Console.WriteLine("Меню библиотеки");
        Console.WriteLine("1. Добавить книгу");
        Console.WriteLine("2. Выборки среди книг");
        Console.WriteLine("3. Выход");
        Console.WriteLine("\n0. Добавить книги для тестирования");
        ConsoleKeyInfo key = new('0', ConsoleKey.D0, false, false, false);
        while (key.Key != ConsoleKey.D3)
        {
            key = Console.ReadKey();
            Disappear();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    {
                        AddBook();
                        key = new('3', ConsoleKey.D3, false, false, false);
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        if (Bookshelf.Count > 0) Selection();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Библиотека пуста");
                            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                            key = new('3', ConsoleKey.D3, false, false, false);
                            Console.ReadKey();
                            break;
                        }
                        key = new('3', ConsoleKey.D3, false, false, false);
                        break;
                    }
                case ConsoleKey.D3:
                    {
                        Environment.Exit(0);
                        break;
                    }
                case ConsoleKey.D0:
                    {
                        Bookshelf.Add(new Book("Карл Маркс", "Капитал", 3743, 1867, "Н.Ф. Даниельсон", "Трактат", new List<DateOnly>[2] { new List<DateOnly> { new DateOnly(1905, 06, 12), new DateOnly(1906, 09, 23) }, new List<DateOnly> { new DateOnly(1906, 09, 11), new DateOnly(1907, 10, 12) } })) ;
                        Bookshelf.Add(new Book("Антуан де Сент-Экзюпери", "Маленький принц", 2286245, 2021, "Эксмо", "Сказка", new List<DateOnly>[2] { new List<DateOnly> { new DateOnly(2022, 01, 23), new DateOnly(2022, 12, 19)}, new List<DateOnly> { new DateOnly(2022, 09, 01) } }));
                        Console.WriteLine("Книги добавлены:");
                        new Book("Карл Маркс", "Капитал", 3743, 1867, "Н.Ф. Даниельсон", "Трактат", new List<DateOnly>[2] { new List<DateOnly> { new DateOnly(1905, 06, 12), new DateOnly(1906, 09, 23) }, new List<DateOnly> { new DateOnly(1906, 09, 11), new DateOnly(1907, 10, 12) } }).Print();
                        new Book("Антуан де Сент-Экзюпери", "Маленький принц", 2286245, 2021, "Эксмо", "Сказка", new List<DateOnly>[2] { new List<DateOnly> { new DateOnly(2022, 01, 23), new DateOnly(2022, 12, 19) }, new List<DateOnly> { new DateOnly(2022, 09, 01) } }).Print();
    break;
                    }
                default: break;
            }
        }

        void AddBook()
        {
            string author = "Не указано";
            string bookname = "Не указано";
            int id = 0;
            int publicationyear = 0;
            string publname = "Не указано";
            string genre = " Не указано";
            List<DateOnly>[] status = new List<DateOnly>[2];
            status[0] = new List<DateOnly>();
            status[1] = new List<DateOnly>();
            Console.Clear();
            Console.WriteLine("Добавить книгу");
            Console.WriteLine("1. Ввести имя автора");
            Console.WriteLine("2. Ввести название книги");
            Console.WriteLine("3. Ввести ID книги");
            Console.WriteLine("4. Ввести год издания");
            Console.WriteLine("5. Ввести название издательства");
            Console.WriteLine("6. Ввести жанр");
            Console.WriteLine("7. Добавить дату выдачи");
            Console.WriteLine("8. Добавить дату сдачи");
            Console.WriteLine("9. Сохранить книгу и выйти в меню");
            Console.WriteLine("0. Выход");
            
            key = new('0', ConsoleKey.D0, false, false, false);
            while (key.Key != ConsoleKey.D9)
            {
                key = Console.ReadKey();
                Disappear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            Console.Write("Введите имя автора: ");
                            author = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Write("Введите название книги: ");
                            bookname = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.Write("Введите ID книги: ");
                            id = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.Write("Введите год издания: ");
                            publicationyear = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Write("Введите название издательства: ");
                            publname = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D6:
                        {
                            Console.Write("Введите жанр: ");
                            genre = Console.ReadLine();
                            break;
                        }
                    case ConsoleKey.D7:
                        {
                            Console.Write("Введите год выдачи: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите месяц: ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите день: ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            DateOnly inBible = new (year, month, day);
                            status[0].Add(inBible);
                            break;
                        }
                    case ConsoleKey.D8:
                        {
                            Console.Write("Введите год сдачи: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите месяц: ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите день: ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            DateOnly outBible = new (year, month, day);
                            status[1].Add(outBible);
                            break;
                        }
                    case ConsoleKey.D9:
                        {
                            Bookshelf.Add(new Book(author, bookname, id, publicationyear, publname, genre, status));
                            break;
                        }
                    case ConsoleKey.D0:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default: break;
                }
            }
        }

        void Selection()
        {
            Console.Clear();
            Console.WriteLine("Выборки");
            Console.WriteLine("1. По автору");
            Console.WriteLine("2. По издательству");
            Console.WriteLine("3. По жанру");
            Console.WriteLine("4. Выданные книги");
            Console.WriteLine("5. Выданные книги в определённом периоде");
            Console.WriteLine("6. В меню");
            Console.WriteLine("7. Выход");
            key = new('0', ConsoleKey.D0, false, false, false);
            while (key.Key != ConsoleKey.D6)
            {
                key = Console.ReadKey();
                Disappear();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        {
                            bool flag = false;
                            Console.Write("Введите имя автора: ");
                            string name = Console.ReadLine();
                            for (int i = 0; i < Bookshelf.Count; i++)
                            {
                                if (name == Bookshelf[i].Author)
                                {
                                    Bookshelf[i].Print();
                                    flag = true;
                                }
                            }
                            if (flag == false) Console.WriteLine("Книг по заданным параметрам не найдено");
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            bool flag = false;
                            Console.Write("Введите имя издательства: ");
                            string name = Console.ReadLine();
                            for (int i = 0; i < Bookshelf.Count; i++)
                            {
                                if (name == Bookshelf[i].PublName)
                                {
                                    Bookshelf[i].Print();
                                    flag = true;
                                }
                            }
                            if (flag == false) Console.WriteLine("Книг по заданным параметрам не найдено");
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            bool flag = false;
                            Console.Write("Введите название жанра: ");
                            string name = Console.ReadLine();
                            for (int i = 0; i < Bookshelf.Count; i++)
                            {
                                if (name == Bookshelf[i].Genre)
                                {
                                    Bookshelf[i].Print();
                                    flag = true;
                                }
                            }
                            if (flag == false) Console.WriteLine("Книг по заданным параметрам не найдено");
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            bool flag = false;
                            for (int i = 0; i < Bookshelf.Count; i++)
                            {
                                if (Bookshelf[i].Status[0].Last() > Bookshelf[i].Status[1].Last())
                                {
                                    Bookshelf[i].Print();
                                    flag = true;
                                }
                                if (flag == false) Console.WriteLine("Книг по заданным параметрам не найдено");
                            }
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Write("Введите год начала периода: ");
                            int year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите месяц: ");
                            int month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите день: ");
                            int day = Convert.ToInt32(Console.ReadLine());
                            DateOnly startDate = new(year, month, day);
                            Console.Write("Введите год конца периода: ");
                            year = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите месяц: ");
                            month = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Введите день: ");
                            day = Convert.ToInt32(Console.ReadLine());
                            DateOnly endDate = new(year, month, day);
                            bool flag = false;
                            for (int i = 0; i < Bookshelf.Count; i++)
                            {
                                bool statusFlag = false;
                                for (int j = 0; j < Bookshelf[i].Status[1].Count; j++)
                                {
                                    if (startDate < Bookshelf[i].Status[0][j] && Bookshelf[i].Status[0][j] < endDate || startDate < Bookshelf[i].Status[1][j] && Bookshelf[i].Status[1][j] < endDate) statusFlag = true;

                                }
                                if (Bookshelf[i].Status[1].Count != Bookshelf[i].Status[0].Count) if (startDate < Bookshelf[i].Status[0].Last() && Bookshelf[i].Status[0].Last() < endDate) statusFlag = true;
                                if (statusFlag == true) Bookshelf[i].Print();
                                flag = true;
                            }
                            if (flag == false) Console.WriteLine("Книг по заданным параметрам не найдено");
                            break;
                        }
                    case ConsoleKey.D6: break;
                    case ConsoleKey.D7:
                        {
                            Environment.Exit(0);
                            break;
                        }
                    default: break;
                }
            }
        }
        void Disappear()
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ");
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
    while (true);
}
Menu();
public class Book
{
    string author;
    string bookname;
    int id;
    int publicationyear;
    string publname;
    string genre;
    List<DateOnly>[] status = new List<DateOnly>[2];
    public Book(string author, string bookname, int id, int publicationyear, string publname, string genre, List<DateOnly>[] status) { this.author = author; this.bookname = bookname; this.id = id; this.publicationyear = publicationyear; this.publname = publname; this.genre = genre; this.status = status; }
    public void Print()
    {
        Console.WriteLine($"Название: {bookname}, автор: {author}, ID: {id}, год публикации: {publicationyear}, жанр: {genre}, издательство: {publname}");
        Console.Write("Даты выдач: ");
        for (int i = 0; i < status[0].Count; i++) Console.Write($"{status[0][i]} ");
        Console.WriteLine();
        Console.Write("Даты сдач: ");
        for (int i = 0; i < status[1].Count; i++) Console.Write($"{status[1][i]} ");
        Console.WriteLine();
    }
    public string Author
    {
        get
        {
            return author;
        }

    }
    public string Bookname
    {
        get
        {
            return bookname;
        }

    }
    public string PublName
    {
        get
        {
            return publname;
        }
    }
    public int ID
    {
        get
        {
            return id;
        }

    }
    public int PublicationYear
    {
        get
        {
            return publicationyear;
        }

    }
    public string Genre
    {
        get
        {
            return Genre;
        }
    }
    public List<DateOnly>[] Status
    {
        get
        {
            return status;
        }
    }
}



