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
    void Awake()
    {
        A = GetComponent<GManager>();
        texts = A.BackLetter();
        Panel.SetActive(true);
        Letter.sprite = texts[a];
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

            Board.SetActive(true);
            Panel.SetActive(false);
            Destroy(this);
        }
        else
        {
            Letter.sprite = texts[a];
        }
    }
}
