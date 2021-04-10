using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Statuspanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int a;
    RectTransform V;
    public Vector3 pos;
    public Vector3 m;
    int b = 0;
    private void Start()
    {
        if (b == 0)
        {
            V = GetComponent<RectTransform>();
            m = new Vector3(V.sizeDelta.x * Camera.main.pixelWidth / 1920 / 2, -V.sizeDelta.y * Camera.main.pixelHeight / 1080 / 2, 0);
            pos = new Vector3(pos.x * Camera.main.pixelWidth / 1920, pos.y * Camera.main.pixelHeight / 1080, 0);
            b = 1;
        }
    }
    public void A()
    {
        if (b == 0)
        {
            V = GetComponent<RectTransform>();
            m = new Vector3(V.sizeDelta.x * Camera.main.pixelWidth / 1920 / 2, -V.sizeDelta.y * Camera.main.pixelHeight / 1080 / 2, 0);
            b = 1;
            pos = new Vector3(pos.x * Camera.main.pixelWidth / 1920, pos.y * Camera.main.pixelHeight / 1080, 0);
        }
        this.transform.position = Input.mousePosition + pos + m;
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
