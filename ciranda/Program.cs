using System;

namespace ciranda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a character: ");
            //read the number
            int num = int.Parse(Console.ReadLine());
            
            //check if is divisible by 3
            if (num % 3 == 0)
            {
                //check if the number contains 5
                if (num.ToString().Contains("5"))
                {
                    Console.WriteLine("CiraDinha");
                }
                else
                {
                    Console.WriteLine("Cira");
                }
            }
            //if the number is not divisible by 3, then check if contains 5
            if (num.ToString().Contains("5"))
            {
                Console.WriteLine("Dinha");
            }
        }
    }
}
