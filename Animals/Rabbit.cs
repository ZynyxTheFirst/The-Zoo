class Rabbit : Animal
{
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Rabbit; DECEASED; Date of Death: {deathDate}, Id: {id}, Name: {name}, Age: {age}";
        }
        return $"Rabbit; Id: {id}, Name: {name}, Age: {age}";
    }
    public override string Info()
    {
        return $"Rabbit,{id},{name},{age},{deceased},{deathDate},0";
    }

    public Rabbit(string name, int age) : base(name, age) { }
    public Rabbit() { }
}