using System;

class Program
{
    readonly Utility utility = new Utility();
    readonly CreateClass cc = new CreateClass();

    static void Main()
    {
        Program p = new Program();
        p.Run();
    }
    public void Run()
    {
        utility.Load();
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
                    if (command.Length == 5)
                    {
                        try
                        {
                            utility.NewAnimal(command[1], command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
                        }
                        catch
                        {
                            Console.WriteLine("Error");
                            break;
                        }
                    }
                    else if (command.Length == 4)
                    {
                        try
                        {
                            utility.NewAnimal(command[1], command[2], Int32.Parse(command[3]));
                        }
                        catch
                        {
                            Console.WriteLine("Error");
                            break;
                        }
                    }
                    else 
                    {
                        Console.WriteLine("syntax error");
                        break;
                    }     
                    break;
                case "sort":
                    if (command.Length != 2)
                    {
                        Console.WriteLine("syntax error");
                        break;
                    }
                    utility.Sort(command[1]);
                    break;
                case "death":
                    if (command.Length != 3)
                    {
                        Console.WriteLine("syntax error");
                        break;
                    }
                    utility.RegisterDeath(command[1], command[2]);
                    break;
                case "register":
                    cc.MakeClass();
                    break;
                case "print":
                    utility.Print();
                    break;
                case "help":
                    utility.Help();
                    break;
                case "clear":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
