using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameObject hinthand;
    public GameObject hintblack;

    public TextMeshProUGUI hakemname;

    //winmenu

    public GameObject winmenu;
    public GameObject blackscreen1;
    public GameObject textwin;
    public GameObject kupa1;
    public GameObject kupa2;
    public GameObject kupa3;
    public GameObject diamond;
    public GameObject diamondtext;
    public GameObject ticket;
    public GameObject tickettext;
    public GameObject nextlevel;
    public GameObject nothanks;

    //drawmenu

    public GameObject winmenu2;
    public GameObject blackscreen2;
    public GameObject textwin2;
    public GameObject kupa1_2;
    public GameObject kupa3_2;
    public GameObject diamond2;
    public GameObject diamondtext2;
    public GameObject ticket2;
    public GameObject tickettext2;
    public GameObject nextlevel2;
    public GameObject nothanks2;

    //losemenu

    public GameObject winmenu3;
    public GameObject blackscreen3;
    public GameObject textwin3;
    public GameObject kupa1_3;
    public GameObject diamond3;
    public GameObject diamondtext3;
    public GameObject nextlevel3;
    public GameObject nothanks3;

    public void Start()
    {
        RandomHakemName();

    }
    public void SinglePlayerSceneTransiction()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MainMenuSceneTransiction()
    {
        SceneManager.LoadScene("Menu");
    }

    public void FirstTouchThanDisappear()
    {
        hinthand.SetActive(false);
        hintblack.SetActive(false);
    }

    public void FinishWinStartfunc()
    {
        StartCoroutine(FinishWinStart());
    }

    public void FinishDrawStartfunc()
    {
        StartCoroutine(FinishDrawStart());
    }

    public void FinishLoseStartfunc()
    {
        StartCoroutine(FinishLoseStart());
    }

    public void RandomHakemName()
    {
        string[] biomes = new string[] { "Jackie", "Jacob", "Tony", "Matthew", "Scoty", "David" };
        System.Random random = new System.Random();
        int useBiome = random.Next(biomes.Length);
        string pickBiome = biomes[useBiome];
        hakemname.text = pickBiome.ToString();
    }

    public IEnumerator FinishWinStart()
    {
        winmenu.SetActive(true);
        blackscreen1.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        textwin.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa1.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa3.SetActive(true);
        yield return new WaitForSecondsRealtime(0.7f);
        diamond.SetActive(true);
        diamondtext.SetActive(true);
        ticket.SetActive(true);
        tickettext.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        nextlevel.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        nothanks.SetActive(true);
    }

    public IEnumerator FinishDrawStart()
    {
        winmenu2.SetActive(true);
        blackscreen2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        textwin2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa1_2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa3_2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.7f);
        diamond2.SetActive(true);
        diamondtext2.SetActive(true);
        ticket2.SetActive(true);
        tickettext2.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        nextlevel2.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        nothanks2.SetActive(true);
    }


    public IEnumerator FinishLoseStart()
    {
        winmenu3.SetActive(true);
        blackscreen3.SetActive(true);
        yield return new WaitForSecondsRealtime(0.1f);
        textwin3.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        kupa1_3.SetActive(true);
        yield return new WaitForSecondsRealtime(0.7f);
        diamond3.SetActive(true);
        diamondtext3.SetActive(true);
        yield return new WaitForSecondsRealtime(0.3f);
        nextlevel3.SetActive(true);
        yield return new WaitForSecondsRealtime(4f);
        nothanks3.SetActive(true);
    }
}
