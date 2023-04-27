Garage myGarage = new(2);
myGarage.Add(new Car("McQueen", 69));
myGarage.Add(new Car("Zuzhik", 30));
CarWash larrysWash = new();
larrysWash.DoWash(myGarage);

class Car
{
    string name;
    public string Name { get { return name; } }
    int speed;
    public Car(string name, int speed) { this.name = name; this.speed = speed; }
}
class Garage
{
    List<Car> garage;
    public Garage() { }
    public Garage(int capacity) { garage = new(capacity); }

    public void Add(Car car)
    {
        garage.Add(car);
    }
    public void Remove(Car car)
    {
        garage.Remove(car);
    }
    public void Enumeration(Action<Car> action)
    {
        foreach (Car car in garage)
        {
            action(car);
        }
    }
}
class CarWash
{
    public void DoWash(Garage garage)
    {
        garage.Enumeration((Car car) => Console.WriteLine($"Машина {car.Name} помыта"));
    }
}
