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
        string tempId = "";
        string[] trunkthingy = new string[10];

        for (int i = 0; i < trunkthingy.Length; i++)
        {
            trunkthingy[i] = trunkLength.ToString();
            tempId += trunkthingy[i];
        }

        return Int32.Parse(tempId.ToString().Substring(0, 6));
    }

    public int OwlId(int wingspan)
    {
        int tempId = RND(100, 999);

        string id = wingspan.ToString();
        while (id.Length < 3)
        {
            string temp = "0";
            string temp2 = id;
            temp += temp2;
            id = temp;
        }
        return Int32.Parse(id += tempId);
    }

    public int TigerId(string name, int weight)
    {
        string tempName;
        string tempName2 = "";
        byte[] charValue = Encoding.ASCII.GetBytes(name.Substring(0, 3));

        for (int i = 0; i < charValue.Length; i++)
        {
            tempName = charValue[i].ToString();
            tempName2 += tempName;
        }

        int tempId = Int32.Parse(tempName2);
        tempId *= weight;
        return Math.Abs(Int32.Parse(tempId.ToString().Substring(0, 6)));
    }
}