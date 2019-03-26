using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;

static class RandomExtensions
{
    public static void Shuffle<T>(this System.Random rng, T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = rng.Next(n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
}

[System.Serializable]
public class ManagerExercitii
{
    public int[][] combinatiiNumere = new int[100][];
    int indexNumere;//cate randuri am
    public int[][] combinatiiSemne = new int[100][];
    int indexSemne;//cate randuri am
    int indexSemneBun;
    int indexNumarBun;

    Numere num;
    Semne sem;
    public int dificultateNumere;
    public int dificultateSemne;

    public ManagerExercitii()
    {
        num = new Numere();
        sem = new Semne();
    }
    public double calculareRezultat(string expression)
    {
        System.Data.DataTable table = new DataTable();
        table.Columns.Add("expression", typeof(string), expression);
        System.Data.DataRow row = table.NewRow();
        table.Rows.Add(row);
        return double.Parse((string)row["expression"]);
    }

    //doar in caz ca ne trebuie separate 
    public void splitString(string str)
    {
        string[] numbers = Regex.Split(str, @"\D+");
        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int i = int.Parse(value);
                Console.WriteLine("Number: {0}", i);
            }
        }

        string specialChar = @"+-*/";
        foreach (var i in str)
        {
            foreach (var item in specialChar)
            {
                if (item == i)
                    Console.WriteLine("Character: {0}", i);
            }
        }

    }


    public void calculareDificultate(string str)
    {
        string[] numbers = Regex.Split(str, @"\D+");
        dificultateNumere = 0;
        foreach (string value in numbers)
        {
            if (!string.IsNullOrEmpty(value))
            {
                int i = int.Parse(value);
                int nr_caractere = i.ToString().Length;
                dificultateNumere += num.returnareValoare(nr_caractere);
            }
        }
        Console.WriteLine("Dificultate numere: {0}", dificultateNumere);

        dificultateSemne = 0;
        string specialChar = @"+-*/";
        foreach (var i in str)
        {
            foreach (var item in specialChar)
            {
                if (item == i)
                    dificultateSemne += sem.returnareValoare(item);
            }
        }

        Console.WriteLine("Dificultate semne: {0}", dificultateSemne);

    }

    public string generareExecitiu(int dificultatenr, int dificultatesemne)
    {
        this.dificultateNumere = dificultatenr;
        this.dificultateSemne = dificultatesemne;
        //---obligatoriu
        indexNumere = 0;
        indexSemne = 0;
        indexSemneBun = 0;
        indexNumarBun = 0;
        //--------

        //randim intre val alea
        //alegem numerele

        //TODO MODIFICA 7 si 5 ca fiind SUMELE LA CARE VREAU SA AJUNG PT NR SI SEMNE

        int[] arrr = new int[220];
        printCompositionsPentruNumere(arrr, dificultatenr, 0);//7 e suma dorita
        Console.WriteLine("Combinatii pt numere OK");
        Console.WriteLine();
        int[] arrr2 = new int[220];
        printCompositionsPentruSemne(arrr2, dificultatesemne, 0);//7 e suma dorita
        Console.WriteLine("Combinatii pt semne OK");
        //in momentul de fata  am in combinatii semnse si numere toate combinatiile
        //si numarul de combinatii in indexi
        // to do -  generare random pana nimereste o combinatie buna X

        generare();
        Console.WriteLine("Generare Ok");
        //in momentul de fata am cele 2 combinatii bune(randul din matrice)
        // to do - extrag valorile semnelor si le generez
        // to do - extrag intai valorile cifrelor si le generez random
        return calc();
        int aa = 3;
    }

    //#################################################################################################
    //################################### Calculare posibilitati valori numere ########################
    //#################################################################################################

    void printCompositionsPentruNumere(int[] arr, int n, int i)
    {
        if (n == 0)
        {
            printArray(arr, i);//gaseste un rezultat bun
        }
        else if (n > 0)
        {
            for (int k = 1; k <= 3; k++)// 1 inceput si 3 final => 3 valori pt numere
            {
                arr[i] = num.valori[k - 1];
                printCompositionsPentruNumere(arr, n - num.valori[k - 1], i + 1);
            }
        }
    }

    // Utility function to print array arr[] 
    //salvez intr o matrice pe prima pozitie nr de numere si dupa numerele(valorile)
    void printArray(int[] arr, int m)
    {
        combinatiiNumere[indexNumere] = new int[m + 1];
        combinatiiNumere[indexNumere][0] = m;//prima pozitie nr de numere
        for (int i = 0; i < m; i++)
        {
            combinatiiNumere[indexNumere][i + 1] = arr[i];
            Console.Write(arr[i] + " ");
        }
        indexNumere++;
        Console.WriteLine();
    }




