using System;
using System.Globalization;
using System.IO;

class CreateClass
{
    private string className;
    private string unique;
    private bool containsUnique;
    
    public void MakeClass()
    {
        CreateClass cc = new CreateClass();
        Console.WriteLine("Enter name: \n>>>");
        string name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().ToLower());
        if (name.Contains(" "))
        {
            Console.WriteLine("no spaces");
            return;
        }
        cc.className = name;
        Console.WriteLine("Add unique Integer attribute y/n?");
        if (Console.ReadLine().ToLower() == "y")
        {
            bool loop = true;
            Console.WriteLine("Enter name: \n>>>");
            while (loop == true)
            {
                string input = Console.ReadLine().ToLower();
                if (input.Contains(" "))
                {
                    Console.WriteLine("no spaces");
                    return;
                }
                switch (input)
                {
                    case "name":
                    case "age":
                    case "deceased":
                    case "deathDate":
                    case "id":
                    case "":
                        Console.WriteLine("name taken");
                        break;
                    case "cancel":
                        return;
                    default:
                        cc.unique = input;
                        cc.containsUnique = true;
                        cc.Write();
                        return;
                }
            }
        }
        cc.Write();
        return;
    }
    public string GenerateClass()
    {
        return "class " + className + " : Animal\n{";
    }
    public string GenerateCunstructor()
    {
        if (containsUnique == true)
        {
            return "\n    public " + className + "(string name, int age, int " + unique + ") : base(name, age)\n    {\n        this." + unique + " = " + unique + ";\n    }\n    public " + className + "() { }\n";
        }
        return "\n    public " + className + "(string name, int age) : base(name, age) { }\n    public " + className + "() { }\n";
    }
    public string GenerateToString()
    {
        if (containsUnique == true)
        {
            return "\npublic int GetUnique()\n    {\n        return " + unique + ";\n    }\n    public override string ToString()\n    {\n        if (deceased == true)\n        {\n            return $\"" + className + "; DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}, " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(unique.ToLower()) + ": {" + unique + "}\";\n        }\n        return $\"" + className + "; Id: {Id}, Name: {name}, Age: {age}, " + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(unique.ToLower()) + ": {" + unique + "}\";\n    }";
        }
        return "\n    public override string ToString()\n    {\n        if (deceased == true)\n        {\n            return $\"" + className + "; DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}\";\n        }\n        return $\"" + className + "; Id: {Id}, Name: {name}, Age: {age}\";\n    }";
    }
    public string GenerateInfo()
    {
        if (containsUnique == true)
        {
            return "\n    public override string Info()\n    {\n        return $\"" + className + ",{Id},{name},{age},{deceased},{deathDate},{" + unique + "}}\";\n    }";
        }
        return "\n    public override string Info()\n    {\n        return $\"" + className + ",{Id},{name},{age},{deceased},{deathDate},0\";\n    }";
    }
    public string GenerateBody()
    {
        if (containsUnique == true)
        {
            return "\n    public int " + unique + ";";
        }
        return null;
    }
    public void Write()
    {
        using (StreamWriter sw = new StreamWriter(@"..\..\..\animals\" + className + ".cs"))
        {
            sw.Write(GenerateClass() + GenerateBody() + GenerateToString() + GenerateInfo() + GenerateCunstructor() + "}");
        }
    }
}