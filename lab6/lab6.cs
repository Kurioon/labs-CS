using System;

namespace OOP_Circle
{
    class TCircle
    {
        // === ПОЛЯ ТА ВЛАСТИВОСТІ ===
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = Math.Max(0, value); } // Захист: радіус не може бути від'ємним
        }

        // === КОНСТРУКТОРИ ===
        
        // 1. Конструктор без параметрів (за замовчуванням)
        public TCircle()
        {
            Radius = 0;
        }

        // 2. Конструктор з параметрами
        public TCircle(double r)
        {
            Radius = r;
        }

        // 3. Конструктор копіювання (створює нове коло на основі існуючого)
        public TCircle(TCircle otherCircle)
        {
            Radius = otherCircle.Radius;
        }

        // === МЕТОДИ ===

        // Введення даних
        public void InputData()
        {
            Console.Write("Введіть радіус кола: ");
            Radius = double.Parse(Console.ReadLine());
        }

        // Виведення даних
        public void PrintData()
        {
            Console.WriteLine($"Коло з радіусом: {Radius:F2}");
        }

        // Визначення площі круга
        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        // Визначення довжини кола
        public double GetCircumference()
        {
            return 2 * Math.PI * Radius;
        }

        // Порівняння з іншим колом
        public void CompareWith(TCircle other)
        {
            if (this.Radius > other.Radius)
                Console.WriteLine("Поточне коло БІЛЬШЕ за передане.");
            else if (this.Radius < other.Radius)
                Console.WriteLine("Поточне коло МЕНШЕ за передане.");
            else
                Console.WriteLine("Кола ОДНАКОВІ.");
        }

        // === ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ===

        // Перевантаження додавання (+)
        public static TCircle operator +(TCircle c1, TCircle c2)
        {
            return new TCircle(c1.Radius + c2.Radius);
        }

        // Перевантаження віднімання (-)
        public static TCircle operator -(TCircle c1, TCircle c2)
        {
            // Якщо c2 більше за c1, захист у властивості Radius перетворить мінус на нуль
            return new TCircle(c1.Radius - c2.Radius); 
        }

        // Перевантаження множення на число (*)
        public static TCircle operator *(TCircle c, double multiplier)
        {
            return new TCircle(c.Radius * multiplier);
        }

        // Дзеркальне множення (щоб можна було писати не тільки circle * 2, а й 2 * circle)
        public static TCircle operator *(double multiplier, TCircle c)
        {
            return new TCircle(c.Radius * multiplier);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- Створення об'єктів ---");
            TCircle circle1 = new TCircle(5.0); // Конструктор з параметрами
            Console.Write("Коло 1: "); circle1.PrintData();

            TCircle circle2 = new TCircle(); // Конструктор без параметрів
            Console.Write("Введення Кола 2. ");
            circle2.InputData();

            TCircle circle3 = new TCircle(circle1); // Конструктор копіювання
            Console.Write("Коло 3 (копія Кола 1): "); circle3.PrintData();

            Console.WriteLine("\n--- Тестування методів (для Кола 1) ---");
            Console.WriteLine($"Площа: {circle1.GetArea():F2}");
            Console.WriteLine($"Довжина: {circle1.GetCircumference():F2}");
            
            Console.Write("Порівняння Кола 1 та Кола 2: ");
            circle1.CompareWith(circle2);

            Console.WriteLine("\n--- Тестування ПЕРЕВАНТАЖЕННЯ ОПЕРАТОРІВ ---");
            
            TCircle sumCircle = circle1 + circle2;
            Console.Write("Додавання (Коло 1 + Коло 2): "); sumCircle.PrintData();

            TCircle diffCircle = circle1 - circle2;
            Console.Write("Віднімання (Коло 1 - Коло 2): "); diffCircle.PrintData();

            TCircle multCircle = circle1 * 3;
            Console.Write("Множення (Коло 1 * 3): "); multCircle.PrintData();
        }
    }
}