using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public Transform Pos1;
    public Transform Pos2;
    public float speed;
    public float speed2;
    public TextManager SD;
    int a = 0;
    Image A;
    void Start()
    {
        A = this.GetComponent<Image>();
    }
    void Update()
    {
        switch (a)
        {
            case 0:
                transform.position += new Vector3(0, speed, 0);
                if (transform.position.y >= Pos1.position.y)
                {
                    a = 1;
                }
                break;
            case 1:
                transform.position -= new Vector3(0, speed, 0);
                if (transform.position.y <= Pos2.position.y)
                {
                    SD.PictureOver();
                    a = 10;
                }
                break;
            case 2:
                A.color -= new Color(0, 0, 0, speed2 / 255f);
                if (A.color.a <= 0)
                {
                    A.color += new Color(0, 0, 0, 1);
                }
                break;

        }
        if (transform.GetSiblingIndex() != 4)
        {
            A.color = new Color(0.3f, 0.3f, 0.3f, 1);
        }
        else
        {
            A.color = new Color(1, 1, 1, 1);
        }
    }
}
