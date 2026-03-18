using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Program
    {
        static void Main()
        {

            // завд 1 ст 34 вар 6
            // Дано три дійсних числа: a, b, c. Знайти max(a,b) + (min(b,c)) ^ 2.

            // Console.WriteLine("Input a: ");    
            // double a = double.Parse(Console.ReadLine());

            // Console.WriteLine("Input b: ");    
            // double b = double.Parse(Console.ReadLine());

            // Console.WriteLine("Input c: ");    
            // double c = double.Parse(Console.ReadLine());

            // double max;
            // double min;

            // if (a < b)
            // {
            //     max = b;
            // }
            // else
            // {
            //     max = a;
            // }


            // if (c < b)
            // {
            //     min = c;
            // }
            // else
            // {
            //     min = b;
            // }

            // double res = max + Math.Pow(min, 2);
            // Console.WriteLine($"Result = {res}");



            // завд 2 вар 6 
            // y = 1 if 0 <= x < 5,
            //   = 2 if 5 <= X < 8,
            //   = 3 if X < 0, 
            //   = 4 if X >=8  

            //     short y;

            //     Console.WriteLine("Input x: ");
            //     double x = double.Parse(Console.ReadLine());
                
            //    if (x >= 0 && x < 5)
            //     {
            //         y = 1;
            //     }
            //     else if (x >= 5 && x < 8)
            //     {
            //         y = 2;
            //     }
            //     else if (x < 0)
            //     {
            //         y = 3;
            //     }
            //     else 
            //     {
            //         y = 4;
            //     }

            //     Console.WriteLine($"y = {y}");



            // завд 3 вар 6
            // Трикутник задається координатами своїх вершин на площині: A(x1, y1), B(x2, y2), C(x3, y3).
            // Визначити, чи є цей трикутник рівностороннім.


            Console.Write("A(x1): "); double x1 = double.Parse(Console.ReadLine());
            Console.Write("A(y1): "); double y1 = double.Parse(Console.ReadLine());
            
            Console.Write("B(x2): "); double x2 = double.Parse(Console.ReadLine());
            Console.Write("B(y2): "); double y2 = double.Parse(Console.ReadLine());
            
            Console.Write("C(x3): "); double x3 = double.Parse(Console.ReadLine());
            Console.Write("C(y3): "); double y3 = double.Parse(Console.ReadLine());

            double ab = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            double bc = Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
            double ca = Math.Sqrt(Math.Pow(x1 - x3, 2) + Math.Pow(y1 - y3, 2));

            Console.WriteLine($"Довжини: AB = {ab:F2}, BC = {bc:F2}, CA = {ca:F2}");

            if (ab == bc && bc == ca)
            {
                Console.WriteLine("Triangle is equilateral.");
            }
            else
            {
                Console.WriteLine("Triangle is not equilateral.");
            }
        }
    }
}
