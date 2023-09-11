using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandsNum : MonoBehaviour
{
    public Dealer deal;
    public MakeTable MT;
    public TextMeshPro TMP;
    public int PlayerNum;
    public int CardNum = 0;

    //プレイヤー残り枚数表示
    void Update()
    {
        if(MT.isGame)
        {
            CardNum = deal.pCard[PlayerNum].Count;
        }
        TMP.text = "プレイヤー" + PlayerNum + ":" + CardNum;
    }
}
