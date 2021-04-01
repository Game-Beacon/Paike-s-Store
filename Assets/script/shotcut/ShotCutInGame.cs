using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotCutInGame : MonoBehaviour
{
    public BlackMoku Black;
    public GManager G;
    public GameObject[] Panels;
    public GameObject Pusepanel;
    public GManager A;
    public GameObject Optionpanel;
    public SoungVakue B;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Back();
        }
    }
    public void Back()
    {
        for (int i = 0; i < Panels.Length; i++)
        {
            if (Panels[i].activeInHierarchy)
            {
                A.Closepanel(Panels[i]);
                return;
            }
        }
        if(Optionpanel.activeInHierarchy){
            Pause(2);
            return;
        }
        Pause(1);
    }
    public void Pause(int a)
    {
        if (a == 1)
        {
            Pusepanel.SetActive(!Pusepanel.activeInHierarchy);
        }
        else
        {
            Optionpanel.SetActive(!Optionpanel.activeInHierarchy);
        }
        Time.timeScale = 1 - Time.timeScale;
    }
    public void BackToMenu()
    {
        B.enabled = true;
        Time.timeScale = 1;
        Black.namee = "MainMenu";
        Black.UseSlid = false;
        Black.gameObject.SetActive(true);
        Black.enabled = true;
    }
}
