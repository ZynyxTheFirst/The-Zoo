﻿class Owl : Animal
{
    readonly RndIDGen rid = new RndIDGen();

    public int wingspan;
    protected override int id
    {
        get { return rid.OwlId(wingspan); }
        set {; }
    }

    public override int GetUnique()
    {
        return wingspan;
    }
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Owl; DECEASED; Date of Death: {deathDate}, Id: {id}, Name: {name}, Age: {age}, Wingspan: {wingspan}";
        }
        else return $"Owl; Id: {id}, Name: {name}, Age: {age}, Wingspan: {wingspan}";
    }
    public override string Info()
    {
        return $"Owl,{id},{name},{age},{deceased},{deathDate},{wingspan}";
    }

    public Owl(string name, int age, int wingspan) : base(name, age)
    {
        this.wingspan = wingspan;
    }
    public Owl() { }
}