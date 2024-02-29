using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter a grade percentage: ");
        string gradeStr = Console.ReadLine();

        int grade = 0;
        bool result = int.TryParse(gradeStr, out grade);

        // if the use entered an interger, else give error message
        if (result)
        {
            string letter = "";

            if (grade >= 90)
            {   
                letter = "A";
            }
            else if (grade >= 80)
            {
                letter = "B";
            }
            else if (grade >= 70)
            {
                letter = "C";
            }
            else if (grade >= 60)
            {
                letter = "D";
            }
            else
            {
                letter = "F";
            }

            string strMessage = "";

            if (grade >= 70)
            {
                strMessage = "Congratulations! You passed the course.";
            }
            else
            {
                strMessage = "Sorry, that is not a passing grade. Please try again.";
            }

            Console.WriteLine($"Your grade letter is {letter}. {strMessage}");
        }
        else
        {
            Console.WriteLine("Invalid entry. You must enter an integer.");
        }
    }
}