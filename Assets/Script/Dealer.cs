using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public List<int> AtomList;
    int Num;
    public int pNum = 4;
    public int[] cNum;
    public List<List<int>> pCard;
    public List<int> test;
    private int Selnum;

    void Start()
    {
        for(int i = 1; i <= 90; i++)
        {
            AtomList.Add(i);
        }

        cNum = new int[pNum];

        for(int i = 0; i < pNum; i++)
        {
            cNum[i] = 90 / pNum;
        }
        for(int i = 0; i < 90 % pNum; i++)
        {
            cNum[i]++;
        }
        pCard = new List<List<int>>();
    }

    public void Deal()
    {
        for(int i = 0; i < pNum; i++)
        {
            List<int> temp = new List<int>();
            for(int j = 0; j < cNum[i]; j++)
            {
                Selnum = Random.Range(0,AtomList.Count);
                temp.Add(AtomList[Selnum]);
                AtomList.RemoveAt(Selnum);
            }
            pCard.Add(temp);
        }
        print(pCard.Count);
    }
}
