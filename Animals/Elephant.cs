class Elephant : Animal
{
    readonly RndIDGen rid = new RndIDGen();
    public int trunkLength;
    protected override int Id
    {
        get { return rid.ElephantId(trunkLength); }
        set {; }
    }

    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Elephant; DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}, TrunkLength: {trunkLength}";
        }
        return $"Elephant; Id: {Id}, Name: {name}, Age: {age}, TrunkLength: {trunkLength}";
    }

    public override string Info()
    {
        return $"Elephant,{Id},{name},{age},{deceased},{deathDate},{trunkLength}";
    }

    public Elephant(string name, int age, int trunkLenght) : base(name, age)
    {
        this.trunkLength = trunkLenght;
    }
    public Elephant() { }
}
