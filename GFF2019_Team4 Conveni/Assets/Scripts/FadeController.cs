using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public AudioClip Clik_SE3;
    public AudioSource audioSource;

    public GameObject BTmaxTXT;
    float fadeInSpeed = 0.000275f;
    float fadeOutSpeed = 0.000275f;        //透明度が変わるスピードを管理
    float red, green, blue, alpha;   //パネルの色、不透明度を管理
    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    public bool isFadeIn = false;   //フェードイン処理の開始、完了を管理するフラグ

    Image fadeImage;                //透明度を変更するパネルのイメージ

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey("z"))
        {
            StartFadeIn();
            
        }

        else
        {
            StartFadeOut();
        }

        if (alpha >= 0)
        {
            BTmaxTXT.SetActive(false);
        }
    }

    void StartFadeIn()
    {
        alpha -= fadeInSpeed;                //a)不透明度を徐々に下げる
        SetAlpha();                      //b)変更した不透明度パネルに反映する
        if (alpha <= 0)
        {                    //c)完全に透明になったら処理を抜ける
            isFadeIn = false;
            fadeImage.enabled = false;    //d)パネルの表示をオフにする
        }
    }

    void StartFadeOut()
    {
        
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        alpha += fadeOutSpeed;         // b)不透明度を徐々にあげる
        SetAlpha();               // c)変更した透明度をパネルに反映する
        if (alpha >= 0.81f)
        {             // d)完全に不透明になったら処理を抜ける
            alpha = 0.8f;
            isFadeOut = false;
            
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    public void AddplusEG (float amount)
    {
        audioSource.PlayOneShot(Clik_SE3);

        Debug.Log("kaninanain");
        alpha += -0.08f;

        if(alpha <= 0)
        {                    //c)完全に透明になったら処理を抜ける
            

            isFadeIn = false;
            fadeImage.enabled = false;//d)パネルの表示をオフにする
            BTmaxTXT.SetActive(true);

        }

        if(alpha <= -0.2)
        {
            alpha = 0;
        }
   

    }
}