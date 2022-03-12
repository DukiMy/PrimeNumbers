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
*/

using System;
using static System.Console;

class Program
{
    private static int highestDivisorAmount = 0;
    private static int antiPrime = 0;

    private static void IsNumHighestAntiPrime(int divisorAmount, int num)
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
    private static void IsNumPrime(int num)
    {
        // "divisorAmount" stores the amount of times that "num"
        // has been divided without leaving any remainders.

        int divisorAmount = 0;

        for (var i = 1; i < num; i++)
        {
            if (num % i == 0)           // Checks if 'num' leaves any remainders.
            {
                divisorAmount++;
            }
        }

        if (divisorAmount == 1)         // Determines a prime number.
        {
            WriteLine($"{num} is a prime.");
        }

        IsNumHighestAntiPrime(divisorAmount, num);
    }
    public static void AlPrimesUpTo(int num)
    {
        for (var i = 0; i < num; i++)
        {
            IsNumPrime(i);   
        }
    }

    static void Main(string[] args)
    {
        try
        {
            AlPrimesUpTo(int.Parse(args[0]));
            WriteLine($"\n{antiPrime} is the highest antiprime in the interval, and it has {highestDivisorAmount + 1} divisors.");
        }
        catch (Exception)
        {
            WriteLine($"\nYou entered '{args[0]}', you must enter a positive number as a command line argument.\n Try 'dotnet run 135'.\n");
        }
        
    }
}