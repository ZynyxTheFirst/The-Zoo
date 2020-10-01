using System;
using System.Collections.Generic;
using System.Reflection;

class Utility
{
    private readonly string path = @"..\..\..\Data\animals.txt";
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
    public void NewAnimal(string t, string name, int age, string unique)
    {
        Type type = Type.GetType(t, true);

        var temp = Activator.CreateInstance(type);

        if (temp is Animal)
        {
            Type[] args = { typeof(string), typeof(int), typeof(string) };
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
                return;
            }
        }
    }
}