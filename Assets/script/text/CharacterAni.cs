using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAni : MonoBehaviour
{
    public Transform Pos1;
    public Transform Pos2;
    public float speed;
    public int a = 0;
    Image A;
    public string noready;
    public string ready;
    void Start()
    {
        A = this.GetComponent<Image>();
    }
    void Update()
    {
        // switch (a)
        // {
        //     case 0:
        //         transform.position += new Vector3(0, speed, 0);
        //         if (transform.position.y >= Pos1.position.y)
        //         {
        //             a = 1;
        //         }
        //         break;
        //     case 1:
        //         transform.position -= new Vector3(0, speed, 0);
        //         if (transform.position.y <= Pos2.position.y)
        //         {
        //             a = 10;
        //         }
        //         break;

        // }
        transform.eulerAngles += new Vector3(0, speed, 0);
        if (transform.eulerAngles.y > 0 && transform.eulerAngles.y < 10)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            this.enabled = false;
        }
    }
}
