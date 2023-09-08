using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hands : MonoBehaviour
{
    public GameObject card;
    public GameObject[] myCards;
    public Dealer dealer;
    public Atom atom;
    public Transform parent;
    public RectTransform rparent;

    public List<GameObject> myCards_front;
    public List<GameObject> myCards_back;
    int cNum_half;
    public float Paneint;
    int hand_num;

    public void Start()
    {
        myCards = new GameObject[dealer.cNum[0]];
        cNum_half = dealer.cNum[0] / 2;
        hand_num = dealer.cNum[0];
        Paneint = 11;
    }

    public void CardAli()
    {
        int max_Wid;
        if(myCards_front.Count >= myCards_back.Count)
        {
            max_Wid = myCards_front.Count;
        }
        else
        {
            max_Wid = myCards_back.Count;
        }
        rparent.sizeDelta = new Vector2(max_Wid * Paneint, 30);
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

    public void CardAli(GameObject GO)
    {
        int max_Wid;
        if(myCards_front.Count >= myCards_back.Count)
        {
            max_Wid = myCards_front.Count;
        }
        else
        {
            max_Wid = myCards_back.Count;
        }
        rparent.sizeDelta = new Vector2(max_Wid * Paneint, 30);
        myCards_front.RemoveAll(x => x.GetComponent<AtomIndex>().num.Equals(GO.GetComponent<AtomIndex>().num));
        myCards_back.RemoveAll(x => x.GetComponent<AtomIndex>().num.Equals(GO.GetComponent<AtomIndex>().num));
        Destroy(GO);
        hand_num -= 1;
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

    public void myHands()
    {
        for(int i = 0; i < dealer.cNum[0]; i++)
        {
            myCards[i] = Instantiate(card,parent);
            if(i < cNum_half)
            {
                myCards_front.Add(myCards[i]);
            }
            else
            {
                myCards_back.Add(myCards[i]);
            }
            myCards[i].GetComponent<AtomIndex>().num = dealer.pCard[0][i];
            myCards[i].GetComponent<AtomIndex>().Name = atom.AtomDic[dealer.pCard[0][i]];
            myCards[i].GetComponentInChildren<TextMeshPro>().text = atom.AtomDic[dealer.pCard[0][i]];
        }
        CardAli();
    }
}