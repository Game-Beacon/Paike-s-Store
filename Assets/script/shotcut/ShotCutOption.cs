using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotCutOption : MonoBehaviour
{
    public BlackMoku black;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }
    public void Back()
    {
        black.gameObject.SetActive(true);
        black.namee = "MainMenu";
        black.enabled = true;
        black.UseSlid = false;
    }
}
