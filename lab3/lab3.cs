using System;

namespace lab1  
{
    class Program
    {
        static void Main()
        {


            // Завдання 1 ст 43 вар 6
            // Дано дійсне число a і натуральне число n. Обчислити a^2 * (a+1)^2 * ... * (a+n-1)^2.

            // Console.Write("Input a: ");
            // double a = double.Parse(Console.ReadLine());

            // Console.Write("Input n: ");
            // int n = int.Parse(Console.ReadLine());

            // if (n > 0)
            // {

            //     double result = 1.0;

            //     for (int i = 0; i < n; i++)
            //     {
            //         double current = a + i;
                    
            //         result *= (current * current); 
            //     }

            //     Console.WriteLine($"Result: {result}");
            // }
            // else
            // {
            //     Console.WriteLine("Error: n must be > 0.");
            // }



            // Завдання 2 ст 43 вар 6


            Console.Write("Input x (|x| < 1): ");
            double x = double.Parse(Console.ReadLine());

            if (Math.Abs(x) >= 1)
            {
                Console.WriteLine("Error: x must be in the interval (-1, 1).");
                return;
            }

            Console.Write("Input E (0.0001): ");
            double E = double.Parse(Console.ReadLine());

            if (E <= 0)
            {
                Console.WriteLine("Error: E must be > 0.");
                return;
            }

            double sum = 0.0;
            int n = 1;
            double xPow = x;
            double current;

            do
            {
                current = -xPow / n;
                sum += current;
                n++;
                xPow *= x;

            } while (Math.Abs(current) >= E);

            Console.WriteLine($"Result sum: {sum}");
            
            Console.WriteLine($"Check value: {Math.Log(1 - x)}");
            Console.WriteLine($"Sum count:  {n - 1}");
        }
    }
}