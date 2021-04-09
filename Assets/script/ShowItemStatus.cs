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
    public int exit = 0;
    [ContextMenu("A")]
    public void ABCD()
    {
        if (Panel.GetComponent<Statuspanel>() == null)
        {
            Panel.AddComponent<Statuspanel>();
        }
        else
        {
            Debug.Log("001");
        }
    }
   public  Statuspanel S;
    private void Start()
    {
        A = GetComponent<OffItemStatus>();
        S = Panel.GetComponent<Statuspanel>();
        Now = Panel.transform.parent;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            exit = 1;
            Panel.SetActive(true);
            Panel.transform.parent = Show;
            A.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        exit = 0;
    }


    public void Off()
    {
        Panel.SetActive(false);
        Panel.transform.parent = Now;
        A.enabled = false;
    }
}
