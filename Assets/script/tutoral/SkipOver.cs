using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipOver : MonoBehaviour
{
    public GameObject A;
    void Start()
    {
        A.SetActive(false);
        Destroy(this);
    }

}
