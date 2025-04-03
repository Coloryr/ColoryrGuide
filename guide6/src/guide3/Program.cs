namespace guide3;

class Car
{
    public int X;  //表示长
    public int Y;  //表示宽
    public int Z;  //表示高

    public Car()
    {
        Console.WriteLine("X is:" + X);
        Console.WriteLine("Y is:" + Y);
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var car = new Car()
        {
            X = 1,
            Y = 2
        };
    }
}
