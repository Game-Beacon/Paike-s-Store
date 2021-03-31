using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPanel : MonoBehaviour
{
    public int a;
    public Image I;
    public Text t;
    public GameObject A;
    public TextManager tm;
    public ShotCutInGame shot;
    public float speed;
    public GameObject Next;
    private void Start()
    {
        speed /= 255f;
    }
    private void Update()
    {
        if (a == 1)
        {
            I.color -= new Color(0, 0, 0, speed);
            t.color -= new Color(0, 0, 0, 2 * speed);
            if (I.color.a <= 0)
            {
                shot.enabled = true;
                this.enabled = false;
                if (Next != null)
                {
                    Next.SetActive(!Next.activeInHierarchy);
                }
                A.SetActive(false);
            }
        }
        else
        {
            I.color += new Color(0, 0, 0, speed);
            t.color += new Color(0, 0, 0, 2 * speed);
            if (I.color.a >= 0.9f)
            {
                tm.SetText();
                this.enabled = false;
            }
        }
    }
}
