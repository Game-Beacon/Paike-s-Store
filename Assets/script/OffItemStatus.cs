using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffItemStatus : MonoBehaviour
{
    ShowItemStatus A;
    private void Start()
    {
        A = GetComponent<ShowItemStatus>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            A.Off();

        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            A.Off();
        }
        if (A.exit == 0 && A.S.a == 0)
        {
            A.Off();
        }
    }
}
