using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Statuspanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int a;
    RectTransform V;
    public Vector3 pos;
    Vector3 m;
    private void Start() {
        
        V = GetComponent<RectTransform>();
        m = new Vector3(V.sizeDelta.x / 2, -V.sizeDelta.y / 2, 0);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        a = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        a = 0;
    }
    private void Update()
    {
        this.transform.position = Input.mousePosition + pos + m;
    }
}
