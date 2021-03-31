using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class MoveHandleCheck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool InSprite;
    public void OnPointerEnter(PointerEventData eventData)
    {
        InSprite = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        InSprite = false;
    }
}
