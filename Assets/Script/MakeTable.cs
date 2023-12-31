using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTable : MonoBehaviour
{
    public GameObject PrePane;
    public GameObject[] Pane;
    public Transform parent;
    public Atom atom;
    public Dealer dealer;
    public Hands hands;
    public Prog prog;
    public SceneChange[] SC;

    public bool isGame = false;
    bool isFirst = true;

    void Start()
    {
        Pane = new GameObject[90];
    }

    void Update()
    {
        //ゲーム開始処理
        if(isFirst)
        {
            isGame = true;
            isFirst = false;

            //盤面作成
            for(int i = 0; i < 90; i++)
            {
                Pane[i] = Instantiate(PrePane,parent);
                Pane[i].GetComponent<AtomIndex>().num = i + 1;
                Pane[i].GetComponent<AtomIndex>().Name = atom.AtomDic[i + 1];

                if(i == 0)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-425,210,0));
                }
                else if(i == 1)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(425,210,0));
                }
                else if(i == 2)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-425,160,0));
                }
                else if(i == 3)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-375,160,0));
                }
                else if(3 < i && i < 10)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-25 + i * 50,160,0));
                }
                else if(i == 10)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-425,110,0));
                }
                else if(i == 11)
                {
                    Pane[i].transform.position = parent.TransformPoint(new Vector3(-375,110,0));
                }
                else
                {
                Pane[i].transform.position = parent.TransformPoint(new Vector3(-425 + i % 18 * 50, 110 - i / 18 * 50, 0));
                }

                //結合する元素を設置可能に
                if(i + 1 == 8 || i + 1 == 9 || i + 1 == 16 || i + 1 == 17 || i + 1 == 61)
                {
                    Pane[i].GetComponent<AtomIndex>().canPut = true;
                }
                else
                {
                    Pane[i].GetComponent<AtomIndex>().canPut = false;
                }
            }

            dealer.Deal();
            hands.myHands();
            prog.GameStart();
        }

        SC[0].wasFinished = !isGame;
        SC[1].wasFinished = !isGame;
    }

    //コンボ判定
    public bool isCombo(int num)
    {
        switch(num)
        {
            case 1:
                if(Pane[5].GetComponent<AtomIndex>().isPutted && Pane[7].GetComponent<AtomIndex>().isPutted)
                {
                    print("CH3ReO3");
                    return  true;
                }
                break;
            case 6:
                if(Pane[7].GetComponent<AtomIndex>().isPutted)
                {
                    print("Re2(CO)10");
                    if(Pane[0].GetComponent<AtomIndex>().isPutted)
                    {
                        print("CH3ReO3");
                    }
                    return true;
                }
                break;
            case 8:
                print("ReO2");
                if(Pane[5].GetComponent<AtomIndex>().isPutted)
                {
                    print("Re2(CO)10");
                    if(Pane[0].GetComponent<AtomIndex>().isPutted)
                    {
                        print("CH3ReO3");
                    }
                }
                if(Pane[55].GetComponent<AtomIndex>().isPutted)
                {
                    print("Ba(ReO4)2");
                }
                return true;
            case 9:
                print("ReF6");
                return true;
            case 16:
                print("ReS2");
                return true;
            case 17:
                print("Re2Cl10");
                return true;
            case 19:
                if(Pane[65].GetComponent<AtomIndex>().isPutted)
                {
                    print("K2ReHg");
                    return true;
                }
                break;
            case 56:
                if(Pane[7].GetComponent<AtomIndex>().isPutted)
                {
                    print("Ba(ReO4)2");
                    return true;
                }
                break;
            case 66:
                if(Pane[18].GetComponent<AtomIndex>().isPutted)
                {
                    print("K2ReHg");
                    return true;
                }
                break;
        }
        return false;
    }
}
