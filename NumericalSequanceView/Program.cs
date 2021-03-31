using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NumericalSequenceLib;

namespace NumericalSequanceView
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberSequence = long.Parse(args[0]);

            NumericalSequence sequence = new NumericalSequence(numberSequence);

            Console.WriteLine($"Заданное число: {sequence.NumberSequence}");
            Console.WriteLine();

            foreach (long item in sequence.GetSequence())
            {
                Console.Write($"{item}, ");
            }

            Console.ReadKey();
        }
    }
}
