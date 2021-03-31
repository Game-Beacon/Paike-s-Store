using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Buttonmoveupdown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        a = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        a = -1;
    }

    int a = 0;
    public float target;
    public float speed;
    private void Start()
    {
        target = transform.position.y + 10;
    }
    private void Update()
    {
        switch (a)
        {
            case 1:
                transform.position += new Vector3(0, speed, 0);
                if (transform.position.y >= target)
                {
                    transform.position = new Vector3(this.transform.position.x, target, 0);
                    a = 0;
                }
                break;
            case -1:
                transform.position -= new Vector3(0, speed, 0);
                if (transform.position.y <= target - 10)
                {
                    transform.position = new Vector3(this.transform.position.x, target - 10, 0);
                    a = 0;
                }
                break;
        }
    }

}
