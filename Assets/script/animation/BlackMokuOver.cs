using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackMokuOver : MonoBehaviour
{
    Image A;
    public float Speed;
    public float TargetTime;
    public GameObject[] objects;

    void Start()
    {
        A = GetComponent<Image>();
        Speed = 1 / TargetTime;
    }

    private void Update()
    {
        A.color -= new Color(0, 0, 0, Speed * Time.deltaTime);
        if (A.color.a <= 0)
        {
            foreach (GameObject i in objects)
            {
                i.SetActive(true);
            }
            A.color = new Color(0, 0, 0, 0);
            this.gameObject.SetActive(false);
            this.enabled = false;
        }
    }



}
