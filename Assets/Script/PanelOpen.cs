using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PanelOpen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public GameObject NextPanel;
    public GameObject NowPanel;
    public AudioSource Audio;
    public AudioClip Click;
    public bool isPanel;
    public bool isImage;
    public bool isCloseButton;
    public bool isFirstPanel;

    public void OnPointerEnter(PointerEventData eventdata)
    {
        //optionパネルの色変更
        if(isImage)
        {
            this.gameObject.GetComponent<Image>().color = Color.green;
        }
        else if(isCloseButton)
        {
            this.gameObject.GetComponent<Image>().color = Color.red;        
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        ButtonReset();
    }

    //パネル送り設定
    public void OnPointerClick(PointerEventData eventdata)
    {
        if(!isFirstPanel)
        {
            Audio.PlayOneShot(Click);
            NextPanel.SetActive(true); //パネル表示
        }
        if(isCloseButton) 
        {
            ButtonReset();
            Audio.PlayOneShot(Click);
            NowPanel.SetActive(false); //今開いているパネルを非表示
        }
    }

    //ボタン色初期化
    void ButtonReset()
    {
        if(isImage || isCloseButton)
        {
            this.gameObject.GetComponent<Image>().color = Color.white;
        }
        else
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
