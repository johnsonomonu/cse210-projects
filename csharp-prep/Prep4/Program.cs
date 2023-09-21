using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numberList = new List<int>();

        int userInput = -1;
        while (userInput != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userInput = int.Parse(userResponse);

            if (userInput != 0)
            {
                numberList.Add(userInput);
            }
        }

        int sum = 0;
        foreach (int number in numberList)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numberList.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numberList[0];

        foreach (int number in numberList)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}
