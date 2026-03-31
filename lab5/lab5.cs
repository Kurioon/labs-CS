using System;
// Завдання 1 ст 69 вар 6

namespace OOP_Progression
{
    class ArithmeticProgression
    {
        public double a1; 
        public double d;  

        public ArithmeticProgression()
        {
            this.a1 = 0;
            this.d = 0;
        }

        public ArithmeticProgression(double a1)
        {
            this.a1 = a1;
            this.d = 0;
        }

        public ArithmeticProgression(double a1, double d) : this(a1)
        {
            this.d = d;
        }

        public void InputFirstTerm()
        {
            Console.Write("Введіть перший член прогресії (a1): ");
            a1 = double.Parse(Console.ReadLine());
        }

        public void PrintFirstTerm()
        {
            Console.WriteLine($"Перший член прогресії: {a1}");
        }

        public void InputDifference()
        {
            Console.Write("Введіть різницю прогресії (d): ");
            d = double.Parse(Console.ReadLine());
        }

        public void PrintDifference()
        {
            Console.WriteLine($"Різниця прогресії: {d}");
        }

        public double GetNthTerm(int n)
        {
            return a1 + (n - 1) * d;
        }

        public double GetSum(int n)
        {
            return ((2 * a1 + (n - 1) * d) / 2.0) * n;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ArithmeticProgression progression = new ArithmeticProgression();

            ArithmeticProgression progression1 = new ArithmeticProgression(3.0, 4.0);

            ArithmeticProgression progression2 = new ArithmeticProgression(2.0);

            ArithmeticProgression progression3 = new ArithmeticProgression() {d = -1};

            progression.InputFirstTerm();
            progression.InputDifference();

            progression.PrintFirstTerm();
            progression.PrintDifference();

            progression1.PrintFirstTerm();
            progression1.PrintDifference();

            progression2.PrintFirstTerm();
            progression2.PrintDifference();

            progression3.PrintFirstTerm();
            progression3.PrintDifference();

            Console.Write("\nВведіть номер члена прогресії для обчислень (n): ");
            int n = int.Parse(Console.ReadLine());

            if (n > 0)
            {
                Console.WriteLine($"\n{n}-й член прогресії дорівнює: {progression.GetNthTerm(n)}");
                Console.WriteLine($"Сума перших {n} членів дорівнює: {progression.GetSum(n)}");
            }
            else
            {
                Console.WriteLine("Помилка: номер n має бути натуральним числом (більшим за 0).");
            }
        }
    }
}