    //#################################################################################################
    //################################### Calculare posibilitati valori semne #########################
    //#################################################################################################

    void printCompositionsPentruSemne(int[] arr, int n, int i)
    {
        if (n == 0)
        {
            printArraySemne(arr, i);//gaseste un rezultat bun
        }
        else if (n > 0)
        {
            for (int k = 1; k <= 4; k++)// 1 inceput si 4 final => 4 valori pt semne
            {
                arr[i] = sem.valori[k - 1];
                printCompositionsPentruSemne(arr, n - sem.valori[k - 1], i + 1);
            }
        }
    }

    // Utility function to print array arr[] 
    //salvez intr o matrice pe prima pozitie nr de numere si dupa numerele(valorile)
    void printArraySemne(int[] arr, int m)
    {
        combinatiiSemne[indexSemne] = new int[m + 1];
        combinatiiSemne[indexSemne][0] = m;//prima pozitie nr de numere
        for (int i = 0; i < m; i++)
        {
            combinatiiSemne[indexSemne][i + 1] = arr[i];
            Console.Write(arr[i] + " ");
        }
        indexSemne++;
        Console.WriteLine();
    }

    //#################################################################################################
    //################################## Generare combinatii intre semne si numere ####################
    //#################################################################################################


    //scoate in indexSemneBun si indexNumarBun
    public void generare()
    {

        int ok = 0;
        while (ok == 0)
        {
            System.Random r = new System.Random();
            int randomNumere = r.Next(0, indexNumere); //for ints
            int randomSemne = r.Next(0, indexSemne); //for ints


            //verificare compatibilitate
            //1. la numere trebuie sa fie cel putin 2
            //2. la semne trebuie sa fie cu 1 mai mic decat numerele

            int numar = combinatiiNumere[randomNumere][0];
            Console.WriteLine(numar);
            if (numar > 1)
            {
                int semn = combinatiiSemne[randomSemne][0];
                if (semn == (numar - 1))
                {
                    indexSemneBun = randomSemne;
                    indexNumarBun = randomNumere;
                    ok = 1;
                }
            }
        }
        int y = 0;
    }

    //#################################################################################################
    //################################## Generare combinatii intre semne si numere ####################
    //#################################################################################################

    //rezultatul sa nu fie negativ
    //impartirea sa fie exacta
    //sa nu am rezultate partiale negative
    // to do - daca am un - automat nr din stanga sa fie mai mare sau egal decat nr din dreapta

    public int[] ReturnareOptiuniRezultat(string exercitiu)
    {
        System.Random r = new System.Random();
        int rezultat=Convert.ToInt32(calculareRezultat(exercitiu));
        int[] VectorRaspunsuriPosibile = { 0, 0, 0, 0 };
        VectorRaspunsuriPosibile[3] = rezultat;
        int indexNumere=0;
        if (rezultat < 10)
        {
            for (int i = 0; i < 3; i++)
            {

                int numar = r.Next(0, 15);
                while (VectorRaspunsuriPosibile.Contains(numar))
                {
                    numar = r.Next(0, 15);
                }
                VectorRaspunsuriPosibile[i] = numar;
            }
        }
        else if(rezultat <100)
        {
            for (int i = 0; i < 3; i++)
            {

                int numar = r.Next(0, 150);
                while (VectorRaspunsuriPosibile.Contains(numar))
                {
                    numar = r.Next(0, 150);
                }
                VectorRaspunsuriPosibile[i] = numar;
            }

        }
        else if (rezultat <= 1000)
        {
            for (int i = 0; i < 3; i++)
            {

                int numar = r.Next(0, 1200);
                while (VectorRaspunsuriPosibile.Contains(numar))
                {
                    numar = r.Next(0, 1200);
                }
                VectorRaspunsuriPosibile[i] = numar;
            }
        }
        return VectorRaspunsuriPosibile;
    }

