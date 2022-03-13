﻿/*
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
using static System.Console;

class Program
{
    private static int highestDivisorAmount = 0;
    private static ulong antiPrime = 0;
    private static List<List<ulong>> divisorList = new List<List<ulong>>();

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
            Write($"{num}\n");
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

    static void Main(string[] args)
    {
        try
        {
            Write($"\nThe primes in the chosen interval are:\n");
            AlPrimesUpTo( ulong.Parse(args[0]));
            Write($"\n{antiPrime} is the highest antiprime in the interval, and it has {highestDivisorAmount + 1} divisors.\nIts divisors are:");

            foreach (ulong divisor in divisorList[Convert.ToInt32(antiPrime)])
            {
                Write($" {divisor}");
            }

            Write($" {antiPrime}.\n ");
        }
        catch (Exception)
        {
            Write($"\nYou entered '{args[0]}', you must enter a positive number as a command line argument.\n Try 'dotnet run 135'.\n");
        }
    }
}