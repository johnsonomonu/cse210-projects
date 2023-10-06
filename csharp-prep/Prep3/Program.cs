using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);
        int guess = -1;
        while (guess != magicNumber)
        {
            Console.Write("Enter your guess number");
            guess = int.Parse(Console.ReadLine());

            if (magicNumber > guess)
            {
                Console.WriteLine("Higher");
            }

            else if (magicNumber < guess)
            {
                Console.WriteLine("Lower");
            }

            else
            {
                Console.Write("You Guessed it right !!");
            }

        }
    }
}
