using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Prog : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Dealer deal;
    public MakeTable MT;
    public HandsNum[] HN;
    public AudioSource Audio;
    public bool myTurn = false;
    public bool isFirst = false;
    public static int nowPlayer;
    public AudioClip put;

    int ComboCheck;

    public void GameStart()
    {
        print("start");

        //ターン表示
        for(int i = 0; i < deal.pNum; i++)
        {
            if(deal.pCard[i].Contains(61))
            {
                if(i == 0)
                {
                    text.text = "あなたの番";
                }
                else
                {
                    text.text = "プレイヤー" + i + "の番";
                }
                nowPlayer = i;
            }
        }
        isFirst = true;
        print("StartTurn:" + nowPlayer);
        Turn(nowPlayer);
    }

    //ゲーム進行
    public void Turn(int num)
    {
        if(num != 0) //npcのターン
        {
            StartCoroutine(NPCTurn(num));
        }
        else //プレイヤーのターン
        {
            myTurn = true;
            text.text = "あなたの番";
            print("あなたのターン");
        }
    }

    //npcの挙動
    IEnumerator NPCTurn(int num)
    {
        while(num % 4 != 0 && MT.isGame) //プレイヤーが一周するまで
        {
            //プレーヤー名表示
            nowPlayer = num;
            ComboCheck = -1;
            print("player" + (num % 4) + "turn");
            text.text = "プレイヤー" + (num % 4) + "の番";
            
            yield return new WaitForSeconds(1);
            
            //初手はレニウムを設置
            if(isFirst)
            {
                MT.Pane[60].GetComponent<Renderer>().material.color = Color.green;
                deal.pCard[num % 4].RemoveAt(deal.pCard[num % 4].IndexOf(61));
                MT.Pane[60].GetComponent<AtomIndex>().isPutted = true;
                Audio.PlayOneShot(put);
                isFirst = false;
                print("61");
            }
            else //初手以外
            {
                ComboCheck = Action(num % 4,ComboCheck);
                while(MT.isCombo(ComboCheck))
                {
                    text.text = "プレイヤー" + (num % 4) + ":連続ターン";
                    yield return new WaitForSeconds(1);
                    ComboCheck = Action(num % 4,ComboCheck);
                }
            }
            print("-----");

            //次のプレイヤーに移動
            num++;
            yield return new WaitForSeconds(1);
        }
        if(MT.isGame) //ゲームが終わっていなければプレイヤーのターン
        {
            nowPlayer = 0;
            Turn(0);
        }
    }

    //npcカード設置
    int Action(int num, int check)
    {
        //手札の数ループ
        for(int i = 0; i < deal.pCard[num].Count; i++)
        {
            //手札が設置できるとき
            if(MT.Pane[deal.pCard[num][i] - 1].GetComponent<AtomIndex>().canPut)
            {
                //設置処理
                MT.Pane[deal.pCard[num][i] - 1].GetComponent<Renderer>().material.color = Color.green;
                MT.Pane[deal.pCard[num][i] - 1].GetComponent<AtomIndex>().isPutted = true;
                print(MT.Pane[deal.pCard[num][i] - 1].GetComponent<AtomIndex>().num);
                check = MT.Pane[deal.pCard[num][i] - 1].GetComponent<AtomIndex>().num;
                Audio.PlayOneShot(put);
                MT.Pane[deal.pCard[num][i] - 1].GetComponent<AtomIndex>().canPut = false;
                deal.pCard[num].RemoveAt(i);
                break;
            }
            //全ての手札が設置できなかったとき
            if(i == deal.pCard[num].Count - 1)
            {
                print("出せる手札がありませんでした");
                check = -1;
            }
        }

        //手札が終わったとき
        if(deal.pCard[num].Count == 0)
        {
            //勝利処理
            print(nowPlayer);
            text.text = ("プレイヤー" + num + "の勝利");
            HN[num - 1].CardNum = 0;
            MT.isGame = false;
            ComboCheck = -1;
        }
        return check;
    }
}
