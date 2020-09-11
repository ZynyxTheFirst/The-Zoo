using System;
using System.Collections.Generic;
using System.Reflection;

class Utility
{
    private string path = @"..\..\..\Data\animals.txt";
    readonly List<Animal> animals = new List<Animal>();
    public void TestTiger()
    {
        Tiger t = new Tiger("TestTiger", 5, 5);
        animals.Add(t);
    }

    public void AddAnimal(string type)
    {
        Type t = Type.GetType(type, true);

        if(t == typeof(Animal))
		{
            Animal a = (Animal)Activator.CreateInstance(t);
            
		}

    }
}