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

    public void Turn(int num)
    {
        if(num != 0)
        {
            StartCoroutine(NPCTurn(num));
        }
        else
        {
            myTurn = true;
            text.text = "あなたの番";
            print("あなたのターン");
        }
    }

    IEnumerator NPCTurn(int num)
    {
        while(num % 4 != 0 && MT.isGame)
        {
            nowPlayer = num;
            ComboCheck = -1;
            print("player" + (num % 4) + "turn");
            text.text = "プレイヤー" + (num % 4) + "の番";
            
            yield return new WaitForSeconds(1);
            
            if(isFirst)
            {
                MT.Pane[60].GetComponent<Renderer>().material.color = Color.green;
                deal.pCard[num % 4].RemoveAt(deal.pCard[num % 4].IndexOf(61));
                MT.Pane[60].GetComponent<AtomIndex>().isPutted = true;
                Audio.PlayOneShot(put);
                isFirst = false;
                print("61");
            }
            else
            {
                ComboCheck = Action(num,ComboCheck);
                while(MT.isCombo(ComboCheck))
                {
                    text.text = "プレイヤー" + num + ":連続ターン";
                    yield return new WaitForSeconds(1);
                    ComboCheck = Action(num,ComboCheck);
                }
            }
            print("-----");
            num++;
            yield return new WaitForSeconds(1);
        }
        if(MT.isGame)
        {
            nowPlayer = 0;
            Turn(0);
        }
    }

    int Action(int num, int check)
    {
        for(int i = 0; i < deal.pCard[num % 4].Count; i++)
        {
            if(MT.Pane[deal.pCard[num % 4][i] - 1].GetComponent<AtomIndex>().canPut)
            {
                MT.Pane[deal.pCard[num % 4][i] - 1].GetComponent<Renderer>().material.color = Color.green;
                MT.Pane[deal.pCard[num % 4][i] - 1].GetComponent<AtomIndex>().isPutted = true;
                print(MT.Pane[deal.pCard[num % 4][i] - 1].GetComponent<AtomIndex>().num);
                check = MT.Pane[deal.pCard[num % 4][i] - 1].GetComponent<AtomIndex>().num;
                Audio.PlayOneShot(put);
                deal.pCard[num].RemoveAt(i);
                break;
            }
            if(i == deal.pCard[num % 4].Count - 1)
            {
                print("出せる手札がありませんでした");
                check = -1;
            }
        }
        if(deal.pCard[num % 4].Count == 0)
        {
            print(nowPlayer);
            text.text = ("プレイヤー" + (num % 4) + "の勝利");
            HN[num - 1].CardNum = 0;
            MT.isGame = false;
            ComboCheck = -1;
        }
        return check;
    }
}
