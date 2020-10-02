class Tiger : Animal
{
    readonly RndIDGen rid = new RndIDGen();
    public int weight;
    protected override int Id
    {
        get { return rid.TigerId(name, weight); }
        set {; }
    }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {name}\nAge: {age}\nWeight: {weight}";
    }

    public override string Info()
    {
        return $"{Id},{name},{age},{weight}";
    }

    public Tiger(string name, int age, int weight) : base(name, age)
    {
        this.weight = weight;
    }
    public Tiger() { }
}
