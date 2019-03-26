using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Numere
{
    public int[] cifre = { 1, 2, 3 };
    public int[] valori = { 1, 2, 3 };

    //primeste numarul de caractere si returneaza valoarea
    public int returnareValoare(int numar)
    {
        int index = 0;
        foreach (int a in cifre)
        {
            if (a == numar)
            {
                return valori[index];
            }
            index++;
        }
        return 0;
    }

    public int returnareCifre(int valoare)
    {
        int index = 0;
        foreach (int a in valori)
        {
            if (a == valoare)
            {
                return cifre[index];
            }
            index++;
        }
        return 0;
    }
}
