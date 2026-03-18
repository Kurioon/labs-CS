using System;

namespace MathFunctionApp
{
    class Program
    {
        // Завдання 1 ст 53 вар 6 
        // За даними дійсними числами a і b обчислити u = max{F(a), F(b)} - F(3).
        // F(x) x < 0 -->  1 + x + x^2/2! + ... + x^8/8!
        // F(x) 0 <= x <= 5 --> 15 + sqrt(cos^6(x))
        // F(x) x > 5 --> min{1, 2*sin(x)}


        // static void GetMax(double val1, double val2, ref double res)
        // {
        //     if (val1 > val2)
        //     {
        //          res = val1;
        //     }
        //     else
        //     {
        //         res = val2;
        //     }
        // }

        // static double GetMin(double val1, double val2)
        // {
        //     if (val1 < val2)
        //     {
        //         return val1;
        //     }
        //     else
        //     {
        //         return val2;
        //     }
        // }

        // static double F(double x)
        // {
        //     if (x < 0)
        //     {
        //         double sum = 1.0;
        //         double current = 1.0; 
                
        //         for (int i = 1; i <= 8; i++)
        //         {
        //             current *= x / i; 
        //             sum += current;
        //         }
        //         return sum;
        //     }
        //     else if (x <= 5)
        //     {
        //         return 15 + Math.Sqrt(Math.Pow(Math.Cos(x), 6));
        //     }
        //     else 
        //     {
        //         return GetMin(1, 2 * Math.Sin(x));
        //     }
        // }

        // static void Main()
        // {

        //     double test = 0;
        //     Console.Write("Input a: ");
        //     double a = double.Parse(Console.ReadLine());

            
        //     Console.Write("Input b: ");
        //     double b = double.Parse(Console.ReadLine());

        //     double f_a = F(a);
        //     double f_b = F(b);
        //     double f_3 = F(3);

        //     GetMax(f_a, f_b, ref test); 
        //     double u = test - f_3;

        //     Console.WriteLine($"F(a) = {f_a:F4}");
        //     Console.WriteLine($"F(b) = {f_b:F4}");
        //     Console.WriteLine($"F(3) = {f_3:F4}");
        //     Console.WriteLine($"u = {u:F4}");
        // }


        // Завдання 2 ст 55 вар 6 
        // Використовуючи підпрограму визначення перпендикулярності двох прямих на площині, визначити, скільки взаємно перпендикулярних пар прямих є серед вказаних n прямих: Ai x + Bi y + Ci = 0, i =1,2,...,n .

        // static bool IsPerpendicular(params double[] arr)
        // {

        //     if (arr.Length != 4)
        //     {
        //         throw new Exception("Error, arr must = 4");
        //     }

        //     return (arr[0] * arr[2] + arr[1] * arr[3]) == 0;
        // }

        // static void Main()
        // {

        //     Console.Write("Input n: ");
        //     int n = int.Parse(Console.ReadLine());

        //     if (n < 2)
        //     {
        //         Console.WriteLine("n must be >= 2.");
        //         return;
        //     }

        //     double[] A = new double[n];
        //     double[] B = new double[n];
        //     double[] C = new double[n];

        //     Console.WriteLine("\nInput coefficients");
        //     for (int i = 0; i < n; i++)
        //     {
        //         Console.WriteLine($"Line {i + 1}:");
        //         Console.Write("  A = "); A[i] = double.Parse(Console.ReadLine());
        //         Console.Write("  B = "); B[i] = double.Parse(Console.ReadLine());
        //         Console.Write("  C = "); C[i] = double.Parse(Console.ReadLine());
        //     }

        //     int perpendicularPairsCount = 0;

        //     for (int i = 0; i < n - 1; i++)
        //     {
        //         for (int j = i + 1; j < n; j++)
        //         {
        //             if (IsPerpendicular(A[i], B[i], A[j], B[j]))
        //             {
        //                 perpendicularPairsCount++;
        //             }
        //         }
        //     }

        //     Console.WriteLine($"Result: {perpendicularPairsCount}");
        // }


        // Завдання 3 ст 56 вар 6
        // Нехай x0 = 0, x1 = 9, xi = 2xi-1 + 3xi-2. Визначити xn.

        static long GetXn(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 9;

            return 2 * GetXn(n - 1) + 3 * GetXn(n - 2);
        }

        static void Main()
        {

            Console.Write("Input n: ");
            
            int n = int.Parse(Console.ReadLine());
            if (n < 0)
            {
                Console.WriteLine("Error. n must be >= 0."); 
                return;
            }
            long result = GetXn(n);
            Console.WriteLine($"Result: x{n} = {result}");
        }
    }
}