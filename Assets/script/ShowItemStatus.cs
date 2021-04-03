using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowItemStatus : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject Panel;
    OffItemStatus A;
    public Transform Show;
    public Transform Now;
    Vector3 B;

    private void Start()
    {
        A = GetComponent<OffItemStatus>();
        Now = Panel.transform.parent;
        //B = Panel.transform.position - this.transform.position;
        B = new Vector3(120, -160, 0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            Panel.transform.position = B + this.transform.position;
            Panel.SetActive(true);
            Panel.transform.parent = Show;
            A.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Off();
    }


    public void Off()
    {
        Panel.SetActive(false);
        Panel.transform.parent = Now;
        A.enabled = false;
    }
}
