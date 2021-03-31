using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public List<Texts> texts = new List<Texts>();
    public int page = 0;
    public ShowText Show;
    public TextPanel tp;
    bool canfast = false;
    private void Start()
    {
        Star();
    }
    public void Star()
    {
        page = 0;
        tp.a = 0;
        tp.enabled = true;
        Show.t.text = "";
        if (!texts[0].Ani)
        {
            canfast = true;
        }
}
    public void Click()
    {
        if (Show.enabled)
        {
            Show.enabled = false;
            Show.t.text = Show.text;
            Show.Res();
        }
        else
        {
            page++;
            if (page >= texts.Count)
            {
                tp.a = 1;
                tp.enabled = true;
            }
            else
            {
                SetText();
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canfast)
        {
            if (Show.enabled)
            {
                Show.enabled = false;
                Show.t.text = Show.text;
                Show.Res();
            }
            else
            {
                page++;
                if (page >= texts.Count)
                {
                    tp.a = 1;
                    tp.enabled = true;
                }
                else
                {
                    SetText();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
    public void SetText()
    {
        if (texts[page].Ani == false)
        {
            texts[page].Set();

            string a;
            switch (PlayerPrefs.GetString("languages"))
            {
                case "zh":
                    a = texts[page].zh;
                    break;
                default:
                    a = texts[page].zh;
                    break;
            }
            Show.text = a;
            Show.enabled = true;
        }
        else if (!texts[page].Isover)
        {
            texts[page].A.SetActive(true);
            texts[page].A.transform.SetAsLastSibling();
        }
        else
        {
            page++;
            SetText();
        }
    }

    public void PictureOver()
    {
        texts[page].Isover = true;
        canfast = true;
        page++;
        if (page >= texts.Count)
        {
            tp.a = 1;
            tp.enabled = true;
        }
        else
        {
            SetText();
        }
    }

    public void Close()
    {
        tp.a = 1;
        page = 0;
        tp.enabled = true;
    }
}

[Serializable]
public class Texts
{
    public bool Ani;
    public string zh;
    public string en;
    public GameObject A;
    public string name;
    public Text nametext;
    public Text Othernametext;
    public bool Isover;
    public void Set()
    {
        nametext.text = name;
        Othernametext.text = "";
        A.transform.SetAsLastSibling();
    }
}
