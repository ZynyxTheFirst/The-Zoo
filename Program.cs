using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    readonly Utility utility = new Utility();
    CreateClass cc = new CreateClass();
    static void Main()
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        cc.MakeClass();
        /*
        cc.GetFinal();
        cc.MakeClass();
        utility.TestTiger();
        
        string input = Console.ReadLine().ToLower();
        string[] command = input.Split(" ");
        while (true)
        {
            switch (command[0])
            {
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Unknown command");
                    Console.ResetColor();
                    break;
            }
        }
        */
    }
}
