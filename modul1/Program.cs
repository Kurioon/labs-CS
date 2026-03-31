using System;

namespace modul1
{
    // Варіант 12 Петріченко Олександр

    // Інтерфейс для знаходження х
    public interface IxFinder
    {
        void FindAndPrintX();
    }

    class Polynomial
    {
        protected double[] a = new double[5];

        public virtual void InputCoefficients()
        {
            Console.WriteLine("Введіть коефіцієнти многочлена 4-го степеня (a4*x^4 + ... + a0):");
            for (int i = 4; i >= 0; i--)
            {
                Console.Write($"  a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine());
            }
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Многочлен: {a[4]}*x^4 + {a[3]}*x^3 + {a[2]}*x^2 + {a[1]}*x + {a[0]}");
        }

        public virtual double Calculate(double x)
        {
            double result = 0;
            for (int i = 0; i <= 4; i++)
            {
                result += a[i] * Math.Pow(x, i);
            }
            return result;
        }
    }

    class LinearFunction : Polynomial, IxFinder
    {
        public override void InputCoefficients()
        {
            Console.WriteLine("Введіть коефіцієнти лінійної функції (a1*x + a0):");
            for (int i = 1; i >= 0; i--)
            {
                Console.Write($"  a[{i}] = ");
                a[i] = double.Parse(Console.ReadLine());
            }
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Лінійна функція: {a[1]}*x + {a[0]}");
        }

        public override double Calculate(double x)
        {
            return a[1] * x + a[0]; 
        }

        public void FindAndPrintX()
        {
            if (a[1] == 0)
            {
                if (a[0] == 0)
                    Console.WriteLine("Корінь: x - будь-яке число (0 = 0).");
                else
                    Console.WriteLine("Рівняння не має коренів (паралельно осі x).");
            }
            else
            {
                double x = -a[0] / a[1];
                Console.WriteLine($"Корінь лінійного рівняння ({a[1]}*x + {a[0]} = 0): x = {x:F2}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Polynomial poly = new Polynomial();
            poly.InputCoefficients();
            Console.WriteLine("\nРезультат вводу:");
            poly.PrintCoefficients();

            LinearFunction linear = new LinearFunction();
            linear.InputCoefficients();
            Console.WriteLine("\nРезультат вводу:");
            linear.PrintCoefficients();

            Console.Write("Введіть значення точки x: ");
            
            double targetX = double.Parse(Console.ReadLine());

            Console.WriteLine($"Значення многочлена у точці {targetX}: {poly.Calculate(targetX)}");
            Console.WriteLine($"Значення лінійної функції у точці {targetX}: {linear.Calculate(targetX)}");

            
            IxFinder xFinder = linear; 
            xFinder.FindAndPrintX();
        }
    }
}