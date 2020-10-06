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
                    Console.WriteLine("Name unavailable");
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
        catch { Console.WriteLine("Error"); }
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

    private void Sort(List<Animal> list)
    {
        int min;
        for (int i = 0; i < list.Count - 1; i++)
        {
            min = i;
            for (int index = i + 1; index < list.Count; index++)
            {
                if (list[index].name.CompareTo(list[min].name) < 0)
                {
                    min = index;
                }
            }
            if (min != i)
            {
                Animal temp = list[i];
                list[i] = list[min];
                list[min] = temp;
            }
        }
    }

    public void SortSpeciesName()
    {
        Sort(animals);
        foreach (Animal a in animals)
        {
            if (a is Tiger)
            {
                Tiger temp = a as Tiger;
                Console.WriteLine(a.name + temp.weight);
            }
            if (a is Elephant)
            {
                Elephant temp = a as Elephant;
                Console.WriteLine(a.name + temp.trunkLength);
            }
            if (a is Owl)
            {
                Owl temp = a as Owl;
                Console.WriteLine(a.name + temp.wingspan);
            }
        }
    }
}