using System;

class Program
{
    readonly Utility utility = new Utility();
    static void Main()
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        utility.Load();
        //utility.NewAnimal("Tiger", "hej", 12, 33);
           
        while (true)
        {
            string input = Console.ReadLine().ToLower();
            string[] command = input.Split(" ");

            switch (command[0])
            {
                case "exit":
                    utility.Save();
                    Environment.Exit(0);
                    break;
                case "add":
                    if (command.Length != 5)
                    {
                        throw new Exception();
                    }
                    utility.NewAnimal(command[1], command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
                    break;
                case "death":
                    utility.RegisterDeath(command[1], command[2]);
                    break;
                case "print":
                    utility.Print();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Unknown command");
                    Console.ResetColor();
                    break;
            }
        }
    }
}
