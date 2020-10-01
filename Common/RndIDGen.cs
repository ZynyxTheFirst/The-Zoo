using System;
using System.Text;

class RndIDGen
{
    static int RND(int min, int max)
    {
        Random rnd = new Random();
        return rnd.Next(min, max);
    }

    public int AnimalId()
    {
        return RND(99999, 1000000);
    }

    public int ElephantId(int trunkLength)
    {
        throw new NotImplementedException();
    }

    public int OwlId(int wingspan)
    {
        throw new NotImplementedException();
    }

    public int TigerId(string name, int weight)
    {
        string tempName;
        string tempName2 = "";
        int tempId;
        byte[] charValue = Encoding.ASCII.GetBytes(name.Substring(0, 3));

        for (int i = 0; i < charValue.Length; i++)
        {
            tempName = charValue[i].ToString();
            tempName2 += tempName;
        }

        tempId = Int32.Parse(tempName2);
        tempId *= weight;
        string id = tempId.ToString().Substring(0, 6);

        return Int32.Parse(id);
    }
}