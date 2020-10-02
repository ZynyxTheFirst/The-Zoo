﻿using System;

abstract class Animal
{
    readonly RndIDGen rid = new RndIDGen();

    protected virtual int Id
    {
        get { return rid.AnimalId(); }
        set {; }
    }
    
    protected string name;
    protected int age;
    protected bool deceased;
    protected string deathDate = null;

    public void SetDeath(string Date)
    {
        deceased = true;
        deathDate = Date;
    }

    public string GetName()
    {
        return name;
    }
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}";
        }
        return $"Id: {Id}, Name: {name}, Age: {age}";
    }
    public virtual string Info()
    {
        return $"{Id},{name},{age},{Convert.ToInt32(deceased)},{deathDate}";
    }
    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public Animal() { }
}