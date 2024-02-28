using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask the user for their name
        Console.Write("What is your first name? ");
        string fname = Console.ReadLine();

        Console.Write("What is your last name? ");
        string lname = Console.ReadLine();

        Console.WriteLine($"\nYour name is {lname}, {fname} {lname}.");
    }
}