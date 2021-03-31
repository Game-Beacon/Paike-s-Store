using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soundvalueset : MonoBehaviour
{
    Slider A;
    public string na;
    public SoungVakue B;
    public SoungVakue[] C;
    public bool ismusic = true;
    void Start()
    {
        A = GetComponent<Slider>();
        A.value = PlayerPrefs.GetFloat(na);

    }
    public void Changed()
    {
        PlayerPrefs.SetFloat(na, A.value);
        if (ismusic)
        {
            B.Change();
        }
        else
        {
            foreach (var i in C)
            {
                i.Change();
            }
        }

    }

}
