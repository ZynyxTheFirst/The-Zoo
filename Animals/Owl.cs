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
        return $"Id: {Id}\nName: {name}\nAge: {age}\nWingspan: {wingspan}";
    }
    
    public override string Info()
    {
        return $"{Id},{name},{age},{wingspan}";
    }

    public Owl(string name, int age, int wingspan) : base(name, age)
    {
        this.wingspan = wingspan;
    }
}