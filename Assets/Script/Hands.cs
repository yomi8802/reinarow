using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hands : MonoBehaviour
{
    public GameObject card;
    public GameObject[] myCards; //手札
    public Dealer dealer;
    public Atom atom;
    public Transform parent;
    public RectTransform rparent;

    public List<GameObject> myCards_front;
    public List<GameObject> myCards_back;
    int cNum_half; //手札２列表示用
    public float Paneint; //手札canvas横幅
    int hand_num; //手札枚数

    public void Start()
    {
        myCards = new GameObject[dealer.cNum[0]];
        cNum_half = dealer.cNum[0] / 2;
        hand_num = dealer.cNum[0];
        Paneint = 11;
    }

    //カード整列
    public void CardAli()
    {
        int max_Wid; //手札幅
        //手札上下の多いほうに合わせる
        if(myCards_front.Count >= myCards_back.Count)
        {
            max_Wid = myCards_front.Count;
        }
        else
        {
            max_Wid = myCards_back.Count;
        }

        //手札canvasサイズ設定
        rparent.sizeDelta = new Vector2(max_Wid * Paneint, 30);

        //手札設置
        for(int i = 0; i < hand_num; i++)
        {
            if(i < myCards_front.Count)
            {
                myCards_front[i].transform.position = parent.TransformPoint(new Vector3(i * Paneint - (myCards_front.Count - 1) * Paneint / 2, 0,0));
            }
            else
            {
                myCards_back[i - myCards_front.Count].transform.position = parent.TransformPoint(new Vector3((i - myCards_front.Count) * Paneint - (myCards_back.Count - 1) * Paneint / 2, -12,0));
            }
        }
    }

    //カード整列
    public void CardAli(GameObject GO)
    {
        int max_Wid; //手札幅
        //手札上下多いほうに合わせる
        if(myCards_front.Count >= myCards_back.Count)
        {
            max_Wid = myCards_front.Count;
        }
        else
        {
            max_Wid = myCards_back.Count;
        }

        //手札canvasサイズ設定
        rparent.sizeDelta = new Vector2(max_Wid * Paneint, 30);

        //選択された手札を削除
        myCards_front.RemoveAll(x => x.GetComponent<AtomIndex>().num.Equals(GO.GetComponent<AtomIndex>().num));
        myCards_back.RemoveAll(x => x.GetComponent<AtomIndex>().num.Equals(GO.GetComponent<AtomIndex>().num));
        Destroy(GO);
        hand_num -= 1;

        //手札再設置
        for(int i = 0; i < hand_num; i++)
        {
            if(i < myCards_front.Count)
            {
                myCards_front[i].transform.position = parent.TransformPoint(new Vector3(i * Paneint - (myCards_front.Count - 1) * Paneint / 2, 0,0));
            }
            else
            {
                myCards_back[i - myCards_front.Count].transform.position = parent.TransformPoint(new Vector3((i - myCards_front.Count) * Paneint - (myCards_back.Count - 1) * Paneint / 2, -12,0));
            }
        }
    }

    //手札作成
    public void myHands()
    {
        for(int i = 0; i < dealer.cNum[0]; i++)
        {
            //空のカード作成
            myCards[i] = Instantiate(card,parent);
            if(i < cNum_half)
            {
                myCards_front.Add(myCards[i]);
            }
            else
            {
                myCards_back.Add(myCards[i]);
            }

            myCards[i].GetComponent<AtomIndex>().num = dealer.pCard[0][i]; //原子番号設定
            myCards[i].GetComponent<AtomIndex>().Name = atom.AtomDic[dealer.pCard[0][i]]; //元素名設定
            myCards[i].GetComponentInChildren<TextMeshPro>().text = atom.AtomDic[dealer.pCard[0][i]]; //元素名表示
        }

        //整列
        CardAli();
    }
}