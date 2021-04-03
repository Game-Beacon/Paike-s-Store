using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackLetter : MonoBehaviour
{
    GManager A;
    public Image Letter;
    public List<Sprite> texts = new List<Sprite>();
    int a = 0;
    public BlackMokuOver Black;
    public GameObject Panel;
    public GameObject Board;
    public GameObject Over;
    List<string> item = new List<string>();
    public Text B;
    void Awake()
    {
        A = GetComponent<GManager>();
        texts = A.BackLetter();
        item = A.GetUnlockItem();
        Panel.SetActive(true);
        Letter.sprite = texts[a];
        B.text = "解鎖物品: " + item[a];
        for (int i = 0; i < A.day; i++)
        {
            for (int j = 0; j < A.Lev[i].Characters.Count; j++)
            {
                foreach (var k in A.Lev[i].Characters[j].Letters[PlayerPrefs.GetInt("day" + i + "count" + j)].UnlockItem)
                {
                    k.SetActive(true);
                }
                foreach (var k in A.Lev[i].Characters[j].Letters[PlayerPrefs.GetInt("day" + i + "count" + j)].UnlockMap)
                {
                    k.SetActive(true);
                }
            }
        }
        Black.enabled = true;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Click();
        }
    }
    public void Click()
    {
        a++;
        if (a >= texts.Count)
        {


            if (PlayerPrefs.GetInt("day") == 4)
            {
                Over.SetActive(true);
            }
            else
            {
                Board.SetActive(true);
            }
            Panel.SetActive(false);
            Destroy(this);
        }
        else
        {
            Letter.sprite = texts[a];
            B.text = "解鎖物品: " + item[a];
        }
    }
}
