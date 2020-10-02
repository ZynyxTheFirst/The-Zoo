using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

class Utility
{
    private readonly string path = @"..\..\..\Data\animals.txt";
    readonly List<Animal> animals = new List<Animal>();
    public void Save()
    {
        StreamWriter animalsw = new StreamWriter(path, true);
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
            NewAnimal(strings[0], strings[1], Int32.Parse(strings[2]), Int32.Parse(strings[3]), Convert.ToBoolean(strings[4]), strings[5]);
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
                return;
            }
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
                    throw new Exception();
                }
            }
        }
    }
    public void NewAnimal(string t, string name, int age, int unique, bool deceased = false, string date = null)
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
        catch { throw new Exception(); }
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
}