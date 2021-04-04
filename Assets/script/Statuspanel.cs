using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Statuspanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int a;
     public void OnPointerEnter(PointerEventData eventData)
    {
        a = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        a = 0;
    }
}
