Massiv<string> mass = new Massiv<string>(5);
mass.Set("aboba", 0);

Console.WriteLine(mass.Get(0));
mass.Remove(0);

Console.WriteLine(mass.Get(0));

Massiv<int> massiv2 = new Massiv<int>(2);
massiv2.Set(12435, 0);
massiv2.Set(-134, 1);
massiv2.Print();
massiv2.Remove(0);
massiv2.Print();

class Massiv<T>
{
    T[] ar;
    
    public Massiv(int length) 
    { 
        this.ar = new T[length];
    }
    public void Set (T el, int index)
    {
        ar[index] = el;
    }
    public T Get(int index)
    {
        return ar[index];
    }
    public void Remove(int index)
    {
        ar[index] = default(T);
    }
    public void Print()
    {
        foreach(T el in ar)
        {
            Console.Write(el + " ");
        }
        Console.WriteLine();
    }
}
