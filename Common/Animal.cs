abstract class Animal
{
    readonly RndIDGen rid = new RndIDGen();

    protected virtual int Id
    {
        get { return rid.AnimalId(); }
        set {; }
    }
    
    protected string name;
    protected int age;

    public string GetName()
    {
        return name;
    }
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
    public Animal() { }
}