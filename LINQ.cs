// есть массив, необходимо определить сумму положительных, произведение ненулевых, колво чётных. затем изменить массив, удалить все нечётные
// выполнить те же запросы.

List<double> nums = new List<double>() {1, 2, 3, -31, 0, 0.314, -341, 0.4444 };
Requests(nums);
// выборка без нечётных
var needToDelete =
    from num in nums
    where num % 2 != 1
    select num;
foreach (double num in needToDelete.ToArray()) nums.Remove(num);
Requests(nums);
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
    double multOfNotNull = 1;
    foreach (var num in notNull) multOfNotNull *= num;
    Console.WriteLine(multOfNotNull);

    var even =
        from num in nums
        where num % 2 == 0
        select num;
    int amountOfEven = even.Count();
    Console.WriteLine(amountOfEven);

    Console.WriteLine();
}
