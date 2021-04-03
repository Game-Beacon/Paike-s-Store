using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deesheeguilgeh : MonoBehaviour
{
    public Transform Target;
    public float targettime;
    float speed;
    void Start()
    {
        speed = Target.position.y - this.transform.position.y;
        speed /= targettime;
    }

    void Update()
    {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        if (transform.position.y > Target.position.y)
        {
            this.enabled = false;
        }
    }
}
