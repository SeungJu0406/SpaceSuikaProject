using System;
using System.Collections;
using System.Collections.Generic;

public class Util
{
    public static Random random = new Random();

    public static int Random(int min, int max)
    {
        return random.Next(min, max+1);
    }
}
