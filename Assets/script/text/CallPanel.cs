using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPanel : MonoBehaviour
{
    public List<Texts> texts = new List<Texts>();
    public ShotCutInGame ShotCut;
    public TextManager textManager;
    public void Call(){
        ShotCut.enabled = false;
        textManager.texts = texts;
        textManager.gameObject.SetActive(true);
        textManager.Star();
    }
}
