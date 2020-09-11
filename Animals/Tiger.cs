class Tiger : Animal
{
    public int weight;

    public override string ToString()
    {
        return "Name: " + name + "\nAge: " + age + "\nWeight: " + weight;
    }

    public Tiger(string name, int age, int weight) : base(name, age)
    {
        this.weight = weight;
    }
}
