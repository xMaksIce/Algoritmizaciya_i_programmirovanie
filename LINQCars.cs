// два класса: 1. Описание машин(номер машины (id), цвет, марка); 2. id машины, владелец;

List<Car> cars = new() { new Car(123, "Чёрный", "Lexus"), new Car(420, "Белый", "Chevrolet"), 
                                 new Car(222, "Лиловый", "Chevrolet"), new Car(324, "Чёрный", "Toyota")};
List<CarToOwner> carsToOwners = new() {new CarToOwner(123, "Ленни"), new CarToOwner(420, "Артур"),
                                       new CarToOwner(222, "Мика"), new CarToOwner(324, "Ленни")};

Console.Write("Введите марку машины (Lexus, Chevrolet, Toyota): ");
string? pickedMark = Console.ReadLine();
var carByMark = from car in cars
                where car.Mark == pickedMark
                select car;
foreach (var car in carByMark) Console.WriteLine($"ID машины: {car.ID}");

Console.WriteLine("Машины владельцев");
var owners = from car in carsToOwners
                 group car by car.OwnerName;
foreach (var owner in owners)
{
    Console.WriteLine(owner.Key);
    foreach(var car in owner)
    {
        Console.WriteLine($"ID машины: {car.ID}");
    }
}
class Car 
{ 
    public int ID { get; set; }
    public string Color { get; set; }
    public string Mark { get; set; }
    public Car(int id, string color, string mark) {ID = id; Color = color; Mark = mark; }
}
class CarToOwner
{
    public int ID { get; set; }
    public string OwnerName { get; set; }
    public CarToOwner(int id, string ownerName) { ID = id; OwnerName = ownerName; }   
}
