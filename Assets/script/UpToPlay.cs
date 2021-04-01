using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpToPlay : MonoBehaviour, IPointerUpHandler
{
    public AudioSource A;
    public void OnPointerUp(PointerEventData eventData){
        A.Play();
    }
}
