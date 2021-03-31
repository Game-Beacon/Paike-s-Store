using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeCount : MonoBehaviour
{
    public Text text;
    public float target;
    float time;
    public GManager A;
    private void Start()
    {
        Set();
    }

    public void Set()
    {
        this.gameObject.SetActive(true);
        time = target;
    }

    void Update()
    {
        time -= Time.deltaTime;
        text.text = "0" + (int)(time / 60) + ":" + (time % 60 < 10 ? "0" : "") + (int)(time % 60);
        if (time <= 0)
        {
            A.TimeOver();
            this.gameObject.SetActive(false);
        }
    }
}
