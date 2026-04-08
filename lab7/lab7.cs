// using System;

// // Завдання 1 ст83 вар6
// public class TBankomat
// {
//     private int _count5;
//     private int _count10;
//     private int _count20;
//     private int _count50;
//     private int _count100;
//     private int _count200;

//     public int Count5 
//     { 
//         get { return _count5; } 
//         private set { _count5 = Math.Max(0, value); } 
//     }
//     public int Count10 
//     { 
//         get { return _count10; } 
//         private set { _count10 = Math.Max(0, value); } 
//     }
//     public int Count20 
//     { 
//         get { return _count20; } 
//         private set { _count20 = Math.Max(0, value); } 
//     }
//     public int Count50 
//     { 
//         get { return _count50; } 
//         private set { _count50 = Math.Max(0, value); } 
//     }
//     public int Count100 
//     { 
//         get { return _count100; } 
//         private set { _count100 = Math.Max(0, value); } 
//     }
//     public int Count200 
//     { 
//         get { return _count200; } 
//         private set { _count200 = Math.Max(0, value); } 
//     }

//     public TBankomat(int count5, int count10, int count20, int count50, int count100, int count200)
//     {
//         Count5 = count5;
//         Count10 = count10;
//         Count20 = count20;
//         Count50 = count50;
//         Count100 = count100;
//         Count200 = count200;
//     }

//     public int GetMaxSum()
//     {
//         return (Count5 * 5) + (Count10 * 10) + (Count20 * 20) + 
//                (Count50 * 50) + (Count100 * 100) + (Count200 * 200);
//     }

//     public int GetMinSum()
//     {
//         if (Count5 > 0) return 5;
//         if (Count10 > 0) return 10;
//         if (Count20 > 0) return 20;
//         if (Count50 > 0) return 50;
//         if (Count100 > 0) return 100;
//         if (Count200 > 0) return 200;
        
//         return 0; 
//     }

//     public bool getMoney(int amount)
//     {
//         if (amount <= 0 || amount % 5 != 0 || amount > GetMaxSum())
//         {
//             return false;
//         }

//         int remaining = amount;
        
//         int take200 = Math.Min(remaining / 200, Count200);
//         remaining -= take200 * 200;

//         int take100 = Math.Min(remaining / 100, Count100);
//         remaining -= take100 * 100;

//         int take50 = Math.Min(remaining / 50, Count50);
//         remaining -= take50 * 50;

//         int take20 = Math.Min(remaining / 20, Count20);
//         remaining -= take20 * 20;

//         int take10 = Math.Min(remaining / 10, Count10);
//         remaining -= take10 * 10;

//         int take5 = Math.Min(remaining / 5, Count5);
//         remaining -= take5 * 5;

//         if (remaining == 0)
//         {
//             Count200 -= take200;
//             Count100 -= take100;
//             Count50 -= take50;
//             Count20 -= take20;
//             Count10 -= take10;
//             Count5 -= take5;
//             return true;
//         }

//         return false;
//     }

//     public override string ToString()
//     {
//         return $"Залишок купюр: [5 грн: {Count5}], [10 грн: {Count10}], [20 грн: {Count20}], " +
//                $"[50 грн: {Count50}], [100 грн: {Count100}], [200 грн: {Count200}].\n" +
//                $"Доступна сума: {GetMaxSum()} грн";
//     }
// }

// class ProgramBankomat
// {
//     static void Main()
//     {
//         Console.OutputEncoding = System.Text.Encoding.UTF8;

//         TBankomat atm = new TBankomat(10, 5, 10, 5, 2, 5); 

//         Console.WriteLine(atm.ToString());
//         Console.WriteLine($"Мінімальна доступна сума: {atm.GetMinSum()} грн\n");

//         int sumTogetMoney = 465;
//         Console.WriteLine($"Спроба зняти {sumTogetMoney} грн");
        
//         if (atm.getMoney(sumTogetMoney))
//         {
//             Console.WriteLine("Операція успішна.\n");
//         }
//         else
//         {
//             Console.WriteLine("Помилка: неможливо видати дану суму (недостатньо коштів або немає потрібних купюр).\n");
//         }

//         Console.WriteLine("Стан банкомату після операції");
//         Console.WriteLine(atm.ToString());
//     }
// }


// Завдання 2 ст85 вар6
using System;

public class Triangle
{
    private double _xa;
    private double _ya;
    private double _xb;
    private double _yb;
    private double _xc;
    private double _yc;

    public double Xa 
    { 
        get { return _xa; } 
        set { _xa = value; } 
    }
    public double Ya 
    { 
        get { return _ya; } 
        set { _ya = value; } 
    }
    
    public double Xb 
    { 
        get { return _xb; } 
        set { _xb = value; } 
    }
    public double Yb 
    { 
        get { return _yb; } 
        set { _yb = value; } 
    }
    
    public double Xc 
    { 
        get { return _xc; } 
        set { _xc = value; } 
    }
    public double Yc 
    { 
        get { return _yc; } 
        set { _yc = value; } 
    }

    public Triangle() { }

    public Triangle(double xa, double ya, double xb, double yb, double xc, double yc)
    {
        Xa = xa;
        Ya = ya;
        Xb = xb;
        Yb = yb;
        Xc = xc;
        Yc = yc;
    }

    public double this[char side]
    {
        get
        {
            switch (char.ToLower(side))
            {
                case 'a': 
                    return Math.Sqrt(Math.Pow(Xc - Xb, 2) + Math.Pow(Yc - Yb, 2)); 
                
                case 'b': 
                    return Math.Sqrt(Math.Pow(Xc - Xa, 2) + Math.Pow(Yc - Ya, 2)); 
                
                case 'c': 
                    return Math.Sqrt(Math.Pow(Xb - Xa, 2) + Math.Pow(Yb - Ya, 2)); 
                
                default: 
                    throw new ArgumentException("Недопустимий індекс. Використовуйте 'a', 'b' або 'c'.");
            }
        }
    }

    public void Input()
    {
        try
        {
            Console.Write("Введіть Xa (Вершина A): ");
            Xa = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть Ya (Вершина A): ");
            Ya = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть Xb (Вершина B): ");
            Xb = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть Yb (Вершина B): ");
            Yb = Convert.ToDouble(Console.ReadLine());

            Console.Write("Введіть Xc (Вершина C): ");
            Xc = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть Yc (Вершина C): ");
            Yc = Convert.ToDouble(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Помилка: введено некоректне число.");
        }
    }

    public void Output()
    {
        Console.WriteLine($"\nВершини: A({Xa}, {Ya}), B({Xb}, {Yb}), C({Xc}, {Yc})");
        Console.WriteLine($"Сторони: a = {this['a']:F2}, b = {this['b']:F2}, c = {this['c']:F2}");
    }

    public double GetPerimeter()
    {
        return this['a'] + this['b'] + this['c'];
    }

    public double GetArea()
    {
        double a = this['a'];
        double b = this['b'];
        double c = this['c'];

        if (a + b <= c || a + c <= b || b + c <= a)
        {
            Console.WriteLine("Трикутник із такими координатами не існує.");
            return 0;
        }

        double p = GetPerimeter() / 2.0;
        return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
}

class ProgramTriangle
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        Triangle triangle = new Triangle();
        
        // (0,0) (0,3) (4,0)
        // (1,1) (2,2) (3,3)

        triangle.Input();
        triangle.Output();
        
        Console.WriteLine($"\nПериметр: {triangle.GetPerimeter():F2}");
        Console.WriteLine($"Площа: {triangle.GetArea():F2}");
    }
}