abstract class Animal
{
    readonly RndIDGen rid = new RndIDGen();

    protected virtual int id
    {
        get { return rid.AnimalId(); }
        set {; }
    }
    protected string name;
    protected int age;
    protected bool deceased;
    protected string deathDate = null;

    public virtual int GetUnique()
    {
        return 1;
    }
    public string GetName()
    {
        return name;
    }
    public void SetDeath(string Date)
    {
        deceased = true;
        deathDate = Date;
    }
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"DECEASED; Date of Death: {deathDate}, Id: {id}, Name: {name}, Age: {age}";
        }
        return $"Id: {id}, Name: {name}, Age: {age}";
    }
    public virtual string Info()
    {
        return $"{id},{name},{age},{deceased},{deathDate}";
    }

    public Animal(string name, int age)
    {
        this.name = name;
        this.age = age;
    }
    public Animal() { }
}