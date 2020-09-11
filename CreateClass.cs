using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

class CreateClass
{
    readonly List<CreateClass> createClasses = new List<CreateClass>();
    readonly List<string> strings = new List<string>();
    readonly List<string> integers = new List<string>();

    public string className;

    public void MakeClass()
    {
        CreateClass cc = new CreateClass();
        Console.WriteLine("Enter name: \n>>>");
        cc.className = (Console.ReadLine().ToLower());
        Console.WriteLine("Add Integer attribute y/n?");
        if (Console.ReadLine().ToLower() == "y")
        {
            while (true)
            {
                Console.WriteLine("Enter atribute name\n>>>");
                cc.integers.Add(Console.ReadLine().ToLower());
                Console.WriteLine("Add another y/n?");
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
        }
        Console.WriteLine("Add String attribute y/n?");
        if (Console.ReadLine().ToLower() == "y")
        {
            while (true)
            {
                Console.WriteLine("Enter atribute name\n>>>");
                cc.strings.Add(Console.ReadLine().ToLower());
                Console.WriteLine("Add another y/n?");
                if (Console.ReadLine().ToLower() == "n")
                {
                    break;
                }
            }
        }
        createClasses.Add(cc);
        cc.Write();
        cc.GetFinal();
    }

    public string GenerateClass()
    {
        return "class " + className + " : Animal\n{";
    }

    public string GenerateCunstructor()
    {
        string cons1 = "\n    public " + className + "(string name, int age";
        string cons2 = "";
        string cons3 = "";
        string cons4 = ") : base(name, age)\n    {";
        string cons5 = "";
        string cons6 = "";
        foreach (string s in strings)
        {
            cons2 = cons2 + ", string " + s;
        }
        foreach (string i in integers)
        {
            cons3 = cons3 + ", int " + i;
        }
        foreach (string s in strings)
        {
            cons5 = cons5 + "\n        this." + s + " = " + s + ";";
        }
        foreach (string i in integers)
        {
            cons6 = cons6 + "\n        this." + i + " = " + i + ";";
        }
        return cons1 + cons2 + cons3 + cons4 + cons5 + cons6 + "\n    }";
    }

    public string GenerateToString()
    {
        string ts1 = "\n     public override string ToString()\n     {";
        string ts2 = "\n" + "        return \"Name: \" + name + \"Age: \" + age";
        string ts3 = "";
        string ts4 = "";
        string ts5 = ";\n     }";
        foreach (string s in strings)
        {
            ts3 = ts3 + " + \"" + s + ": \" + " + s;
        }
        foreach (string i in integers)
        {
            ts4 = ts4 + " + \"" + i + ": \" + " + i;
        }
        return ts1 + ts2 + ts3 + ts4 + ts5;
    }

    public string GenerateBody()
    {
        string bod1 = "";
        string bod2 = "";
        foreach (string s in strings)
        {
            bod1 = bod1 + "\n     public string " + s + ";";
        }
        foreach (string i in integers)
        {
            bod2 = bod2 + "\n     public int " + i + ";";
        }
        return bod1 + bod2;
    }

    public string FinalGeneration()
    {
        string gClass = GenerateClass();
        string gBody = GenerateBody();
        string gToString = GenerateToString();
        string gConstruct = GenerateCunstructor();
        string final = gClass + gBody + gToString + gConstruct + "\n}";
        return final;
    }

    public void Write()
    {
        using (StreamWriter sw = new StreamWriter(@"..\..\..\animals\" + className + ".cs"))
        {
            sw.Write(FinalGeneration());
        }
    }

    public void GetFinal()
    {
        Console.WriteLine(FinalGeneration());
    }
}