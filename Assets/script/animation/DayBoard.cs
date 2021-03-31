using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayBoard : MonoBehaviour
{
    public float speed;
    public float targetcount;
    public GameObject Targetpos;
    public GameObject HomePos;
    public List<GameObject> A = new List<GameObject>();
    public GManager B;
    float count = 0;
    int a = 1;
    void Update()
    {
        switch (a)
        {
            case 1:
                transform.position -= new Vector3(0, speed, 0);
                if (transform.position.y <= Targetpos.transform.position.y)
                {
                    transform.position = Targetpos.transform.position;
                    a = 2;
                }
                break;
            case 2:
                count += Time.deltaTime;
                if (count >= targetcount)
                {
                    count = 0;
                    a = 3;
                }
                break;
            case 3:
                transform.position += new Vector3(0, speed, 0);
                if (transform.position.y >= HomePos.transform.position.y)
                {
                    transform.position = HomePos.transform.position;
                    a = 1;
                    foreach (var i in A)
                    {
                        i.SetActive(!i.activeInHierarchy);
                    }
                    foreach (var i in B.NPC[PlayerPrefs.GetInt("day") - 1].NPC)
                    {
                        i.SetActive(true);
                    }
                    this.gameObject.SetActive(false);
                }
                break;
        }

    }
}
