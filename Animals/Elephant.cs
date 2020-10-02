class Elephant : Animal
{
    readonly RndIDGen rid = new RndIDGen();
    public int trunkLength;
    protected override int Id
    {
        get { return Id; }
        set { Id = rid.ElephantId(trunkLength); }
    }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {name}\nAge: {age}\nTrunkLength: {trunkLength}";
    }
    public override string Info()
    {
        return $"{Id},{name},{age},{trunkLength}";
    }

    public Elephant(string name, int age, int trunkLenght) : base(name, age)
    {
        this.trunkLength = trunkLenght;
    }
}
