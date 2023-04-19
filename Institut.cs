// рассматриваем организацию "Институт", несколько классов и методов, взаимодействие классов,
// объекты: основные работники, вспомогательные р., управляющий персонал, студенты.
// преподаватели имеют ФИО, предметы, которые они ведут, история работы с названиями и датами
// студенты имеют ФИО, оценки по разным дисциплинам у разных преподавателей
// управление издаёт приказы остальным трём объектам (приказ и кто выдал)
// выдать студентов, у которых есть долги (какой долг (оценка 2 или пусто), какой преподаватель)
// выдать долги по преподавателю
// выдать какие приказы были для студентов, какие приказы были для преподавателей, какие для вспомогательного, какие общие
// выдать дисциплины преподавателя
// выдать общий стаж работы преподавателя и стаж на текущем месте
// выход
// добавить тестовый ввод и стандартный
// люди имеют разные классы, но с общим наследником

List<Student> students = new();
List<Teacher> teachers = new();
List<Administration> admins = new();
List<TechnicalStaff> techStaff = new();
void MainMenu()
{
    ConsoleKeyInfo key;
    while (true)
    {
        Console.Clear();
        Console.WriteLine("Институт");
        Console.WriteLine("1. Ввод данных");
        Console.WriteLine("2. Выборка");
        Console.WriteLine("\n0. Выход");

        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.D1:
                {
                    Input(key);
                    break;
                }
            case ConsoleKey.D2:
                {
                    Selection(key);
                    break;
                }
            case ConsoleKey.D0:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
void Input(ConsoleKeyInfo key)
{
    while (key.Key != ConsoleKey.D0)
    {
        Console.Clear();
        Console.WriteLine("Ввод данных");
        Console.WriteLine("1. Ввод вручную");
        Console.WriteLine("2. Ввод для тестирования");
        Console.WriteLine("\n0. Назад");

        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.D1:
                {
                    ManualInput(key);
                    break;
                }
            case ConsoleKey.D2:
                {
                    TestInput(key);
                    break;
                }
            case ConsoleKey.D0:
                {
                    break;
                }
        }
    }
}
void ManualInput(ConsoleKeyInfo key)
{
    while (key.Key != ConsoleKey.D0)
    {
        Console.Clear();
        Console.WriteLine("Ввод данных");
        Console.WriteLine("1. Добавить студента");
        Console.WriteLine("2. Добавить преподавателя");
        Console.WriteLine("3. Добавить управляющего");
        Console.WriteLine("4. Добавить тех. работника");
        Console.WriteLine("\n0. Назад");

        key = Console.ReadKey();
        switch (key.Key)
        {
            case ConsoleKey.D1:
                {
                    Console.Clear();
                    Console.WriteLine("Добавить студента");

                    Console.Write("Введите имя студента: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) name = "Имя неизвестно";

                    students.Add(new Student(name));
                    Console.WriteLine("Студент добавлен");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D2:
                {
                    Console.Clear();
                    Console.WriteLine("Добавить преподавателя");

                    Console.Write("Введите имя преподавателя: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) name = "Имя неизвестно";

                    Console.Write("Введите число дисциплин у преподавателя: ");
                    int numSubjects = -1;
                    while (true)
                    {
                        try
                        {
                            numSubjects = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("Введите число: ");
                        }
                        if (numSubjects < 1)
                        {
                            Console.Write("Введите положительное число: ");
                        }
                        else break;
                    }
                    List<string> subjects = new(numSubjects);
                    for (int i = 0; i < numSubjects; i++)
                    {
                        Console.Write("Введите название дисциплины: ");
                        string subjectName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(subjectName)) subjectName = "Название неизвестно";
                        subjects.Add(subjectName);
                    }

                    Console.Write("Введите число мест работы преподавателя: ");
                    int numWorks = -1;
                    while (true)
                    {
                        try
                        {
                            numWorks = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.Write("Введите число: ");
                        }

                        if (numWorks < 1)
                        {
                            Console.Write("Введите положительное число: ");
                        }
                        else break;
                    }
                    List<Work> works = new(numWorks);
                    for (int i = 0; i < numWorks; i++)
                    {
                        Console.Write("Введите название места работы: ");
                        string workName = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(workName)) workName = "Название неизвестно";

                        Console.Write("Введите дату зачисления в формате (ДД.ММ.ГГГГ): ");
                        DateOnly startDate;
                        int[] startArr = new int[3];
                        while (true)
                        {
                            try
                            {
                                startArr = Console.ReadLine().Split('.').Select(Int32.Parse).ToArray();
                                startDate = new DateOnly(startArr[2], startArr[1], startArr[0]);
                                break;
                            }
                            catch
                            {
                                Console.Write("Введите дату в формате (ДД.ММ.ГГГГ): ");
                            }
                        }

                        DateOnly endDate;
                        int[] endArr = new int[3];
                        if (i == numWorks - 1)
                        {
                            Console.Write("Введите дату увольнения или нажмите Enter, чтобы пропустить: ");
                            while (true)
                            {
                                try
                                {
                                    string str = Console.ReadLine();
                                    if (str == "") 
                                    {
                                        works.Add(new(workName, startDate));
                                        break; 
                                    }
                                    endArr = str.Split('.').Select(Int32.Parse).ToArray();
                                    endDate = new DateOnly(endArr[2], endArr[1], endArr[0]);
                                }
                                catch
                                {
                                    Console.Write("Введите дату в формате (ДД.ММ.ГГГГ) или нажмите Enter: ");
                                }
                                if (startDate > endDate)
                                {
                                    Console.Write("Увольнение не может происходить раньше зачисления. Введите дату: ");
                                }
                                else
                                {
                                    works.Add(new(workName, startDate, endDate));
                                    break;
                                }

                            }
                        }
                        else
                        {
                            Console.Write("Введите дату увольнения в формате (ДД.ММ.ГГГГ): ");
                            while (true)
                            {
                                try
                                {
                                    endArr = Console.ReadLine().Split('.').Select(Int32.Parse).ToArray();
                                    endDate = new DateOnly(endArr[2], endArr[1], endArr[0]);
                                }
                                catch
                                {
                                    Console.Write("Введите дату в формате (ДД.ММ.ГГГГ): ");
                                }
                                if (startDate > endDate)
                                {
                                    Console.Write("Увольнение не может происходить раньше зачисления. Введите дату: ");
                                }
                                else 
                                {
                                    works.Add(new Work(workName, startDate, endDate));
                                    break;
                                }
                            }
                        }
                    }
                    Console.WriteLine("Преподаватель добавлен");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D3:
                {
                    Console.Clear();
                    Console.WriteLine("Добавить управляющего");

                    Console.Write("Введите имя управляющего: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) name = "Имя неизвестно";

                    admins.Add(new Administration(name));
                    Console.WriteLine("Управляющий добавлен");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D4:
                {
                    Console.Clear();
                    Console.WriteLine("Добавить технического работника");

                    Console.Write("Введите имя тех. работника: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name)) name = "Имя неизвестно";

                    techStaff.Add(new TechnicalStaff(name));
                    Console.WriteLine("Технический работник добавлен");
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D0:
                {
                    break;
                }
        }
    }
}

bool testFirstActivation = true;
void TestInput(ConsoleKeyInfo key)
{
    Console.Clear();
    if (testFirstActivation)
    {
        Console.WriteLine("Тестовые данные добавлены");
        teachers.Add(new Teacher("Виктор Петрович", new List<string>() { "Физика", "Механика", "Химия" }, new List<Work>()
    {new Work("ОбГТУ", new DateOnly(2007, 05, 12), new DateOnly(2021, 10, 30)), new Work("УгУ", new DateOnly(2021, 12, 26)) }));
        teachers.Add(new Teacher("Элеонора Альбертовна", new List<string>() { "Конструирование одежды" }, new List<Work>()
    {new Work("ОмГИС", new DateOnly(2012, 02, 02), new DateOnly(2016, 02, 16)), new Work("ОмГТУ", new DateOnly(2016, 03, 17), new DateOnly(2022, 06, 17))}));
        admins.Add(new Administration("Терентий Владимирович"));
        students.Add(new Student("Николай Сергеевич"));
        students.Add(new Student("Артём Антонович"));
        students.Add(new Student("Анжелика Валерьевна"));
        techStaff.Add(new TechnicalStaff("Зоя Павловна"));
        students[2].AddGrade(5, teachers[1], "Конструирование одежды");
        students[0].AddGrade(2, teachers[0], "Химия");
        students[0].AddGrade(3, teachers[0], "Физика");
        students[0].AddGrade(2, teachers[0], "Механика");
        students[1].AddGrade(2, teachers[0], "Химия");
        students[1].AddGrade(4, teachers[0], "Физика");
        students[1].AddGrade(4, teachers[0], "Механика");
        admins[0].AddOrder("Выходной 23.10.2022");
        admins[0].AddOrder("Организовать учебную пожарную тревогу во всех корпусах каждую пятницу чётной недели", typeof(TechnicalStaff));
        testFirstActivation = false;
    }

    Console.WriteLine("Управляющие");
    Console.WriteLine("1. Терентий Владимирович");
    Console.WriteLine("Преподаватели");
    Console.WriteLine("1. Виктор Петрович. Предметы: Физика, Химия, Механика. \nМеста работы: ОбГТУ, зачислен 12.05.2007, уволен 30.10.2021; УгУ, числится с 26.12.2021");
    Console.WriteLine("2. Элеонора Альбертовна. Предметы: Конструирование одежды. \nМеста работы: ОмГИС, зачислена 02.02.2012, уволена 16.02.2016; ОмГТУ, зачислена 16.02.2016, уволена 17.06.2022");
    Console.WriteLine("Студенты");
    Console.WriteLine("1. Николай Сергеевич");
    Console.WriteLine("2. Артём Антонович");
    Console.WriteLine("3. Анжелика Валерьевна");
    Console.WriteLine("Технический персонал");
    Console.WriteLine("1. Зоя Павловна");
    Console.WriteLine("Оценки у студентов Виктора Петровича: \r\nНиколай Сергеевич, Химия, 2\r\nНиколай Сергеевич, Физика, 3\r\nНиколай Сергеевич, Механика, 2\r\nАртём Антонович, Химия, 2\r\nАртём Антонович, Физика, 4\r\nАртём Антонович, Механика, 4");
    Console.WriteLine("Список приказов: ");
    Console.WriteLine("1. Общий: Выходной 23.10.2022");
    Console.WriteLine("2. Техническому персоналу: Организовать учебную пожарную тревогу во всех корпусах каждую пятницу чётной недели");
    Console.WriteLine("\nНажмите любую клавишу...");
    Console.ReadKey();
}
void Selection(ConsoleKeyInfo key)
{
    while (key.Key != ConsoleKey.D0)
    {
        Console.Clear();
        Console.WriteLine("Методы");
        Console.WriteLine("1. Выдать новый приказ");
        Console.WriteLine("2. Выставить оценку");
        Console.WriteLine("3. Отобразить дисциплины преподавателя");
        Console.WriteLine("4. Отобразить рабочий стаж преподавателя");
        Console.WriteLine("5. Отобразить оценки по преподавателю");
        Console.WriteLine("6. Отобразить студентов с долгами");
        Console.WriteLine("7. Отобразить список приказов");
        Console.WriteLine("\n0. Назад");

        key = Console.ReadKey();
        switch (key.Key) 
        {
            case ConsoleKey.D1:
                {
                    Console.Clear();
                    Console.WriteLine("Выдать новый приказ");
                    if (admins.Count == 0)
                    {
                        Console.WriteLine("Список управляющих пуст");
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Введите имя управляющего, выдающего приказ: ");
                    string name, text;
                    bool inputFlag = true;
                    while (inputFlag)
                    {
                        name = Console.ReadLine();
                        bool adminFound = false;
                        foreach (Administration admin in admins)
                        {
                            if (admin.Name == name)
                            {
                                adminFound = true;
                                Console.Write("Введите текст приказа: ");
                                while (true)
                                {
                                    text = Console.ReadLine();
                                    if (string.IsNullOrWhiteSpace(text))
                                    {
                                        Console.Write("Текст не должен быть пуст. Введите текст: ");
                                    }
                                    else { break; }
                                }

                                Console.WriteLine("Выберите, кому выдать приказ");
                                Console.WriteLine("1. Преподавателям");
                                Console.WriteLine("2. Студентам");
                                Console.WriteLine("3. Техническому персоналу");
                                Console.WriteLine("4. Всем");
                                bool cycleFlag = true;
                                while (cycleFlag)
                                {
                                    key = Console.ReadKey();
                                    switch (key.Key)
                                    {
                                        case ConsoleKey.D1:
                                            {
                                                admin.AddOrder(text, typeof(Teacher));
                                                cycleFlag = false;
                                                break;
                                            }
                                        case ConsoleKey.D2:
                                            {
                                                admin.AddOrder(text, typeof(Student));
                                                cycleFlag = false;
                                                break;
                                            }
                                        case ConsoleKey.D3:
                                            {
                                                admin.AddOrder(text, typeof(TechnicalStaff));
                                                cycleFlag = false;
                                                break;
                                            }
                                        case ConsoleKey.D4:
                                            {
                                                admin.AddOrder(text);
                                                cycleFlag = false;
                                                break;
                                            }
                                        default:
                                            {
                                                break;
                                            }
                                    }
                                }
                                Disappear();
                                inputFlag = false;
                                Console.WriteLine("Приказ создан");
                                Console.WriteLine("Нажмите любую клавишу...");
                                Console.ReadKey();
                            }
                            break;
                        }
                        if (!adminFound)
                        {
                            Console.Write("Управляющего с заданным именем нет, введите имя: ");
                        }
                        else break;
                    }

                    break;
                }
            case ConsoleKey.D2:
                {
                    Console.WriteLine("Выставить оценку");
                    if (teachers.Count == 0) 
                    {
                        Console.WriteLine("Список преподавателей пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    else if (students.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }

                    string teacherName, studentName, subjectName;
                    int grade = -1;
                    Console.Write("Введите имя преподавателя: ");
                    while (true)
                    {
                        bool teacherFound = false;
                        teacherName = Console.ReadLine();
                        foreach (Teacher teacher in teachers)
                        {
                            if (teacherName == teacher.Name)
                            {
                                teacherFound = true;
                                Console.Write("Введите имя студента: ");
                                while (true)
                                {
                                    studentName = Console.ReadLine();
                                    bool studentFound = false;
                                    foreach (Student student in students)
                                    {
                                        if (studentName == student.Name)
                                        {
                                            studentFound = true;
                                            Console.Write("Введите название предмета: ");
                                            while (true)
                                            {
                                                subjectName = Console.ReadLine();
                                                if (teacher.Subjects.Contains(subjectName))
                                                {
                                                    Console.WriteLine("Выберите оценку");
                                                    Console.WriteLine("1. Отлично");
                                                    Console.WriteLine("2. Хорошо");
                                                    Console.WriteLine("3. Удовлетворительно");
                                                    Console.WriteLine("4. Неудовлетворительно");
                                                    bool cycleFlag = true;
                                                    while (cycleFlag)
                                                    {
                                                        key = Console.ReadKey();
                                                        switch (key.Key)
                                                        {
                                                            case ConsoleKey.D1:
                                                                {
                                                                    grade = 5;
                                                                    cycleFlag = false;
                                                                    break;
                                                                }
                                                            case ConsoleKey.D2:
                                                                {
                                                                    grade = 4;
                                                                    cycleFlag = false;
                                                                    break;
                                                                }
                                                            case ConsoleKey.D3:
                                                                {
                                                                    grade = 3;
                                                                    cycleFlag = false;
                                                                    break;
                                                                }
                                                            case ConsoleKey.D4:
                                                                {
                                                                    grade = 2;
                                                                    cycleFlag = false;
                                                                    break;
                                                                }

                                                            default:
                                                                {
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    student.AddGrade(grade, teacher, subjectName);
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.Write("Указанного предмета не существует. Введите название: ");
                                                }
                                            }
                                        }
                                    }
                                    if (!studentFound)
                                    {
                                        Console.Write("Студента с заданным именем нет, введите имя: ");
                                    }
                                    else break;
                                }
                            }
                        }
                        if (!teacherFound)
                        {
                            Console.Write("Преподавателя с заданным именем нет, введите имя: ");
                        }
                        else break;
                    }
                    break;
                }
            case ConsoleKey.D3:
                {
                    Console.Clear();
                    Console.WriteLine("Дисциплины преподавателя");

                    if (teachers.Count == 0)
                    {
                        Console.WriteLine("Список преподавателей пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }

                    string teacherName;
                    bool teacherFound = false;
                    Console.Write("Введите имя преподавателя: ");
                    while (true)
                    {
                        teacherName = Console.ReadLine(); 
                        foreach (Teacher teacher in teachers)
                        {
                            if (teacher.Name == teacherName)
                            {
                                teacherFound = true;
                                Console.WriteLine($"Число дисциплин: {teacher.Subjects.Count}");
                                for (int i = 1; i <= teacher.Subjects.Count; i++)
                                {
                                    Console.WriteLine($"{i}. {teacher.Subjects[i-1]}");
                                }
                                Console.WriteLine("\nНажмите любую клавишу...");
                                Console.ReadKey();
                            }
                        }
                        if (!teacherFound)
                        {
                            Console.Write("Преподавателя с заданным именем нет, введите имя: ");
                        }
                        else break;
                    }
                    break;
                }
            case ConsoleKey.D4:
                {
                    Console.Clear();
                    Console.WriteLine("Рабочий стаж преподавателя");

                    if (teachers.Count == 0)
                    {
                        Console.WriteLine("Список преподавателей пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("Введите имя преподавателя: ");
                    string teacherName;
                    bool teacherFound = false;
                    while (true)
                    {
                        teacherName = Console.ReadLine();
                        foreach (Teacher teacher in teachers)
                        {
                            if (teacher.Name == teacherName)
                            {
                                teacherFound = true;
                                string tsAll = teacher.GetGeneralExperience();
                                string tsCurrent = teacher.GetCurrentExperience();
                                Console.WriteLine($"Общий стаж: {tsAll}");
                                Console.WriteLine($"Стаж на текущем месте: {tsCurrent}");
                                Console.WriteLine("\nНажмите любую клавишу...");
                                Console.ReadKey();
                            }
                        }

                        if (!teacherFound)
                        {
                            Console.Write("Преподавателя с указаным именем нет. Введите имя: ");
                        }
                        else break;
                    }
                    break;
                }
            case ConsoleKey.D5:
                {
                    Console.Clear();
                    Console.WriteLine("Оценки по преподавателю");

                    if (teachers.Count == 0)
                    {
                        Console.WriteLine("Список преподавателей пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }
                    if (students.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }

                    Console.Write("Введите имя преподавателя: ");

                    string teacherName;
                    bool gradeFound = false;
                    while (true)
                    {
                        teacherName = Console.ReadLine();
                        foreach (Student student in students)
                        {
                            foreach (Grade grade in student.Grades)
                            if (teacherName == grade.Teacher.Name)
                            {
                                Console.WriteLine($"{student.Name}, {grade.Subject}, {grade.GradeNum}");
                                gradeFound = true;
                            }
                        }
                        if (!gradeFound)
                        {
                            Console.WriteLine("Оценки не найдены");
                        }
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;

                    }
                    break;
                }
            case ConsoleKey.D6:
                {
                    Console.Clear();
                    Console.WriteLine("Студенты с долгами");
                    if (students.Count == 0)
                    {
                        Console.WriteLine("Список студентов пуст");
                        Console.WriteLine("\nНажмите любую клавишу...");
                        Console.ReadKey();
                        break;
                    }

                    bool gradeFound = false;
                    foreach(Student student in students)
                    {
                        foreach (Grade grade in student.Grades)
                        {
                            if (grade.GradeNum == 2)
                            {
                                Console.WriteLine($"Студент: {student.Name}, {grade.Subject}, преподаватель: {grade.Teacher.Name}");
                                gradeFound = true;
                            }
                        }
                    }
                    if (!gradeFound)
                    {
                        Console.WriteLine("Долгов не найдено");
                    }
                    Console.WriteLine("\nНажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            case ConsoleKey.D7:
                {
                    Console.Clear();
                    Console.WriteLine("Приказы");
                    bool orderFound = false;
                    foreach (Administration admin in admins)
                    {
                        foreach (Order order in admin.Orders)
                        {
                            Console.WriteLine($"Приказ: {order.Text}");
                            Console.Write("Назначен: ");

                            if (order.Type == typeof(Teacher))
                            {
                                Console.WriteLine("преподавателям");
                            }
                            else if (order.Type == typeof(TechnicalStaff))
                            {
                                Console.WriteLine("техническому персоналу");
                            }
                            else if (order.Type == typeof(Student))
                            {
                                Console.WriteLine("студентам");
                            }
                            else
                            {
                                Console.WriteLine("всем");
                            }
                            Console.WriteLine();
                            orderFound = true;
                        }
                    }
                    if (!orderFound)
                    {
                        Console.WriteLine("Приказов не найдено");
                    }
                    Console.WriteLine("Нажмите любую клавишу...");
                    Console.ReadKey();
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
void Disappear()
{
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(" ");
    Console.SetCursorPosition(0, Console.CursorTop);
}

MainMenu();
class Person
{
    protected string name;
    public string Name { get { return name; } }
}
class Work
{
    string name;
    public string Name { get { return name; } }
    DateOnly startDate;
    internal DateOnly StartDate { get { return startDate; }}
    DateOnly endDate = new DateOnly();
    internal DateOnly EndDate { get { return endDate; } }
    public Work(string workName, DateOnly startDate, DateOnly endDate) { name = workName; this.startDate = startDate; this.endDate = endDate; }
    public Work(string workName, DateOnly startDate) { name = workName; this.startDate = startDate; }
}
class Grade 
{
    Teacher teacher;
    public Teacher Teacher { get { return teacher; } }
    int grade;
    public int GradeNum { get { return grade; } }
    string subject;
    public string Subject { get { return subject; } }
    public Grade(int grade, Teacher teacher, string subject) { this.grade = grade; this.teacher = teacher; this.subject = subject; }
}
class Order
{
    string text;
    public string Text { get { return text; } }
    Type type;
    public Type Type { get { return type; } }
    public Order(string text, Type type) { this.text = text; this.type = type; }
    public Order(string text) { this.text = text; }
}
class Teacher : Person
{
    List<string> subjects;
    public List<string> Subjects { get { return subjects; } }
    List<Work> workHistory;
    public Teacher(string name, List<string> subjects, List<Work> workHistory) { this.name = name; this.subjects = subjects; this.workHistory = workHistory; }
    public string GetGeneralExperience()
    {
        TimeSpan timeSpan = new();
        foreach (Work work in workHistory)
        {
            if (work.EndDate != new DateOnly())
            {
                timeSpan += work.EndDate.ToDateTime(TimeOnly.MinValue).Subtract(work.StartDate.ToDateTime(TimeOnly.MinValue));
            }
            else
            {
                timeSpan += DateTime.Now.Subtract(work.StartDate.ToDateTime(TimeOnly.MinValue));
            }
        }
        string expInString = "";
        int years = 0;
        if (timeSpan.Days > 365)
        {
            years = (int) Math.Floor(timeSpan.Days / 365.25);
            expInString += years;
            if (years == 1)
            {
                 expInString += " год";
            }
            else if (years > 1 && years < 5)
            {
                expInString += " года";
            }
            else
            {
                expInString += " лет";
            }
        }
        int months = (int) ((timeSpan.Days - 365.25 * years) / 30);
        if (years > 0 && months > 0)
        {
            expInString += " ";
        }
        if (years == 0 && months == 0)
        {
            expInString += "меньше месяца";
        }
        else if (months == 1)
        {
            expInString += months + " месяц";
        }
        else if (months > 1 && months < 5)
        {
            expInString += months + " месяца";
        }
        else if (months >= 5)
        {
            expInString += months + " месяцев";
        }
        return expInString;
    }
    public string GetCurrentExperience()
    {
        Work work = workHistory.Last();
        TimeSpan timeSpan;
        if (work.EndDate != new DateOnly())
        {
            timeSpan = work.EndDate.ToDateTime(TimeOnly.MinValue).Subtract(work.StartDate.ToDateTime(TimeOnly.MinValue));
        }
        else
        {
            timeSpan = DateTime.Now.Subtract(work.StartDate.ToDateTime(TimeOnly.MinValue));
        }
        string expInString = "";
        int years = 0;
        if (timeSpan.Days > 365)
        {
            years = (int)Math.Floor(timeSpan.Days / 365.25);
            expInString += years;
            if (years == 1)
            {
                expInString += " год";
            }
            else if (years > 1 && years < 5)
            {
                expInString += " года";
            }
            else
            {
                expInString += " лет";
            }
        }
        int months = (int)((timeSpan.Days - 365.25 * years) / 30);
        if (years > 0 && months > 0)
        {
            expInString += " ";
        }
        if (years == 0 && months == 0)
        {
            expInString += "меньше месяца";
        }
        else if (months == 1)
        {
            expInString += months + " месяц";
        }
        else if (months > 1 && months < 5)
        {
            expInString += months + " месяца";
        } 
        else if (months >= 5)
        {
            expInString += months + " месяцев";
        }
        return expInString;
    }
}

class Student: Person
{
    List<Grade> grades = new();
    public List<Grade> Grades { get { return grades; } }
    public Student(string name) { this.name = name; }
    public void AddGrade(int grade, Teacher teacher, string subject)
    {
        grades.Add(new Grade(grade, teacher, subject));
    }
}
class Administration: Person
{
    List<Order> orders = new();
    public List<Order> Orders { get { return orders; }}
    public Administration(string name) { this.name = name; }
  public void AddOrder(string text, Type type)
    {
         orders.Add(new Order(text, type));
    }
    public void AddOrder(string text)
    {
        orders.Add(new Order(text));
    }
}
class TechnicalStaff: Person
{
    public TechnicalStaff(string name) { this.name = name; }
}