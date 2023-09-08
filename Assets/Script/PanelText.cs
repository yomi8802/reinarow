using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelText : MonoBehaviour
{
    public AtomIndex AI; 
    public TextMeshPro TMP;
    public bool numText = false;
    public bool nameText = false;
    bool isShow = false;

    void Update()
    {
        if(!isShow && AI.isPutted)
        {
            if(numText)
            {
                if(AI.num <= 56)
                {
                    TMP.text = AI.num.ToString();
                }
                else if(AI.num == 57)
                {
                    TMP.text = "57～71";
                }
                else if(AI.num <= 74)
                {
                    TMP.text = (AI.num + 14).ToString();
                }
                else if(AI.num == 75)
                {
                    TMP.text = "89～103";
                }
                else
                {
                    TMP.text = (AI.num + 28).ToString();
                }
            }
            if(nameText)
            {
                TMP.text = AI.Name;
            }
        }
    }
}
