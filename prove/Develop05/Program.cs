// For the exceeds expectations, I added a graphic everytime
// the score crosses a 1000 point milestone
// I also added some extra input verification throughout the program.

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        Console.WriteLine("WELCOME TO ETERNAL QUEST\n");
        
        GoalManager newProgram = new GoalManager();

        newProgram.Start();
    }


}