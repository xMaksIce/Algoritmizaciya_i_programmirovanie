// есть массив, необходимо определить сумму положительных, произведение ненулевых, колво чётных. затем изменить массив, удалить все нечётные
// выполнить те же запросы.

double[] firstNums = {1, 2, 3, -31, 0, 0.314, -341, 0.4444 };
Requests(firstNums);
// выборка без нечётных
var secondNums =
    from num in firstNums
    where num % 2 != 1
    select num;
Requests(secondNums);
void Requests(IEnumerable<double> nums)
{
    var Positives =
    from num in nums
    where num > 0
    select num;
    double sumOfPositives = 0;
    foreach (var num in Positives) sumOfPositives += num;
    Console.WriteLine(sumOfPositives);

    var notNull =
        from num in nums
        where num != 0
        select num;
    double multOfNotNull = 0;
    foreach (var num in notNull) multOfNotNull += num;
    Console.WriteLine(multOfNotNull);

    var even =
        from num in nums
        where num % 2 == 0
        select num;
    int amountOfEven = 0;
    foreach (var num in even) amountOfEven++;
    Console.WriteLine(amountOfEven);

    Console.WriteLine();
}