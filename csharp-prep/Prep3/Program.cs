using System;

class Program
{
    static void Main(string[] args)
    {
        string playGame = "y";

        while (playGame == "y")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1,101);
            
            int guess = 0;
            int numGuesses = 0;

            do
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();

                guess = int.Parse(userInput);
                numGuesses++;

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {numGuesses} guesses.");
                }
            } while (guess != number);

            Console.Write("Do you want to play again (y/n)? ");
            playGame = Console.ReadLine();
        } 
    }
}