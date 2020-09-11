class Elephant : Animal
{
    public int trunkLength;

    public override string ToString()
    {
        return "Name: " + name + "\nAge: " + age + "\nTrunkLength: " + trunkLength;
    }

    public Elephant(string name, int age, int trunkLenght) : base(name, age)
    {
        this.trunkLength = trunkLenght;
    }
}
