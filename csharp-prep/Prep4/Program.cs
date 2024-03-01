using System;

class Program
{
    static void Main(string[] args)
    {
        string numEntry;
        int number;
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

            if (number != 0)
            {
                numbers.Add(number);
                sum += number;
            }

        } while (number != 0);

        if (numbers.Count > 0)
        {
            average = numbers.Average();
            largest = numbers.Max();
        }
    
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest numbers is: {largest}");    
    }
}