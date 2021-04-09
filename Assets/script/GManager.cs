using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Fungus;

public class GManager : MonoBehaviour
{
    public BlackMoku AAA;
    public Text t;
    public int day;
    public List<Levels> Lev = new List<Levels>();
    Levels L;
    public List<int> Item = new List<int>();
    int nowchara = 0;
    public List<int> score;
    public Button Table;
    public List<SCORE_DESU> MainScore = new List<SCORE_DESU>();
    public Flowchart A;
    public Text OVER;

    public GameObject Used;
    public People Now;
    public List<Members> NPC = new List<Members>();
    public Sprite[] DayB;
    public Image Board;
    public GameObject Tablepanel;

    private void Awake()
    {
        day = PlayerPrefs.GetInt("day");
        if (day != 0)
        {
            Board.sprite = DayB[day - 1];
        }
        L = Lev[day];
        L.Characters[nowchara].Have(Item);
        Now = L.Characters[nowchara];
        int d = day > 0 ? day - 1 : 0;
        // foreach (var i in NPC[d].NPC)
        // {
        //     i.SetActive(true);
        // }
    }
    public Statuspanel[] S;
    public void TimeOver()
    {
        L.Characters[nowchara].IsFailed = true;
        L.Characters[nowchara].SetFailed(day, nowchara);
        MainScore.Add(new SCORE_DESU());
        MainScore[MainScore.Count - 1].Set(0, 0);
        Table.interactable = false;
        Closepanel(Tablepanel);
        foreach (var i in S)
        {
            i.gameObject.SetActive(false);
            i.a = 0;
        }
        A.ExecuteBlock(L.Characters[nowchara].timeouttxt);

    }

    public void SwitchPanel(int a)
    {
        L.Characters[nowchara].TPan1.SetActive(a == 1 ? true : false);
        L.Characters[nowchara].TPan2.SetActive(a == 1 ? false : true);
        L.Characters[nowchara].Pan = a;
    }
    public TimeCount T;
    public void OverBag(GameObject A)
    {
        T.gameObject.SetActive(false);
        switch (L.Characters[nowchara].SpecialCode)
        {
            case 1:
                score = L.Characters[nowchara].CheckSpecialItemHave(Item);
                break;
            case 2:
                score = L.Characters[nowchara].HoosonZai(L.Characters[nowchara].Panels, Item);
                break;
            case 3:
                score = L.Characters[nowchara].DeerDarahgui(L.Characters[nowchara].Used, Item);
                break;
        }
        L.Characters[nowchara].SetFailed(day, nowchara);
        MainScore.Add(new SCORE_DESU());
        MainScore[MainScore.Count - 1].Set(score[0], score[1]);
        Table.interactable = false;
        Closepanel(A);
    }
    public void Closepanel(GameObject A)
    {

        A.SetActive(false);
    }
    public SoungVakue AA;
    public void ClearDay()
    {
        AA.enabled = true;
        day++;
        PlayerPrefs.SetInt("see", 1);
        PlayerPrefs.SetInt("day", day);
        AAA.namee = "Game";
        AAA.UseSlid = true;
        AAA.enabled = true;
        AAA.gameObject.SetActive(true);
    }
    public void ClickChara(CharacterAni BBB)
    {
        A.ExecuteBlock(Table.interactable ? BBB.noready : BBB.ready);
    }
    public GameObject OverPanel;
    public Text Niithun;
    public Text Yvlsanhun;
    public Text Hojigdsonhun;
    public GameObject RestartButn;
    public GameObject NextButn;
    public Sprite ylsan;
    public Sprite ylaagui;
    public Image[] Onoo;
    public void RestoreTable()
    {
        L.Characters[nowchara].Table.SetActive(false);
        nowchara++;
        if (nowchara >= L.Characters.Count)
        {
            //Over
            OverPanel.SetActive(true);
            int clear = 0;
            for (int i = 0; i < L.Characters.Count; i++)
            {
                if (!L.Characters[i].IsFailed)
                {
                    clear++;
                }
                Onoo[i].sprite = L.Characters[i].IsFailed ? ylaagui : ylsan;
                Onoo[i].color = new Color(1, 1, 1, 1);
            }
            // int golscore = 0;
            // int evscore = 0;
            // foreach (var i in MainScore)
            // {
            //     golscore += i.Score;
            //     evscore += i.Bonus;
            // }

            //OVER.text = "營業結束" + "\r\n" + "縂客人數: " + L.Characters.Count + "\r\n" + "成功人數: " + clear + "\r\n" + "失敗人數: " + (L.Characters.Count - clear) + "\r\n" + "基礎分數: " + golscore + "\r\n" + "附加分數: " + evscore + "\r\n" + "總分數: " + (golscore + evscore);
            //   Niithun.text = L.Characters.Count.ToString();
            //    Yvlsanhun.text = clear.ToString();
            //  Hojigdsonhun.text = (L.Characters.Count - clear).ToString();
            if (clear != L.Characters.Count)
            {
                RestartButn.SetActive(true);
            }
            else
            {
                NextButn.SetActive(true);
            }
            // PlayerPrefs.SetInt("day" + day, (golscore + evscore));
            return;
        }
        L.Characters[nowchara].Table.SetActive(true);
        Item.Clear();
        L.Characters[nowchara].Have(Item);
        Now = L.Characters[nowchara];
    }

    public void Restartgame()
    {
        AA.enabled = true;
        AAA.namee = "Game";
        AAA.UseSlid = true;
        AAA.enabled = true;
        AAA.gameObject.SetActive(true);
    }


    public List<Sprite> BackLetter()
    {
        List<Sprite> a = new List<Sprite>();
        for (int i = 0; i < Lev[day - 1].Characters.Count; i++)
        {
            a.Add(Lev[day - 1].Characters[i].GetLitterText(day - 1, i));
        }
        return a;
    }
    public List<string> GetUnlockItem()
    {
        List<string> a = new List<string>();
        for (int i = 0; i < Lev[day - 1].Characters.Count; i++)
        {
            a.Add(Lev[day - 1].Characters[i].GetUnlockItem(day - 1, i));
        }
        return a;
    }

}

[System.Serializable]
public class SCORE_DESU
{
    public int Score;
    public int Bonus;
    public void Set(int score, int bonus)
    {
        this.Score = score;
        this.Bonus = bonus;
    }
}
[System.Serializable]
public class Members
{
    public List<GameObject> NPC = new List<GameObject>();
}

