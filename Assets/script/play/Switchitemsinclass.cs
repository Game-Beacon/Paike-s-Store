using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switchitemsinclass : MonoBehaviour
{
    public GameObject ThisItems;
    public GameObject NoneThisItems1;
    public GameObject NoneThisItems2;
    public Sprite  nonclick;
    public Sprite Click;
    public Image This;
    public Image NoThis1;
    public Image NoThie2;
    public void Clicked(){
        NoThis1.gameObject.GetComponent<Switchitemsinclass>().Change(false);
        NoThie2.gameObject.GetComponent<Switchitemsinclass>().Change(false);
        Change(true);
        ThisItems.SetActive(true);
        NoneThisItems1.SetActive(false);
        NoneThisItems2.SetActive(false);
    }
    public void Change(bool a){
        if(a){
            This.sprite = Click;
        }else{
            This.sprite = nonclick;
        }
    }

}
