class Tiger : Animal
{
    readonly RndIDGen rid = new RndIDGen();

    public int weight;
    protected override int id
    {
        get { return rid.TigerId(name, weight); }
        set {; }
    }

    public override int GetUnique()
    {
        return weight;
    }
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Tiger; DECEASED; Date of Death: {deathDate}, Id: {id}, Name: {name}, Age: {age}, Weight: {weight}";
        }
        return $"Tiger; Id: {id}, Name: {name}, Age: {age}, Weight: {weight}";
    }
    public override string Info()
    {
        return $"Tiger,{id},{name},{age},{deceased},{deathDate},{weight}";
    }

    public Tiger(string name, int age, int weight) : base(name, age)
    {
        this.weight = weight;
    }
    public Tiger() { }
}
