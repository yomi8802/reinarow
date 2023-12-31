using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Pick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public MakeTable MT;
    public AtomIndex AI;
    public Hands HA;
    public Prog prog;
    public Dealer deal;
    public TextMeshProUGUI TMP;
    public AudioSource Audio;
    public bool isOption;
    public AudioClip put;
    public AudioClip err;

    public void Start()
    {
        MT = GameObject.Find("Manager").GetComponent<MakeTable>();
        HA = GameObject.Find("Manager").GetComponent<Hands>();
        prog = GameObject.Find("Manager").GetComponent<Prog>();
        deal = GameObject.Find("Manager").GetComponent<Dealer>();
        TMP = GameObject.Find("NowPlayer").GetComponent<TextMeshProUGUI>();
        Audio = GameObject.Find("SEManager").GetComponent<AudioSource>();
        isOption = false;
    }

    public void OnPointerEnter(PointerEventData eventdata)
    {
        Vector3 up; //カードポップアップ
        up = this.transform.position;
        up += new Vector3(0, 0, -1);
        this.transform.position = up;

        //カードをばあに出せるか
        if (MT.Pane[AI.num - 1].GetComponent<AtomIndex>().canPut)
        {
            MT.Pane[AI.num - 1].GetComponent<Renderer>().material.color = Color.yellow;
        }
        else
        {
            MT.Pane[AI.num - 1].GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        Vector3 down; //カード位置戻し
        down = this.transform.position;
        down -= new Vector3(0, 0, -1);
        this.transform.position = down;

        MT.Pane[AI.num - 1].GetComponent<Renderer>().material.color = Color.white;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //オプション画面を開いているとき無効
        if (isOption)
        {
            return;
        }

        //自分のターンのとき
        if (prog.myTurn)
        {
            //初手のとき
            if (prog.isFirst)
            {
                //レニウムを選択したとき
                if (AI.num == 61)
                {
                    Action();
                    prog.isFirst = false;
                    prog.Turn(1);
                }
                else
                {
                    print("場に出せません");
                    Audio.PlayOneShot(err);
                }
            }
            else
            {
                //選択したカードが場に出せるとき
                if (MT.Pane[AI.num - 1].GetComponent<AtomIndex>().canPut)
                {
                    Action();

                    //ターン継続時
                    if (MT.isCombo(AI.num))
                    {
                        prog.Turn(0);
                        TMP.text = "あなたの連続ターン";
                    }
                    else
                    {
                        prog.Turn(1);
                    }
                }
                else
                {
                    print("場に出せません");
                    Audio.PlayOneShot(err);
                }
            }
        }
        else
        {
            print("あなたのターンではありません");
            Audio.PlayOneShot(err);
        }
    }

    //カード設置
    void Action()
    {
        HA.CardAli(this.gameObject);
        Audio.PlayOneShot(put);
        MT.Pane[AI.num - 1].GetComponent<Renderer>().material.color = Color.green;
        MT.Pane[AI.num - 1].GetComponent<AtomIndex>().isPutted = true;
        deal.pCard[0].RemoveAt(deal.pCard[0].IndexOf(AI.num));
        prog.myTurn = false;
        if (deal.pCard[0].Count == 0)
        {
            TMP.text = "あなたの勝ち";
            print("あなたの勝ち");
            MT.isGame = false;
            return;
        }
    }
}
