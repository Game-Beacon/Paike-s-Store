using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource A;
    public void OnPointerEnter(PointerEventData eventData)
    {
        A.Play();
    }

}
