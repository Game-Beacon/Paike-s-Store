using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Move : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public List<GameObject> Blocks = new List<GameObject>();
    public List<GameObject> Used = new List<GameObject>();
    public float zai;
    public GameObject UsedItems;
    Vector2 Zuruu;
    public GameObject Home;
    public Transform Pos1, Pos2;
    public GameObject BACKSUP;
    public GManager G;
    public bool ifres = true;
    public int Num;
    public bool Inbag = false;
    public Vector3 Scale;
    public bool NPCsItem = false;
    List<GameObject> Back = new List<GameObject>();
    Vector3 A;
    Vector3 B;
    public AudioSource C;
    public AudioSource D;
    private void Start()
    {
        // GetComponent<Image>().alphaHitTestMinimumThreshold = 0.1f;
        Scale = this.transform.localScale;
        if (NPCsItem)
        {
            Used.Clear();
            Inbag = true;
            foreach (var i in Blocks)
            {
                foreach (var j in G.Now.Panels)
                {
                    if (Vector3.Distance(i.transform.position, j.transform.position) <= 30)
                    {
                        Used.Add(j);
                        j.GetComponent<PanelStatus>().Used = true;
                        break;
                    }
                }
            }

        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Input.GetMouseButtonUp(0))
        {
            Clices = false;

            if (Input.mousePosition.x < Pos2.position.x
                 && Input.mousePosition.x > Pos1.position.x
                 && Input.mousePosition.y > Pos2.position.y
                 && Input.mousePosition.y < Pos1.position.y)
            {

                if (NPCsItem)
                {
                    this.transform.position = A;
                    this.transform.eulerAngles = B;
                    G.Item.Add(Num);
                    Inbag = true;
                    C.Play();
                    foreach (var k in Blocks)
                    {
                        k.GetComponent<Image>().color = new Color(0, 1, 0, 50 / 255f);
                    }
                    foreach (var k in Back)
                    {
                        k.GetComponent<PanelStatus>().Used = true;
                    }
                    Used.AddRange(Back);
                    Back.Clear();
                    return;
                }
                Destroy(this.gameObject);
                return;
            }
            int a = 0;
            for (int i = 0; i < Blocks.Count; i++)
            {
                for (int j = 0; j < G.Now.Panels.Count; j++)
                {
                    if (G.Now.Panels[j].GetComponent<PanelStatus>().Used)
                    {
                        continue;
                    }
                    if (Vector2.Distance(G.Now.Panels[j].transform.position, Blocks[i].transform.position) <= zai)
                    {
                        a++;
                        Used.Add(G.Now.Panels[j]);
                        break;
                    }
                }
                if (a != i + 1)
                {
                    Used.Clear();
                    //  if (NPCsItem)
                    //  {
                    if (A.x < Pos2.position.x
                        && A.x > Pos1.position.x
                        && A.y > Pos2.position.y
                        && A.y < Pos1.position.y)
                    {
                        Destroy(this.gameObject);
                        return;
                    }
                    this.transform.position = A;
                    this.transform.eulerAngles = B;
                    C.Play();
                    Inbag = true;
                    G.Item.Add(Num);
                    foreach (var k in Blocks)
                    {
                        k.GetComponent<Image>().color = new Color(0, 1, 0, 50 / 255f);
                    }
                    foreach (var k in Back)
                    {
                        k.GetComponent<PanelStatus>().Used = true;
                    }
                    Used.Clear();
                    Used.AddRange(Back);
                    Back.Clear();

                    // }
                    return;
                }
            }
            transform.position = Used[0].transform.position + transform.position - Blocks[0].transform.position;
            C.Play();
            foreach (var i in Blocks)
            {
                i.GetComponent<Image>().color = new Color(0, 1, 0, 50 / 255f);
            }
            Inbag = true;
            G.Item.Add(Num);
            foreach (var i in Used)
            {
                i.GetComponent<PanelStatus>().Used = true;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = eventData.position;
            if (Input.mousePosition.x > Pos2.position.x
                 || Input.mousePosition.x < Pos1.position.x
                 || Input.mousePosition.y < Pos2.position.y
                 || Input.mousePosition.y > Pos1.position.y)
            {
                foreach (var i in Blocks)
                {
                    i.GetComponent<Image>().color = new Color(1, 0, 0, 50 / 255f);

                }
                this.transform.localScale = new Vector3(1, 1, 1);
            }
            else if (Input.mousePosition.x < Pos2.position.x
                || Input.mousePosition.x > Pos1.position.x
                || Input.mousePosition.y > Pos2.position.y
                || Input.mousePosition.y < Pos1.position.y)
            {
                foreach (var i in Blocks)
                {
                    i.GetComponent<Image>().color = new Color(0, 0, 0, 0);
                }
                this.transform.localScale = Scale;
            }

        }
    }

    bool Clices = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //  if (NPCsItem)
            //  {
            Back.AddRange(Used);
            // }
            A = this.transform.position;
            B = this.transform.eulerAngles;
            Clices = true;
            foreach (var i in Blocks)
            {
                i.GetComponent<Image>().color = new Color(1, 0, 0, 50 / 255f);
            }
            foreach (var i in Used)
            {
                i.GetComponent<PanelStatus>().Used = false;
            }
            Used.Clear();
            Zuruu = (Vector2)this.transform.position - eventData.position;
            if (ifres)
            {
                BACKSUP = Instantiate(this.gameObject, this.transform.position, transform.rotation, this.transform.parent);
                BACKSUP.GetComponent<Move>().ResetColor();
                ifres = false;
            }
            transform.SetParent(G.Now.Used.transform);
            transform.SetAsLastSibling();
            if (Inbag)
            {
                Inbag = false;
                G.Item.Remove(Num);
            }
        }
    }
    public void ResetColor()
    {
        foreach (var i in Blocks)
        {
            i.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.LeftShift)) && Clices)
        {
            D.Play();
            switch (transform.eulerAngles.z)
            {
                case 0:
                    transform.eulerAngles = new Vector3(0, 0, 270);
                    break;
                case 90:
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 180:
                    transform.eulerAngles = new Vector3(0, 0, 90);
                    break;
                case 270:
                    transform.eulerAngles = new Vector3(0, 0, 180);
                    break;
            }

        }
    }
}
