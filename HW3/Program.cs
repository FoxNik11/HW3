using System.Data;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a * x^2 + b * x + c = 0");
            Console.WriteLine("Введите значение a:");
            var a = Console.ReadLine();
            int pa;
            Parss(a, out pa);
            Console.WriteLine("Введите значение b:");
            var b = Console.ReadLine();
            int pb;
            Parss(b, out pb);
            Console.WriteLine("Введите значение c:");
            var c = Console.ReadLine();
            int pc;
            Parss(c, out pc);
            var D = Descr(pa, pb, pc);
            if (D > 0)
            {
                var x1 = (-pb + Math.Sqrt(D)) / (2 * pa);
                var x2 = (-pb - Math.Sqrt(D)) / (2 * pa);

                Console.WriteLine($"x1: {x1}, x2: {x2}");
            }
            else if (D < 0)
            {
                throw new NoRoots("Корней нет!");
            }
            else if (D == 0)
            {
                var x1 = (-pb + Math.Sqrt(D)) / (2 * pa);
            }
            void Parss(string aa, out int numbers)
            {
                bool result = int.TryParse(aa, out int number);
                numbers = number;
                    if (result == true)
                    {
                        Console.WriteLine($"Преобразование прошло успешно. Число: {number}");
                    }
                    else
                    {
                        Console.WriteLine("Введено неверное значение. Введите повторно целое число: ");
                        aa = Console.ReadLine();
                        Parss(aa, out int number1);
                        numbers = number1;
                    }
            }
        }
            enum Severity
        {
            Warning,
            Error
        }
        
        static int Descr(int a1, int b1, int c1)
        {
            var D = b1 * b1 - 4 * a1 * c1;
            Console.WriteLine($"дескременант равен: {D}");
            return D;
        }
    }
}

public class NoRoots : Exception
{
    public NoRoots() { }
    public NoRoots(string message) : base(message)
    {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Корней нет!");
        Console.ResetColor();
    }
    public NoRoots(string message, Exception inner) : base(message, inner) { }

}


public class RootsTwo : Exception
{
    public RootsTwo() { }
    public RootsTwo(string message) : base(message)
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.WriteLine("Корней нет!");
        Console.ResetColor();
    }
    public RootsTwo(string message, Exception inner) : base(message, inner) { }

}