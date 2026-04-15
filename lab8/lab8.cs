using System;

// Завдання 1 ст 92 вар 6
namespace OOP_Circle
{
    class TCircle
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius; 
            }

            set
            { 
                radius = Math.Max(0, value); 
            } 
        }

        public TCircle()
        {
            Radius = 0;
        }

        public TCircle(double r)
        {
            Radius = r;
        }

        public TCircle(TCircle otherCircle)
        {
            Radius = otherCircle.Radius;
        }

        public virtual void InputData()
        {
            Console.Write("Введіть радіус кола: ");
            Radius = double.Parse(Console.ReadLine());
        }

        public void PrintData()
        {
            Console.WriteLine($"Коло з радіусом: {Radius:F2}");
        }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double GetLength()
        {
            return 2 * Math.PI * Radius;
        }

        public void CompareWith(TCircle other)
        {
            if (this.Radius > other.Radius)
                Console.WriteLine("Поточне коло БІЛЬШЕ за передане.");
            else if (this.Radius < other.Radius)
                Console.WriteLine("Поточне коло МЕНШЕ за передане.");
            else
                Console.WriteLine("Кола ОДНАКОВІ.");
        }

        public static bool operator ==(TCircle c1, TCircle c2)
        {
            return c1.radius == c2.radius;
        }

        public static bool operator !=(TCircle c1, TCircle c2)
        {
            return !(c1.radius == c2.radius);
        }

        public static TCircle operator +(TCircle c1, TCircle c2)
        {
            return new TCircle(c1.Radius + c2.Radius);
        }

        public static TCircle operator -(TCircle c1, TCircle c2)
        {
            return new TCircle(c1.Radius - c2.Radius); 
        }

        public static TCircle operator *(TCircle c, double multiplier)
        {
            return new TCircle(c.Radius * multiplier);
        }

        public static TCircle operator *(double multiplier, TCircle c)
        {
            return new TCircle(c.Radius * multiplier);
        }
    }

    class TCylinder : TCircle
    {
        private double height;

        public double Height
        {
            get
            {
                return height; 
            }

            set
            {
                height = Math.Max(0, value);
            }
        }

        public TCylinder() : base()
        {
            Height = 0;
        }

        public TCylinder(double r, double h) : base(r)
        {
            Height = h;
        }

        public TCylinder(TCylinder otherCylinder) : base(otherCylinder)
        {
            Height = otherCylinder.Height;
        }

        public override void InputData()
        {
            base.InputData();
            Console.Write("Введіть висоту циліндра: ");
            Height = double.Parse(Console.ReadLine());
        }

        public new void PrintData()
        {
            base.PrintData();
            Console.WriteLine($"Циліндр з радіусом основи: {Radius:F2} та висотою: {Height:F2}");
        }

        public double GetVolume()
        {
            return GetArea() * Height;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TCircle circle1 = new TCircle(5.0); 
            Console.WriteLine("Коло 1: "); 
            circle1.PrintData();

            TCircle circle2 = new TCircle(); 
            Console.WriteLine("Введення Кола 2. ");
            circle2.InputData();

            TCircle circle3 = new TCircle(circle1); 
            Console.WriteLine("Коло 3 (копія Кола 1): "); 
            circle3.PrintData();

            Console.WriteLine($"Площа: {circle1.GetArea():F2}");
            Console.WriteLine($"Довжина: {circle1.GetLength():F2}");
            
            Console.WriteLine("Порівняння Кола 1 та Кола 2: ");
            circle1.CompareWith(circle2);

            TCircle sumCircle = circle1 + circle2;
            Console.WriteLine("Додавання (Коло 1 + Коло 2): ");
            sumCircle.PrintData();

            TCircle diffCircle = circle1 - circle2;
            Console.WriteLine("Віднімання (Коло 1 - Коло 2): ");
            diffCircle.PrintData();

            TCircle multCircle = circle1 * 3;
            Console.WriteLine("Множення (Коло 1 * 3): "); multCircle.PrintData();

            bool isEqual = circle1 == circle2;
            Console.WriteLine($"Чи рівні Коло 1 та Коло 2: {isEqual}");

            Console.WriteLine("\nTCylinder");
            TCylinder cylinder = new TCylinder();
            
            cylinder.InputData();
            cylinder.PrintData();
            
            Console.WriteLine($"Об'єм циліндра: {cylinder.GetVolume():F2}");
            Console.WriteLine($"Площа основи циліндра: {cylinder.GetArea():F2}");
        }
    }
}