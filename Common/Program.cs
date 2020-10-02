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
        //utility.Save();
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
                        Console.WriteLine("syntax error");
                        break;
                    }
                    try 
                    { 
                        utility.NewAnimal(command[1], command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
                    }
                    catch 
                    {
                        Console.WriteLine("syntax error");
                        break;
                    }               
                    break;

                case "death":
                    if (command.Length != 3)
                    {
                        Console.WriteLine("syntax error");
                        break;
                    }
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
