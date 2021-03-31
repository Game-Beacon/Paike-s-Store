using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour
{
    public string text;
    public Text t;
    string a = "";
    public float textspeed;
    float count = 0;
    int b = 0;
    void Update()
    {
        count += Time.deltaTime;
        if (count >= textspeed)
        {
            if (b < text.Length)
            {
                count = 0;
                a += text[b];
                b++;
                t.text = a;
            }
            else
            {
                Res();
            }

        }
    }

    public void Res()
    {
        count = 0;
        b = 0;
        a = "";
        this.enabled = false;
    }

}
