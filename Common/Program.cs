using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    readonly Utility utility = new Utility();
    readonly CreateClass cc = new CreateClass();
    readonly RndIDGen rid = new RndIDGen();
    static void Main()
    {
        Program p = new Program();
        p.Run();
    }

    public void Run()
    {
        //cc.MakeClass();
        Console.WriteLine(rid.AnimalId());
        //cc.GetFinal();
        //cc.MakeClass();
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
    }
}
