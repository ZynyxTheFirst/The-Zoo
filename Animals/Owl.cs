class Owl : Animal
{
    public int wingspan;

    public override string ToString()
    {
        return "Name: " + name + "\nAge: " + age + "\nWingspan: " + wingspan;
    }

    public Owl(string name, int age, int wingspan) : base(name, age)
    {
        this.wingspan = wingspan;
    }
}