using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public List<int> AtomList;
    int Num;
    public int pNum = 4;
    public int[] cNum; //手札枚数
    public List<List<int>> pCard; //プレイヤー手札

    void Start()
    {
        //山札作成
        for(int i = 1; i <= 90; i++)
        {
            AtomList.Add(i);
        }

        //各プレイヤーの手札枚数
        cNum = new int[pNum];

        //プレイヤー数で割り振る
        for(int i = 0; i < pNum; i++)
        {
            cNum[i] = 90 / pNum;
        }
        //余り枚数を割り振る
        for(int i = 0; i < 90 % pNum; i++)
        {
            cNum[i]++;
        }

        pCard = new List<List<int>>();
    }

    public void Deal()
    {
        int Selnum;

        //手札配り
        for(int i = 0; i < pNum; i++)
        {
            List<int> temp = new List<int>();
            for(int j = 0; j < cNum[i]; j++)
            {
                Selnum = Random.Range(0,AtomList.Count); //山札から一枚選択
                temp.Add(AtomList[Selnum]); //手札に追加
                AtomList.RemoveAt(Selnum); //山札から削除
            }
            pCard.Add(temp); //プレイヤーに配布
        }
        print(pCard.Count);
    }
}
