using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSort : MonoBehaviour
{
    public GameObject[] Items;
    List<int> a = new List<int>();
    List<Vector2> pos = new List<Vector2>();
    private void Start()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            a.Add(i);
            pos.Add(Items[i].transform.position);
        }
        List<int> b = new List<int>();

        while (a.Count > 0)
        {
            int x = Random.Range(0, a.Count);
            b.Add(a[x]);
            a.RemoveAt(x);
        }
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].transform.position = pos[b[i]];
        }


    }
}