    string calc()
    {
        int numarSemne = combinatiiSemne[indexSemneBun][0];
        int numarNumere = combinatiiNumere[indexNumarBun][0];
        ExercitiuActual ec = new ExercitiuActual(numarNumere, numarSemne);

        //generare semne
        char[] semne = new char[numarSemne];
        for (int i = 1; i <= numarSemne; i++)
        {
            semne[i - 1] = sem.returnareSemn(combinatiiSemne[indexSemneBun][i]);
        }
        for (int i = 0; i < numarSemne; i++)
        {//copiez in Ecuatie
            ec.semne[i] = semne[i];
        }

        //salvare nr de cifre pt fiecare nr
        int[] val = new int[numarNumere];
        for (int i = 1; i <= numarNumere; i++)
        {
            val[i - 1] = num.returnareCifre(combinatiiNumere[indexNumarBun][i]);//iau i=1 pt ca prima val din matrice reprezinta nr de valori de pe rand
        }
        //am valorile
        //generez seturi de numere

        int testc = 232;
        int ok = 0;
        while (ok == 0)
        {
            System.Random r = new System.Random();
            //generare numere si verificare
            for (int index = 0; index < 20; index++)
            {
                new System.Random().Shuffle(val);
                for (int i = 0; i < numarNumere; i++)
                {
                    if (val[i] == 1)
                    {//daca nr are o singura cifra

                        int numar = r.Next(0, 9);
                        ec.numere[i] = numar;
                    }
                    else if (val[i] == 2)
                    {
                        int numar = r.Next(10, 99);
                        ec.numere[i] = numar;
                    }
                    else
                    {
                        int numar = r.Next(100, 999);
                        ec.numere[i] = numar;
                    }
                }
                /*Console.WriteLine("generare noua");
                for (int i = 0; i < numarNumere-1; i++)
                {
                    Console.WriteLine(ec.numere[i]);
                    Console.WriteLine(ec.semne[i]);

                }
                Console.WriteLine(ec.numere[numarNumere-1]);*/
                //verificare
                //am ecuatia salvata in Ecuatie

                for (int i = 0; i < ec.numarulSemne; i++)
                {  //verificarea 1. Daca am un '-' verific ca nr din stanga sa fie mai mare decat cel din dreapta
                    ok = 1;
                    if (ec.semne[i] == '-')
                    {
                        /* if (val[i]+1 == val[i + 1])//daca nr din dreapta e de 3 cifre si cel din stanga de 2 sau 2 cu 1
                         {
                             int aux = ec.numere[i];
                             ec.numere[i] = ec.numere[i + 1];
                             ec.numere[i+1] = aux;
                         }
                         if (val[i] + 2 == val[i + 1])//daca nr din dreapta e de 3 cifre si cel din stanga de 1
                         {
                             int aux = ec.numere[i];
                             ec.numere[i] = ec.numere[i + 1];
                             ec.numere[i + 1] = aux;
                         }*/
                        if (ec.numere[i] >= ec.numere[i + 1])
                        {
                            ok = 1;
                        }
                        else
                        {
                            int aux = ec.numere[i];
                            ec.numere[i] = ec.numere[i + 1];
                            ec.numere[i + 1] = aux;
                            ok = 1;
                        }
                    }
                    //verific daca se imparte exact
                    if (ec.semne[i] == '/')
                    {
                        //daca primul nr e mai mic ca cifre decat al 2 lea
                        if (ec.numere[i] < ec.numere[i + 1])//daca nr dr este mai mare decat cel din stg se inverseaza
                        {
                            int aux = ec.numere[i];
                            ec.numere[i] = ec.numere[i + 1];
                            ec.numere[i + 1] = aux;
                        }
                        if (ec.numere[i] != 0 && ec.numere[i + 1] != 0)
                        {
                            if (ec.numere[i] % ec.numere[i + 1] == 0)
                            {
                                ok = 1;
                            }
                            else
                            {
                                ok = 0;
                                break;
                            }
                        }
                        else
                        {
                            ok = 0;
                            break;
                        }
                    }
                    if (ec.semne[i] == '*')//se mai poate umbla ca sa scazi un numar doar al o unitate(CACAT)
                    {
                        if (ec.numere[i] > 100)
                        {
                            ec.numere[i] = ec.numere[i] / 10;
                        }
                        if (ec.numere[i + 1] > 100)
                        {
                            ec.numere[i + 1] = ec.numere[i] / 10;
                        }
                        if (ec.numere[i] > 10)
                        {
                            ec.numere[i] = ec.numere[i] / 10;
                        }

                        ok = 1;
                    }
                }

                if (ok == 1)
                {
                    //verific rezultatul
                    double rezultat = calculareRezultat(ec.returnareRezultat());
                    if (rezultat >= 0 && rezultat < 1000 && rezultat % 2 == 0)
                    {
                        ok = 1;
                        ec.rezultat = Convert.ToInt32(rezultat);
                    }
                    else
                    {
                        ok = 0;
                    }
                }
                Console.WriteLine("Combinatia " + ec.returnareRezultat() + " a picat");
                //Console.ReadKey();
                Console.WriteLine("incerc");
                if (ok == 1)
                {
                    break;
                   
                }
            }
        }
        Console.WriteLine(ec.returnareRezultat());
        return ec.returnareRezultat();
        //File.AppendAllText(@"C:\Users\Tudor\Desktop\test.txt", ec.returnareRezultat() + Environment.NewLine);
    }
}
