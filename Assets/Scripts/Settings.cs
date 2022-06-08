using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameObject Soundbut;
    public GameObject NoSoundbut;
    //Username kismi yazilmadi. Sunucuda id olusturmasina göre eklenicek

    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
    public void privacy_policy()
    {
        Application.OpenURL("https://www.izysoft.net/rolling-privacy");
    }

    public void term_of_use()
    {
        Application.OpenURL("https://www.izysoft.net/rolling-terms");
    }

    public void Settingbutton()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            AudioListener.volume = 1;
            Soundbut.SetActive(true);
            NoSoundbut.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            AudioListener.volume = 0;
            Soundbut.SetActive(false);
            NoSoundbut.SetActive(true);
        }
    }
    public void Soundbutton()
    {
        Soundbut.SetActive(false);
        NoSoundbut.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);

    }

    public void NoSoundbutton()
    {
        Soundbut.SetActive(true);
        NoSoundbut.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);

    }

}
