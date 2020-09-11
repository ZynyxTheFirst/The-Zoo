abstract class Animal
{
    public string name;
    public int age;

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