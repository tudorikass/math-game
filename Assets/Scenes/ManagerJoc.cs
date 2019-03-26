using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class ManagerJoc : MonoBehaviour
{
   
    private static ManagerExercitii manager;

    [SerializeField]
    private Text Ecuatie;

   
    private static int DificultateSemne;

   
    private static int DificultateNumere;

    [SerializeField]
    private Text ButonStangaSus;

    [SerializeField]
    private Text ButonStangaJos;

    [SerializeField]
    private Text ButonDreaptaSus;

    [SerializeField]
    private Text ButonDreaptaJos;

    [SerializeField]
    private int ValoareCorecta;


    [SerializeField]
    private float TimeBetweenQuestions = 1f;



    // Start is called before the first frame update
    void Start()
    {
        if (manager == null)
        {
            Debug.Log("TEST");
            manager = new ManagerExercitii();
            DificultateSemne = 2;
            DificultateNumere = 2;
        }
        Debug.Log("DifNR "+DificultateNumere);
        Debug.Log("DifSemne " + DificultateSemne);
        string ex =manager.generareExecitiu(DificultateNumere, DificultateSemne);
        
        Ecuatie.text = ex;
        int[] rex = { 0, 0, 0, 0 };
        rex = manager.ReturnareOptiuniRezultat(ex);
        ValoareCorecta = rex[3];

        new System.Random().Shuffle(rex);
        ButonStangaSus.text = rex[0].ToString();
        ButonStangaJos.text = rex[1].ToString();
        ButonDreaptaSus.text = rex[2].ToString();
        ButonDreaptaJos.text = rex[3].ToString();

    }

    public void AlegereButonStangaSus()
    {
        if (Convert.ToInt32(ButonStangaSus.text) == ValoareCorecta)
        {
            Debug.Log("ok");
            DificultateNumere += 1;
            DificultateSemne += 1;
            StartCoroutine(RaspunsCorectSchimbareLaUrmatoareaIntrebare());
        }
    }

    public void AlegereButonDreaptaSus()
    {
        if (Convert.ToInt32(ButonDreaptaSus.text) == ValoareCorecta)
        {
            Debug.Log("ok");
            DificultateNumere += 1;
            DificultateSemne += 1;
            StartCoroutine(RaspunsCorectSchimbareLaUrmatoareaIntrebare());
        }
    }
    public void AlegereButonStangaJos()
    {
        if (Convert.ToInt32(ButonStangaJos.text) == ValoareCorecta)
        {
            Debug.Log("ok");
            DificultateNumere += 1;
            DificultateSemne += 1;
            StartCoroutine(RaspunsCorectSchimbareLaUrmatoareaIntrebare());
        }
    }
    public void AlegereButonDreaptaJos()
    {
        if (Convert.ToInt32(ButonDreaptaJos.text) == ValoareCorecta)
        {
            Debug.Log("ok");
            DificultateNumere += 1;
            DificultateSemne += 1;
            StartCoroutine(RaspunsCorectSchimbareLaUrmatoareaIntrebare());
        }
    }


    IEnumerator RaspunsCorectSchimbareLaUrmatoareaIntrebare()
    {
        yield return new WaitForSeconds(TimeBetweenQuestions);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
