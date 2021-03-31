using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffItemStatus : MonoBehaviour
{
    ShowItemStatus A;
    private void Start() {
        A = GetComponent<ShowItemStatus>();
    }
    void Update()
    {
        if(Input.GetMouseButton(0)){
            A.Panel.SetActive(false);

            this.enabled = false;
        }
    }
}
