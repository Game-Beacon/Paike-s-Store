using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartMenu : MonoBehaviour
{
    static AsyncOperation PlayScene;
    public BlackMoku Black;
    public string scenename;
    public SoungVakue A;
    void Start()
    {

    }
    public void Play()
    {
        A.enabled = true;
        Black.namee = "Game";
        Black.UseSlid = true;
        Black.gameObject.SetActive(true);
        Black.enabled = true;
    }

    public void Test()
    {
        Debug.Log("001");
    }
    public void T()
    {
        A.enabled = true;
        PlayerPrefs.SetInt("day", 0);
        Black.namee = "Tutoral 1";
        PlayerPrefs.SetInt("see", 1);
        Black.UseSlid = true;
        Black.gameObject.SetActive(true);
        Black.enabled = true;
    }

    public void Load()
    {
        if(PlayerPrefs.GetInt("day") ==0){
            T();
        }else{
            Play();
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void Option()
    {
        Black.namee = "Option";
        Black.gameObject.SetActive(true);
        Black.enabled = true;
        Black.UseSlid = false;
    }
}
