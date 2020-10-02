class Rabbit : Animal
{
    public override string ToString()
    {
        if (deceased == true)
        {
            return $"Rabbit; DECEASED; Date of Death: {deathDate}, Id: {Id}, Name: {name}, Age: {age}";
        }
        return $"Rabbit; Id: {Id}, Name: {name}, Age: {age}";
    }

    public override string Info()
    {
        return $"Rabbit,{Id},{name},{age},{deceased},{deathDate}";
    }

}

