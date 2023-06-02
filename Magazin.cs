// три таблицы (id продукта, наименование), (id произв, наим. произв.), (id товара, id производителя, дата, кол-во)
// группировка по дате ()
// группировка по товару (товар, кто поставлял)
// группировка по производителю ()

Dictionary<int, string> products = new()
{
    [1] = "Молоко",
    [2] = "Сыр",
    [3] = "Колбаса",
    [4] = "Хлеб",
    [5] = "Яблоки",
    [6] = "Бананы"
};
Dictionary<int, string> manufacturers = new()
{
    [1] = "Молочное производство",
    [2] = "Мясокомбинат",
    [3] = "Хлебная мануфактура",
    [4] = "Фруктляндия"
};
List<Supply> supplies = new()
{
    new Supply(1, 1, new DateOnly(2022, 12, 12), 12),
    new Supply(2, 1, new DateOnly(2022, 12, 15), 6),
    new Supply(3, 2, new DateOnly(2022, 12, 13), 10),
    new Supply(4, 3, new DateOnly(2022, 12, 12), 24),
    new Supply(5, 4, new DateOnly(2022, 12, 5), 100),
    new Supply(6, 4, new DateOnly(2022, 12, 13), 24),
    new Supply(1, 1, new DateOnly(2022, 12, 18), 22),
    new Supply(3, 2, new DateOnly(2022, 12, 31), 11),
};

var byDate = from supply in supplies
             group supply by supply.Date;
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("ПО ДАТЕ");
Console.WriteLine("---------------------------------------------------------------------------");
foreach (var date in byDate)
{
    Console.WriteLine(date.Key);
    foreach (var supply in date)
    {
        Console.WriteLine($"Товар: {products[supply.ProductID]}, Производитель: {manufacturers[supply.ManufID]}, Кол-во: {supply.Amount}");
    }
    Console.WriteLine();
}
var byProduct = from supply in supplies
                group supply by supply.ProductID;
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("ПО ТОВАРУ");
Console.WriteLine("---------------------------------------------------------------------------");
foreach (var product in byProduct)
{
    Console.WriteLine(products[product.Key]);
    foreach (var supply in product)
    {
        Console.WriteLine($"Производитель: {manufacturers[supply.ManufID]}, Кол-во: {supply.Amount}, Дата: {supply.Date}");
    }
    Console.WriteLine();
}
var byManufacturer = from supply in supplies
                     group supply by supply.ManufID;
Console.WriteLine("---------------------------------------------------------------------------");
Console.WriteLine("ПО ПРОИЗВОДИТЕЛЮ");
Console.WriteLine("---------------------------------------------------------------------------");
foreach (var manufacturer in byManufacturer)
{
    Console.WriteLine(manufacturers[manufacturer.Key]);
    foreach (var supply in manufacturer)
    {
        Console.WriteLine($"Товар: {products[supply.ProductID]}, Кол-во: {supply.Amount}, Дата: {supply.Date}");
    }
    Console.WriteLine();
}
/*
var owners = from car in carsToOwners
             group car by car.OwnerName;
foreach (var owner in owners)
{
    Console.WriteLine(owner.Key);
    foreach (var car in owner)
    {
        Console.WriteLine($"ID машины: {car.ID}");
    }
}*/
class Supply
{
    public int ProductID { get; set; }
    public int ManufID { get; set; }
    public DateOnly Date { get; set; }
    public int Amount { get; set; }
    public Supply(int productID, int manufacturerID, DateOnly date, int amount) 
    { ProductID = productID; ManufID = manufacturerID; Date = date; Amount = amount;}
}