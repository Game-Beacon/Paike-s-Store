using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickToSay : MonoBehaviour, IPointerClickHandler
{
    public Flowchart A;
    public string None;
    public Button Table;
    public void Click()
    {
        A.ExecuteBlock(None);

        this.GetComponent<Button>().interactable = true;
        Table.interactable = true;
        Destroy(this);

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        A.ExecuteBlock(None);
        this.GetComponent<Button>().interactable = true;
        Table.interactable = true;
        Destroy(this);
    }
}
