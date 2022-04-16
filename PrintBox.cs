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

        public static void PrintPrimes()
        {
            Write($"Table of prime numbers.\n");

            int lengthOfLastPrime = Program.primes
                                    .LastOrDefault()
                                    .ToString()
                                    .Length;

            Write("┌"); Write(new string('─', lengthOfLastPrime * 20 + 20)); Write("┐");
            for (int i = 0; i < Program.primes.Count; i++)
            {
                if (i % 20 == 0)
                {
                    if (i != 0)
                    {
                        Write("│");
                    }

                    Write("\n│");
                }

                Write($"{Program.primes[i]} {new string(' ', lengthOfLastPrime - Program.primes[i].ToString().Length)}");
            }

            Write($"{new string(' ', (20 - (Program.primes.Count % 20)) * (1 + lengthOfLastPrime))}");

            Write("│\n└"); Write(new string('─', lengthOfLastPrime * 20 + 20)); Write("┘");
        }

        public static void PrintDivisors()
        {
            Write($"\n{Program.antiPrime} is the highest antiprime in the interval, and it has {Program.highestDivisorAmount + 1} divisors.");

            foreach (ulong divisor in Program.divisorList[Convert.ToInt32(Program.antiPrime)])
            {
                Write($" {divisor}");
            }

            Write($" {Program.antiPrime}.\n ");
        }

        public static void PrintLoadSequence()
        {
            Console.SetCursorPosition(leftPos, topPos);
            Write(@"/");

            Console.SetCursorPosition(leftPos, topPos);
            Write(@"-");

            Console.SetCursorPosition(leftPos, topPos);
            Write(@"\");

            Console.SetCursorPosition(leftPos, topPos);
            Write(@"|");
        }
    }
}
