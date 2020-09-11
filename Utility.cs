using System;
using System.Collections.Generic;

class Utility
{
    readonly List<Animal> animals = new List<Animal>();
    public void TestTiger()
    {
        Tiger t = new Tiger("", 5, 5);
        animals.Add(t);
    }


}