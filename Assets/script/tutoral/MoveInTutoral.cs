using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MoveInTutoral : MonoBehaviour
{
    bool a = false;
    public GameObject[] P;
    public Flowchart F;
    void Update()
    {
        if (!a)
        {
            foreach (var i in P)
            {
                if (i.GetComponent<PanelStatus>().Used == true)
                {
                    a = true;
                }
            }
        }
        else
        {
            F.ExecuteBlock("4");
            Destroy(this);
        }
    }
    public void Dest()
    {
        Debug.Log("002");
        Destroy(this);
        Debug.Log("001");
    }
    public void DestThisSc()
    {
        Debug.Log("002");
        Destroy(this);
        Debug.Log("001");
    }
}
