using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightGauge_Controller : MonoBehaviour　//キャンバスにあるLight Gaugeのスライダーを管理するスクリプト
{
    public float countTime = 60;   //スライダーのマックス値を設定
    Slider Light_Slider;

    // Use this for initialization
    void Start()
    {
        //キャンバスにあるLight Gaugeのスライダーを取得
        Light_Slider = GameObject.Find("Light Gauge").GetComponent<Slider>();

    }

    
   
   
    // Update is called once per frame
    void Update()
    {
        //毎フレームcountTime(発電ゲージ)から0.1をマイナスしてバッテリーをへらす
        countTime -= Time.deltaTime;


        //発電により大量にエネルギーが来て限界突破してバッテリーが減らなく事があったので、マックス値を超えると強制的にマックス値に戻すようにする
        if (countTime > 61)
        {
            countTime = 60;
        }



        Light_Slider.value = countTime;       

    }

    //ChargeLightから受け取りcountTimeにたす。これでバッテリー残量が増える。やったぜ。
    public void AddplusEG(int amount)
    {
        countTime += amount;

        //  Debug.Log("sjalfhsld");
    }


}






