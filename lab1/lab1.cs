using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1  
{
    class Program
    {
        static void Main()
        {



            // завд 1 ст  вар 6 
            // Обчислити площу та периметр квадрата, якщо задано довжину діагоналі цього квадрата.
            
            
            Console.WriteLine("Enter diagonal: ");
            double diagonal = double.Parse(Console.ReadLine());
            
            if (diagonal > 0)
            {

                double s = Math.Pow(diagonal, 2) / 2;
                double p = 2 * diagonal * Math.Sqrt(2);

                Console.WriteLine($"S = {s}, P = {p}");
            }
            else
            {
                Console.WriteLine("Error: diagonal must be > 0.");
            }
        }
    }

}