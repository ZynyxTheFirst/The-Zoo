abstract class Animal
{
    protected string name;
    protected int age;


    //public abstract void SetUniquiMember(string value);
    public override string ToString()
    {
        return "Name:" + name + "\nAge:" + age;
    }

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}