using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelText : MonoBehaviour
{
    public AtomIndex AI; 
    public TextMeshPro numText;
    public TextMeshPro nameText;
    bool isShow = false;

    void Update()
    {
        if(!isShow && AI.isPutted) //設置されているとき
        {
                //原子番号設定
                if(AI.num <= 56)
                {
                    numText.text = AI.num.ToString();
                }
                else if(AI.num == 57)
                {
                    numText.text = "57～71";
                }
                else if(AI.num <= 74)
                {
                    numText.text = (AI.num + 14).ToString();
                }
                else if(AI.num == 75)
                {
                    numText.text = "89～103";
                }
                else
                {
                    numText.text = (AI.num + 28).ToString();
                }

                //元素名設定
                nameText.text = AI.Name;
        }
    }
}
