/*
 Created by Durim Miziraj @2022-03-12 as a passtime.

 A prime is a number that only divides by itself and 1.
 In this program it is defined as a number that leaves zero remainders only
 once when divided by numbers including itself and all numbers smaller
 than itself.

 The number that has the highest occurences of remainders in the set interval
 is an anti-prime. An anti-prime is a number that can be divided by the most
 amount of divisors.

 This program takes a number as a command line argument, and prints out all
 primes and the largest antiprime beginning from 1 to the number that is specified.
 It also stores the divisors of every number up to the specified number,
 it prints out the divisors of the largest anti prime.
 The largest number allowed is 18'446'744'073'709'551'615,
 this is set by the storage capacity of the 'ulong' type
*/

using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace PrimeNumbers
{

    // TODO: Set up a async load symbol.

    class Program
    {

        private static int leftPos = 0;
        private static int topPos = 0;

        public static List<ulong> primes = new List<ulong>();
        public static int highestDivisorAmount = 0;
        public static ulong antiPrime = 0;
        public static List<List<ulong>> divisorList = new List<List<ulong>>();

        private static void IsNumHighestAntiPrime(int divisorAmount, ulong num)
        {
            // Checks to see if the provided 'divisorAmount' is larger than the 'highestDivisorAmount'.
            // If so, then that value is stored as the 'highestDivisorAmount', and the number that
            // gained that amount of divisors will also be stored as a 'antiPrime'.

            if (highestDivisorAmount < divisorAmount)
            {
                highestDivisorAmount = divisorAmount;
                antiPrime = num;
            }
        }

        private static void IsNumPrime(ulong num)
        {
            // "divisorAmount" stores the amount of times that "num"
            // has been divided without leaving any remainders.
            // It also stores all the divisors of num.

            List<ulong> divisors = new List<ulong>();

            int divisorAmount = 0;

            for (ulong i = 1; i < num; i++)
            {
                if (num % i == 0)           // Checks if 'num' leaves any remainders.
                {
                    divisorAmount++;
                    divisors.Add(i);
                }
            }

            if (divisorAmount == 1)         // Determines a prime number.
            {
                primes.Add(num);
            }

            IsNumHighestAntiPrime(divisorAmount, num);
            divisorList.Add(divisors);  // Stores the divisors of num at an index equal to num.
        }

        public static void AlPrimesUpTo(ulong num)
        {
            for (ulong i = 0; i <= num; i++)
            {
                IsNumPrime(i);
            }
        }

        public static void Setup()
        {
            (leftPos, topPos) = GetCursorPosition();
            CursorVisible = false;
        }

        public static void Terminate()
        {
            (leftPos, topPos) = GetCursorPosition();
            CursorVisible = true;
        }

        static void Main(string[] args)
        {
            try
            {
                Setup();
                
                AlPrimesUpTo(ulong.Parse(args[0]));

                if (Convert.ToInt32(args[0]) < 2)
                {
                    throw new Exception();
                }

                PrintBox.PrintPrimes(25);
                PrintBox.PrintDivisors(25);
                
                Terminate();
            }
            catch (Exception)
            {
                Write($"\nYou must enter a number that is greater than 2 as a command line argument.\n Try 'PrimeNumbers 360'.\n\n");

                Terminate();
            }
        }
    }
}