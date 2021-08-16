using System;

namespace CSharpQ
{
    /// 1.	Program that prints from 1 to 100    
    ///     Conditions: 
    ///     for multiples of three prints "Fizz"
    ///     for multiples of five prints "Buzz"
    ///     for multiples of both three and five prints "FizzBuzz"


    /// Class
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                    Console.WriteLine(i);
            }

        }
    }
}

    
