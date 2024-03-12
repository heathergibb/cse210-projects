using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction firstFraction = new Fraction();
        Fraction secondFraction = new Fraction(5);
        Fraction thirdFraction = new Fraction(3,4);
        Fraction fourthFraction = new Fraction(1,3);

        Console.WriteLine(firstFraction.GetFractionString());
        Console.WriteLine(firstFraction.GetDecimalValue());
        
        Console.WriteLine(secondFraction.GetFractionString());
        Console.WriteLine(firstFraction.GetDecimalValue());
        
        Console.WriteLine(thirdFraction.GetFractionString());
        Console.WriteLine(thirdFraction.GetDecimalValue());

        Console.WriteLine(fourthFraction.GetFractionString());
        Console.WriteLine(fourthFraction.GetDecimalValue());        

    }
}

