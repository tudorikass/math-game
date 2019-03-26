using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Semne
{
    public char[] semne = { '+', '-', '*', '/' };
    public int[] valori = { 1, 2, 3, 4 };

    public int returnareValoare(char semn)
    {
        int index = 0;
        foreach (char a in semne)
        {
            if (a == semn)
            {
                return valori[index];
            }
            index++;
        }
        return 0;
    }

    public char returnareSemn(int val)
    {
        int index = 0;
        foreach (int a in valori)
        {
            if (a == val)
            {
                return semne[index];
            }
            index++;
        }
        return '+';
    }
}
