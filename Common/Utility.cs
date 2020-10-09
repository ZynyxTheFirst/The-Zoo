using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

class Utility
{
    class DuplicateException : Exception { }

    readonly List<Animal> animals = new List<Animal>();
    private readonly string path = @"..\..\..\Data\animals.txt";

    public void Save()
    {
        StreamWriter animalsw = new StreamWriter(path);
        foreach (Animal a in animals)
        {
            animalsw.WriteLine(a.Info());
        }
        animalsw.Close();
    }
    public void Load()
    {
        StreamReader animalsr = new StreamReader(path);
        string text;
        while ((text = animalsr.ReadLine()) != null)
        {
            string[] strings = text.Split(char.Parse(","));
            if (bool.Parse(strings[4]) == true)
            {
                NewAnimal(strings[0], strings[2], Int32.Parse(strings[3]), Int32.Parse(strings[6]), bool.Parse(strings[4]), strings[5]);
            }
            else
            {
                NewAnimal(strings[0], strings[2], Int32.Parse(strings[3]), Int32.Parse(strings[6]));
            }
            
        }
        animalsr.Close();
    }
    public void Print()
    {
        if (animals.Count != 0)
        {
            foreach (Animal a in animals)
            {
                Console.WriteLine(a.ToString());
            }
            return;
        }
        Console.WriteLine("empty.");
    }
    public void CheckDuplicate(string name, List<Animal> animals)
    {
        for (int i = 0; i < animals.Count | i < animals.Count; i++)
        {
            if (animals[i] != null)
            {
                if (animals[i].GetName().ToLower() == name.ToLower())
                {
                    throw new DuplicateException();
                }
            }
        }
    }
    public void NewAnimal(string t, string name, int age, int unique = 0, bool deceased = false, string date = null)
    {
        try
        {
            CheckDuplicate(name, animals);
            Type type = Type.GetType(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t.ToLower()), true);

            var temp = Activator.CreateInstance(type);

            if (temp is Animal)
            {
                Type[] args = { typeof(string), typeof(int), typeof(int) };
                ConstructorInfo constructorInfoObj = type.GetConstructor(args);
                if (constructorInfoObj != null)
                {
                    //input parameters
                    var animal = Activator.CreateInstance(type, name, age, unique);
                    animals.Add(animal as Animal);
                    if (deceased == true)
                    {
                        (animal as Animal).SetDeath(date);
                    }
                    return;
                }

                args = new Type[2] { args[0], args[1] };
                constructorInfoObj = type.GetConstructor(args);

                if (constructorInfoObj != null)
                {
                    var animal = Activator.CreateInstance(type, name, age);
                    animals.Add(animal as Animal);
                    if (deceased == true)
                    {
                        (animal as Animal).SetDeath(date);
                    }
                    return;
                }
            }
        }
        catch (DuplicateException) { Console.WriteLine("Name unavailable"); }
        catch (Exception) { Console.WriteLine("Error"); }
    }
    public void RegisterDeath(string name, string date)
    {
        try
        {
            for (int i = animals.Count - 1; i >= 0; i--)
            {
                if (animals[i].GetName().ToLower() == name)
                {
                    Animal animal = animals[i];
                    animal.SetDeath(date);
                }
            }
        }
        catch { throw new Exception(); }
    }
    public void Sort(string t)
    {
        if (t == "all")
        {
            List<Animal> sortedanimals = animals.OrderBy(o => o.GetName()).ToList();
            foreach (Animal a in sortedanimals) { Console.WriteLine(a.ToString()); }
            return;
        }
        try
        {
            Type type = Type.GetType(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(t.ToLower()), true);

            var temp = Activator.CreateInstance(type);
            
            if (temp is Animal)
            {
                Type[] args = { typeof(string), typeof(int), typeof(int) };
                ConstructorInfo constructorInfoObj = type.GetConstructor(args);
                if (constructorInfoObj != null)
                {
                    List<Animal> sortedanimals = animals.OrderByDescending(o => o.GetUnique()).ToList();
                    foreach (Animal a in sortedanimals)
                    {
                        if (a.GetType() == type)
                        {
                            Console.WriteLine(a.ToString());
                        }
                    }
                    return;
                }
                args = new Type[2] { args[0], args[1] };
                constructorInfoObj = type.GetConstructor(args);

                if (constructorInfoObj != null)
                {
                    List<Animal> sortedanimals = animals.OrderBy(o => o.GetName()).ToList();
                    foreach (Animal a in sortedanimals)
                    {
                        if (a.GetType() == type)
                        {
                            Console.WriteLine(a.ToString());
                        }
                    }
                    return;
                }
            }
        }
        catch (Exception) { Console.WriteLine("Error"); }
    }
    public void Help()
    {
        Console.WriteLine("Command:    | Parameters:                  | Effect:");
        Console.WriteLine("“help”      | none                         | lists all commands");
        Console.WriteLine("“clear”     | none                         | clears the console");
        Console.WriteLine("“exit”      | none                         | saves and exits the program");
        Console.WriteLine("“add”       | [Type][Name][Age]([unique])  | adds a new animal with the specified parameters");
        Console.WriteLine("“print”     | none                         | lists all animals in order of creation");
        Console.WriteLine("“sort”      | [(all)/(Type)]               | sorts all animals or all animals of a specified type");
        Console.WriteLine("“death”     | [Name][Date]                 | registers the death of an animal with a certain date");
        Console.WriteLine("“register”  | none                         | register a new type (species) of animal");
    }
}