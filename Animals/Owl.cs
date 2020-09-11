class Owl : Animal
{
    public int wingspan;

    public Owl(string name, int age, int wingspan) : base(name, age)
    {
        this.wingspan = wingspan;
    }
}