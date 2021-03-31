using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toumingdianji : MonoBehaviour
{
    public Image[] A;
    void Awake()
    {
        foreach (var i in A)
        {
            i.alphaHitTestMinimumThreshold = 0.1f;
        }
    }

}
