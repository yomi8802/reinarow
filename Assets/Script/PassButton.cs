using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Prog prog;
    public MakeTable MT;
    public AudioSource Audio;
    public AudioClip Click;
    public AudioClip err;

    //passボタン色設定
    public void OnPointerEnter(PointerEventData eventdata)
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    //パス可能性判定
    public void OnPointerClick(PointerEventData eventdata)
    {
        if(prog.isFirst)
        {
            Audio.PlayOneShot(err);
            print("今は使えません");
        }
        else if(MT.isGame && Prog.nowPlayer == 0)
        {
            Audio.PlayOneShot(Click);
            prog.Turn(1);
        }
        else
        {
            Audio.PlayOneShot(err);
            print("今は使えません");
        }
    }
}
