using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeLight : MonoBehaviour { //発電システムのスクリプト、携帯を横に傾けると発電してくれるはず(未デバッグ)

    public float Energy = -0.002f; //発電ゲージにプラスする数
    public FadeController LC; //数字を送るスプリクト
   

    void Start()
    {
        


    }

    void Update() { 

           

    }

    public void ChargeEG()
    {
       
        //AddでLightGauge_Controllerのスクリプトに送る
        LC.AddplusEG(Energy);
        
    }

}
