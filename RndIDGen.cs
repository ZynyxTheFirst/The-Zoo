using System;

class RndIDGen
{
    static void RND(int min, int max)
    {
        Random rnd = new Random();
        rnd.Next(min, max);
    }
}