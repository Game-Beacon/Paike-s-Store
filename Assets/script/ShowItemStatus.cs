using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowItemStatus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Panel;
    OffItemStatus A;

    private void Start()
    {
        A = GetComponent<OffItemStatus>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Panel.SetActive(true);
        A.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Panel.SetActive(false);
        A.enabled = false;
    }
}
