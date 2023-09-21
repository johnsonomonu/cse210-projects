using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter grade in percentage");
        string answer = Console.ReadLine();
        int percentage = int.Parse(answer);
        string letter = "";

        if(percentage>=90)
        {
            letter = "A";

        }

        else if (percentage >= 80)
        {
            letter = "B";

        }


        else if (percentage >= 70)
        {
            letter = "C";

        }


        else if (percentage >= 60)
        {
            letter = "D";

        }


        else if (percentage <60)
        {
            letter = "F";

        }

        else 
        {
            Console.WriteLine("You entered an invalid number");

        }

        Console.WriteLine($"Your grade is {letter}");

        if (percentage >=70)
        {
            Console.WriteLine("Congratulations you passed");

        }

        else
        {
            Console.WriteLine("Sorry to inform you sir grader, you faild whofully");

        }

    }
}