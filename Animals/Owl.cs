using System;

class Owl : Animal
{
    readonly RndIDGen rid = new RndIDGen();
    public int wingspan;
    protected override int Id
    {
        get { return rid.OwlId(wingspan); }
        set {; }
    }

    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Owl; DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}, Wingspan: {wingspan}";
        }
        return $"Owl; Id: {Id}, Name: {name}, Age: {age}, Wingspan: {wingspan}";
    }
    
    public override string Info()
    {
        return $"Owl,{Id},{name},{age},{wingspan},{deceased},{deathDate}";
    }

    public Owl(string name, int age, int wingspan) : base(name, age)
    {
        this.wingspan = wingspan;
    }
    public Owl() { }
}