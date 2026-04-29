using System;

namespace InterfacesTask
{
    public class Rational
    {
        public int Numerator { get; private set; }
        public int Denominator { get; private set; }

        public Rational(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменник не може дорівнювати нулю.");
            
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        private void Simplify()
        {
            int gcd = GetGCD(Math.Abs(Numerator), Math.Abs(Denominator));
            Numerator /= gcd;
            Denominator /= gcd;
            
            if (Denominator < 0)
            {
                Numerator = -Numerator;
                Denominator = -Denominator;
            }
        }

        private int GetGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            if (Denominator == 1) return Numerator.ToString();
            return $"{Numerator}/{Denominator}";
        }
    }

    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override string ToString()
        {
            string sign = Imaginary >= 0 ? "+" : "-";
            return $"{Real} {sign} {Math.Abs(Imaginary)}i";
        }
    }

    public interface IRationalOperations
    {
        Rational Add(Rational a, Rational b);
        Rational Subtract(Rational a, Rational b);
        Rational Multiply(Rational a, Rational b);
        Rational Divide(Rational a, Rational b);
    }

    public interface IComplexOperations
    {
        ComplexNumber Add(ComplexNumber a, ComplexNumber b);
        ComplexNumber Subtract(ComplexNumber a, ComplexNumber b);
        ComplexNumber Multiply(ComplexNumber a, ComplexNumber b);
        ComplexNumber Divide(ComplexNumber a, ComplexNumber b);
    }


    public class UniversalCalculator : IRationalOperations, IComplexOperations
    {

        public Rational Add(Rational a, Rational b)
        {
            int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            int den = a.Denominator * b.Denominator;
            return new Rational(num, den);
        }

        public Rational Subtract(Rational a, Rational b)
        {
            int num = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            int den = a.Denominator * b.Denominator;
            return new Rational(num, den);
        }

        public Rational Multiply(Rational a, Rational b)
        {
            return new Rational(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public Rational Divide(Rational a, Rational b)
        {
            if (b.Numerator == 0) throw new DivideByZeroException("Ділення на нуль.");
            return new Rational(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public ComplexNumber Add(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public ComplexNumber Subtract(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
        {
            double real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            double imag = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new ComplexNumber(real, imag);
        }

        public ComplexNumber Divide(ComplexNumber a, ComplexNumber b)
        {
            double denominator = b.Real * b.Real + b.Imaginary * b.Imaginary;
            if (denominator == 0) throw new DivideByZeroException("Ділення на нуль.");

            double real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / denominator;
            double imag = (a.Imaginary * b.Real - a.Real * b.Imaginary) / denominator;
            return new ComplexNumber(real, imag);
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            UniversalCalculator calc = new UniversalCalculator();

            Console.WriteLine("Раціональні дроби");
            Rational r1 = new Rational(1, 2);
            Rational r2 = new Rational(1, 3); 

            Console.WriteLine($"Дріб 1: {r1}");
            Console.WriteLine($"Дріб 2: {r2}");
            Console.WriteLine($"Додавання: {calc.Add(r1, r2)}");
            Console.WriteLine($"Віднімання: {calc.Subtract(r1, r2)}");
            Console.WriteLine($"Множення: {calc.Multiply(r1, r2)}");
            Console.WriteLine($"Ділення: {calc.Divide(r1, r2)}");

            Console.WriteLine("\nКомплексні числа");
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(1, -1);

            Console.WriteLine($"Число 1: {c1}");
            Console.WriteLine($"Число 2: {c2}");
            Console.WriteLine($"Додавання: {calc.Add(c1, c2)}");
            Console.WriteLine($"Віднімання: {calc.Subtract(c1, c2)}");
            Console.WriteLine($"Множення: {calc.Multiply(c1, c2)}");
            Console.WriteLine($"Ділення: {calc.Divide(c1, c2)}");
        }
    }
}