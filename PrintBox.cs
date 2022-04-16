using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    internal static class PrintBox
    {
        private static int leftPos = 0;
        private static int topPos = 0;
        
        private static int lengthOfLastPrime = Program.primes
                                                .LastOrDefault()
                                                .ToString()
                                                .Length;

        private static int lengthOfDivisorList = Program.divisorList[Convert.ToInt32(Program.antiPrime)].Count;

        public static void PrintPrimes(int cols)
        {
            // Box breaks when going less than 5 cols.

            Write($"\nTable of prime numbers.\n");

            Write("┌"); Write(new string('─', lengthOfLastPrime * cols + cols)); Write("┐");
            for (int i = 0; i < Program.primes.Count; i++)
            {
                if (i % cols == 0)
                {
                    if (i != 0)
                    {
                        Write("│");
                    }

                    Write("\n│");
                }

                Write($"{Program.primes[i]} {new string(' ', lengthOfLastPrime - Program.primes[i].ToString().Length)}");
            }

            if ((Program.primes.Count) % cols != 0)
            {
                Write($"{new string(' ', (cols - (Program.primes.Count % cols)) * (1 + lengthOfLastPrime))}");
            }

            Write("│\n└"); Write(new string('─', lengthOfLastPrime * cols + cols)); Write("┘");
        }

        public static void PrintDivisors(int cols)
        {
            Write($"\n{Program.antiPrime} is the highest antiprime in the interval, and it has {Program.highestDivisorAmount + 1} divisors.\n");

            Write("┌"); Write(new string('─', lengthOfLastPrime * cols + cols)); Write("┐");

            int i = 0;

            foreach (ulong divisor in Program.divisorList[Convert.ToInt32(Program.antiPrime)])
            {
                if (i % cols == 0)
                {
                    if (i != 0)
                    {
                        Write("│");
                    }

                    Write("\n│");
                }

                Write($"{divisor} {new string(' ', lengthOfLastPrime - divisor.ToString().Length)}");

                i++;
            }

            Write($"{Program.antiPrime} ");

            if ((lengthOfDivisorList + 1) % cols != 0)
            {
                Write($"{new string(' ', (cols - ((lengthOfDivisorList + 1) % cols)) * (1 + Program.antiPrime.ToString().Length))}");
            }

            Write("│\n└"); Write(new string('─', lengthOfLastPrime * cols + cols)); Write("┘\n\n");
        }
    }
}
