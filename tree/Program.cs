using System;

namespace tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j, count = 1;
            for (j = 1; j <= 5; j++)
            {
                for (i = 1; i <= count; i++)
                    Console.Write(" ");
                count++;
                for (i = 1; i <=  (6 - j); i++)
                    Console.Write("* ");
            Console.WriteLine();
            }
        }
    }
}
