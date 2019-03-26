using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ExercitiuActual
    //de vazut dificultatea daca trebuie stocata aici
{
        public int[] numere;
        public int numarulNumere;

        public char[] semne;
        public int numarulSemne;

        public int rezultat;

        public ExercitiuActual(int numarulNumere,int numarulSemne)
        {
            this.numarulNumere = numarulNumere;
            numere = new int[numarulNumere];
            this.numarulSemne = numarulSemne;
            semne = new char[numarulSemne];
        }

        public void reset()
        {
            numere = new int[numarulNumere];
            semne = new char[numarulSemne];
        }

        public string returnareRezultat()
        {
            string a="";
            for(int i = 0; i < numarulSemne; i++)
            {
                a = a + numere[i];
                a = a + semne[i];
            }
            a = a + numere[numarulNumere - 1];//lipire ultimul nr
            return a;
        }
}
