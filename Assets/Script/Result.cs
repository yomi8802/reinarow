using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Result : MonoBehaviour
{
    public TextMeshProUGUI TMP;

    // Start is called before the first frame update
    void Start()
    {
        TMP.text = "プレイヤー" + Prog.nowPlayer + "の勝ち";
    }
}
