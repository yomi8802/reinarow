using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AtomIndex : MonoBehaviour
{
    public string Name; //元素名

    public int num = 0; //原子番号

    public bool canPut; //設置可能性
    public bool isPutted = false; //設置済みか否か
}
