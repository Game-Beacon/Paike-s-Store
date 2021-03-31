using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupBlocks : MonoBehaviour
{
    public GManager A;
    public GameObject[] _0;
    public GameObject[] _90;
    public GameObject[] _180;
    public GameObject[] _270;
    GameObject[] BB;
    public bool Check()
    {
        switch (this.transform.eulerAngles.z)
        {
            case 0:
                BB = _0;
                break;
            case 90:
                BB = _90;
                break;
            case 180:
                BB = _180;
                break;
            case 270:
                BB = _270;
                break;
        }
        foreach(var i in BB){
            foreach(var j in A.Now.Panels){
                if(Vector3.Distance(i.transform.position, j.transform.position) <= 20){
                    if(j.GetComponent<PanelStatus>().Used){
                        return false;
                    }
                }
            }
        }
        return true;
    }
}
