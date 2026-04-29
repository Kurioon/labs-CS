using System;

namespace MatrixApp
{
    public abstract class TMatrix
    {
        protected double[,] _matrix;
        
        public int Size { get; protected set; } 

        public TMatrix(int size)
        {
            Size = size;
            _matrix = new double[size, size];
        }

        public double this[int i, int j]
        {
            get { return _matrix[i, j]; }
            set { _matrix[i, j] = value; }
        }

        public double GetSum()
        {
            double sum = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    sum += _matrix[i, j];
                }
            }
            return sum;
        }

        public abstract double GetDeterminant();

        public void Input()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"Введіть елемент [{i + 1},{j + 1}]: ");
                    _matrix[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Console.Write($"{_matrix[i, j],6:F1} ");
                }
                Console.WriteLine();
            }
        }
    }

    public class TMatrix2 : TMatrix
    {
        public TMatrix2() : base(2) { }

        public override double GetDeterminant()
        {
            return _matrix[0, 0] * _matrix[1, 1] - _matrix[0, 1] * _matrix[1, 0];
        }
    }

    public class TMatrix3 : TMatrix
    {
        public TMatrix3() : base(3) { }

        public override double GetDeterminant()
        {
            // Формула за правилом трикутників (Саррюса)
            return _matrix[0, 0] * _matrix[1, 1] * _matrix[2, 2] +
                   _matrix[0, 1] * _matrix[1, 2] * _matrix[2, 0] +
                   _matrix[0, 2] * _matrix[1, 0] * _matrix[2, 1] -
                   _matrix[0, 2] * _matrix[1, 1] * _matrix[2, 0] -
                   _matrix[0, 0] * _matrix[1, 2] * _matrix[2, 1] -
                   _matrix[0, 1] * _matrix[1, 0] * _matrix[2, 2];
        }
    }


    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Створення матриці A (порядок 3)");
            TMatrix matrixA = new TMatrix3();
            matrixA.Input();
            Console.WriteLine("\nМатриця A:");
            matrixA.Print();

            Console.WriteLine("\nСтворення матриці B (порядок 2)");
            TMatrix matrixB = new TMatrix2();
            matrixB.Input();
            Console.WriteLine("\nМатриця B:");
            matrixB.Print();

            double sumA = matrixA.GetSum(); 
            double detA = matrixA.GetDeterminant();
            double detB = matrixB.GetDeterminant();

            double S = sumA + detA + detB;


            Console.WriteLine($"Сума елементів матриці A: {sumA:F2}");
            Console.WriteLine($"Детермінант |A|: {detA:F2}");
            Console.WriteLine($"Детермінант |B|: {detB:F2}");
            Console.WriteLine($"S = {sumA:F2} + {detA:F2} {(detB >= 0 ? "+" : "-")} {Math.Abs(detB):F2}");
            Console.WriteLine($"S = {S:F2}");
        }
    }
}