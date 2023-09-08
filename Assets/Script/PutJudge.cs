using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutJudge : MonoBehaviour
{
    public AtomIndex AI;
    public MakeTable MT;

    // Start is called before the first frame update
    void Start()
    {
        MT = GameObject.Find("Manager").GetComponent<MakeTable>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!AI.canPut)
        {
            if(AI.num < 31)
            {
                if(AI.num == 1)
                {
                    if(MT.Pane[2].GetComponent<AtomIndex>().isPutted || (MT.Pane[7].GetComponent<AtomIndex>().isPutted && MT.Pane[5].GetComponent<AtomIndex>().isPutted))
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 2)
                {
                    if(MT.Pane[9].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 3)
                {
                    if(MT.Pane[0].GetComponent<AtomIndex>().isPutted || MT.Pane[3].GetComponent<AtomIndex>().isPutted || MT.Pane[10].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 4)
                {
                    if(MT.Pane[2].GetComponent<AtomIndex>().isPutted || MT.Pane[11].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 5)
                {
                    if(MT.Pane[5].GetComponent<AtomIndex>().isPutted || MT.Pane[12].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(6 <= AI.num && AI.num <= 9)
                {
                    if(AI.num == 6 && MT.Pane[7].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                    if(MT.Pane[AI.num - 1 + 8].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 10)
                {
                    if(MT.Pane[1].GetComponent<AtomIndex>().isPutted || MT.Pane[8].GetComponent<AtomIndex>().isPutted || MT.Pane[17].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 11)
                {
                    if(MT.Pane[2].GetComponent<AtomIndex>().isPutted || MT.Pane[11].GetComponent<AtomIndex>().isPutted || MT.Pane[18].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 12)
                {
                    if(MT.Pane[10].GetComponent<AtomIndex>().isPutted || MT.Pane[3].GetComponent<AtomIndex>().isPutted || MT.Pane[19].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 13)
                {
                    if(MT.Pane[4].GetComponent<AtomIndex>().isPutted || MT.Pane[13].GetComponent<AtomIndex>().isPutted || MT.Pane[30].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(14 <= AI.num && AI.num <= 17)
                {
                    if(MT.Pane[AI.num - 1 + 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num -1 - 8].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 18)
                {
                    if(MT.Pane[9].GetComponent<AtomIndex>().isPutted || MT.Pane[16].GetComponent<AtomIndex>().isPutted || MT.Pane[35].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 19)
                {
                    if(MT.Pane[10].GetComponent<AtomIndex>().isPutted || MT.Pane[19].GetComponent<AtomIndex>().isPutted || MT.Pane[36].GetComponent<AtomIndex>().isPutted || MT.Pane[65].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(AI.num == 20)
                {
                    if(MT.Pane[18].GetComponent<AtomIndex>().isPutted || MT.Pane[11].GetComponent<AtomIndex>().isPutted || MT.Pane[20].GetComponent<AtomIndex>().isPutted || MT.Pane[37].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
                else if(21 <= AI.num && AI.num <= 30)
                {
                    if(MT.Pane[AI.num - 1 + 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted)
                    {
                        AI.canPut = true;
                    }
                }
            }
            else if((31 <= AI.num && AI.num <= 35) || (38 <= AI.num && AI.num <= 53) || (56 <= AI.num && AI.num <= 71))
            {
                if(AI.num == 56 && MT.Pane[7].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
                if(AI.num == 66 && MT.Pane[18].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
                if(MT.Pane[AI.num - 1 + 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
            else if(AI.num == 36 || AI.num == 54 || AI.num == 72)
            {
                if(MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 1 + 18].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
            else if(AI.num == 37 || AI.num == 55)
            {
                if(MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 1  + 18].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
            else if(AI.num == 73)
            {
                if(MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
            else if(74 <= AI.num && AI.num <= 89)
            {
                if(MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
            else if(AI.num == 90)
            {
                if(MT.Pane[AI.num - 1 - 18].GetComponent<AtomIndex>().isPutted || MT.Pane[AI.num - 2].GetComponent<AtomIndex>().isPutted)
                {
                    AI.canPut = true;
                }
            }
        }
    }
}
