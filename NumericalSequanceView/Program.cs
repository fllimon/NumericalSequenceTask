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
            long numberSequenceStart = long.Parse(args[0]);
            long numberSequenceFinish = long.Parse(args[1]);

            NumericalSequence sequence = new NumericalSequence(numberSequenceStart, numberSequenceFinish);

            foreach (long item in sequence)
            {
                Console.Write($"{item}, ");
            }

            Console.ReadKey();
        }
    }
}
