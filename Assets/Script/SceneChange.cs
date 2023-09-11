using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SceneChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isFirst;
    public bool isButton;
    public bool wasFinished;
    public TextMeshProUGUI TMP;
    public AudioSource Audio;
    public AudioClip Change;

    //タイトルへ戻るボタンの挙動
    public void OnPointerEnter(PointerEventData eventdata)
    {
        if (isButton)
        {
            this.gameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public void OnPointerExit(PointerEventData eventdata)
    {
        if (isButton)
        {
            this.gameObject.GetComponent<Image>().color = Color.white;
        }
    }

    public void OnPointerClick(PointerEventData eventdata)
    {
        if(isButton)
        {
            Audio.PlayOneShot(Change); 
            SceneManager.LoadScene("TitleScene");
        }
    }

    void Update()
    {
        //ゲーム終了表示
        if(wasFinished)
        {
            TMP.text = "Spaceを押すと\nタイトルに戻ります";
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (isFirst)
            {
                Audio.PlayOneShot(Change);
                SceneManager.LoadScene("GameScene");
            }
            if (wasFinished)
            {
                Audio.PlayOneShot(Change);
                SceneManager.LoadScene("TitleScene");
            }
        }
    }
}
