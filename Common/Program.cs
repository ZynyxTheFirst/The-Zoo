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
        utility.NewAnimal("Tiger", "hej", 12, 33);
        utility.Print();
        

        //cc.MakeClass();
        //Console.WriteLine(rid.AnimalId());
        //cc.GetFinal();
        //cc.MakeClass();
        
        
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
                    utility.NewAnimal(command[1], command[2], Int32.Parse(command[3]), Int32.Parse(command[4]));
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
