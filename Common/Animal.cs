abstract class Animal
{
    readonly RndIDGen rid = new RndIDGen();
    protected virtual int Id
    {
        get { return Id; }
        set { Id = rid.AnimalId(); }
    }
    protected string name { public get; }
    protected int age;

    public override string ToString()
    {
        return $"Id: {Id}\nName: {name}\nAge: {age}";
    }
    public virtual string Info()
    {
        return $"{Id},{name},{age}";
    }
    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
}