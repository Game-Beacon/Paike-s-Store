using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTestLanguages : MonoBehaviour
{
    Text A;
    [TextArea]
    public string zh;


    private void Awake()
    {
        A = GetComponent<Text>();
        switch (PlayerPrefs.GetString("languages"))
        {
            case "zh":
                A.text = zh;
                break;
            default:
                A.text = zh;
                break;
        }
    }
}
