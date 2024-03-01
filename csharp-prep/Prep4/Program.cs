using System;

class Program
{
    static void Main(string[] args)
    {
        string numEntry; // user entry variable
        int number; // convert numEntry string into an interger and store here
        List<int> numbers = new List<int>();
        int sum = 0;
        double average = 0;
        int largest = 0;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            
        do
        {
            Console.Write("Enter number: ");
            numEntry = Console.ReadLine();

            number = int.Parse(numEntry);

            // if the user didn't enter the 0 (aka quit) command,
            // then add the number to the list and sum 
            if (number != 0)
            {
                numbers.Add(number);
                sum += number;
            }

        } while (number != 0); // exit loop when user enters "0"

        // if the user didn't enter any numbers, other than 0
        if (numbers.Count > 0)
        {
            // I realize there are several ways to do this, 
            // but these functions seem to be the most efficient way
            average = numbers.Average();
            largest = numbers.Max();

            // if I had to do a loop for practice purposes, this is what I 
            // would have done to find the max

            // largest = numbers[0];
            // foreach (int num in numbers)
            // {
            //     if (num > largest)
            //     {
            //         largest = num;
            //     }
            // }

        }
    
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest numbers is: {largest}");    
    }
}