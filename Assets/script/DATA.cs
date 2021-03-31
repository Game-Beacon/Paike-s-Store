using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#region 
/*
    items code
    attack{
        1001 - 斧頭
        1002 - 劍
        1003 - 魔法杖
        1004 - 短劍
        1005 - 鏟子
        1006 - 十字鎬
        1007 - 琴
    }
heal{            
        2001 - 水
        2002 - 飲水
        2003 - 包
        2004 - 回復藥
        2005 - 解毒劑
        2006 - 解毒草
        2007 - 小瓶
        2008 - 大瓶
        2009 - Mu醬油
        2010 - 特里斯卡牛肉乾
        2011 - 白蘭帝國玫瑰花
        2012 - 聖水
        2013 - 魔力回復藥
        2014 - 藍藍土司
        2015 - 藍藍餅乾
        2016 - 藍藍麵包
    }
support{
        3001 - 皇冠
        3002 - 箱子
        3003 - 盾
        3004 - 項鏈
        3005 - 磨刀石
        3006 - 筆
        3007 - 墨
        3008 - 紙
        3009 - 不齊全的森林地圖
        3010 - 不齊全的魔王城地圖
        3011 - 口罩
        3012 - 完整的森林地圖
        3013 - 完整的魔王城地圖
        3014 - 指南針
        3015 - 魔法石
    }
*/

/*
    int ("day0count0") -> 第0天的第0個客人  0 = 失敗: 1 = 成功
    int ("day0") -> 第0天的分數
*/
#endregion
[Serializable]
public class People
{
    public GameObject Chara;
    public string Class;
    public string Name;
    public string Target;
    public List<ItemsAndScore> NeedItem = new List<ItemsAndScore>();
    public List<int> HaveItem = new List<int>();
    public List<int> MegaNeed = new List<int>();
    public List<int> SpecialNeed = new List<int>();
    public List<int> Darahgui = new List<int>();
    public GameObject Used;
    public bool IsFailed;
    public GameObject Table;
    public string timeouttxt;
    public int SpecialCode; // 1 - todorhoi ed zuiltei baih, 2 - Hooson zai, 3 - hool deeree baih
    public int TargetHoosonZai;
    public List<GameObject> Panels = new List<GameObject>();
    public Letter[] Letters = new Letter[2];
    public void Have(List<int> A)
    {
        foreach (var i in HaveItem)
        {
            A.Add(i);
        }
    }
    public List<int> CheckSpecialItemHave(List<int> Items)
    {
        int a = 0;
        int b = 0;
        int score = 0;
        foreach (var i in Items)
        {
            foreach (var j in SpecialNeed)
            {
                if (j == i)
                {
                    a++;
                    break;
                }
            }
            foreach (var j in MegaNeed)
            {
                if (j == i)
                {
                    b++;
                    break;
                }
            }
            foreach (var j in NeedItem)
            {
                if (i == j.Num)
                {
                    score += j.Score;
                    break;
                }
            }
        }
        if (b < MegaNeed.Count)
        {
            IsFailed = true;
        }
        else
        {
            IsFailed = false;
        }
        a = (int)(300f * (float)a / (float)SpecialNeed.Count);
        if (!IsFailed)
        {
            a += 300;
        }
        return new List<int> { a, score };
    }
    public void SetFailed(int day, int count)
    {
        PlayerPrefs.SetInt("day" + day + "count" + count, IsFailed ? 0 : 1);
    }
    public List<int> HoosonZai(List<GameObject> A, List<int> Items)
    {
        int a = 0;
        foreach (var i in A)
        {
            if (!i.GetComponent<PanelStatus>().Used)
            {
                a++;
            }
            if (a >= TargetHoosonZai)
            {
                break;
            }
        }
        int score = 0;
        int b = 0;
        foreach (var i in Items)
        {

            foreach (var j in NeedItem)
            {
                if (i == j.Num)
                {
                    score += j.Score;
                    break;
                }
            }
            foreach (var j in MegaNeed)
            {
                if (j == i)
                {
                    b++;
                    break;
                }
            }

        }
        if (b < MegaNeed.Count)
        {
            IsFailed = true;
        }
        else
        {
            IsFailed = false;
        }
        a = (int)(300f * (float)a / (float)TargetHoosonZai);
        if (!IsFailed)
        {
            a += 300;
        }
        return new List<int> { a, score };


    }


    public List<int> DeerDarahgui(GameObject A, List<int> Items)
    {
        Move[] B = A.GetComponentsInChildren<Move>();
        int x = 0;
        int y = 0;
        foreach (var i in B)
        {
            foreach (var j in Darahgui)
            {
                if (i.Num == j)
                {
                    x++;
                    if (i.gameObject.GetComponent<SupBlocks>().Check())
                    {
                        y++;
                    }
                }
            }
        }
        int score = 0;
        int b = 0;
        foreach (var i in Items)
        {

            foreach (var j in NeedItem)
            {
                if (i == j.Num)
                {
                    score += j.Score;
                    break;
                }
            }
            foreach (var j in MegaNeed)
            {
                if (j == i)
                {
                    b++;
                    break;
                }
            }

        }
        int a;
        if (x == 0)
        {
            a = 0;
        }
        else
        {
            a = (int)((float)(300 * y / x));
        }
        if (b < MegaNeed.Count)
        {
            IsFailed = true;
        }
        else
        {
            IsFailed = false;
            a += 300;
        }
        return new List<int> { a, score };
    }

    public Sprite GetLitterText(int day, int count)
    {
        // string a = "";
        // string x1 = PlayerPrefs.GetInt("day" + day + "count" + count) == 1 ? "成功" : "失敗";
        // string x2 = Letters[PlayerPrefs.GetInt("day" + day + "count" + count)].Text;
        // string x3 = "";
        // foreach (var i in Letters[PlayerPrefs.GetInt("day" + day + "count" + count)].UnlockItem)
        // {
        //     x3 += " [" + i.name + "]";
        // }
        // string x4 = "";
        // foreach (var i in Letters[PlayerPrefs.GetInt("day" + day + "count" + count)].UnlockMap)
        // {
        //     x4 += " [" + i.name + "]";
        // }
        // a = x1 + "\n" + x2 + "\n\n\n解鎖 : " + x3 + "\n" + x4;
        return Letters[PlayerPrefs.GetInt("day" + day + "count" + count)].Text;
    }
}
[Serializable]
public class Levels
{
    public List<People> Characters = new List<People>();
}
[Serializable]
public class ItemsAndScore
{
    public int Num;
    public int Score;
}

[Serializable]
public class Letter
{
    public Sprite Text;
    public List<GameObject> UnlockItem = new List<GameObject>();
    public List<GameObject> UnlockMap = new List<GameObject>();
}