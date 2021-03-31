using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InClassMoveItems : MonoBehaviour
{
    public RectTransform A, B;
    public Scrollbar C;
    public float speed;
     float Y;
    float Y_;
    float MegaY;
    void Start()
    {
        Y = A.transform.position.y - B.transform.position.y;
        MegaY = B.transform.position.y + Y;
        Y_ = 2 * Y;
    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (C.value > 0)
            {
                C.value -= speed;
                if (C.value < 0)
                {
                    C.value = 0;
                }
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (C.value < 1)
            {
                C.value += speed;
                if (C.value > 1)
                {
                    C.value = 1;
                }
            }
        }
    }
    public void Change()
    {
        B.transform.position = new Vector3(B.transform.position.x, MegaY + (2 * Y * C.value - Y), 0);
    }
}
