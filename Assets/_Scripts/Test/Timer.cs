using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent onComplete = new UnityEvent();

    //public delegate void OnCompleteDelegate();//デリゲートの型（変数）つくる(boolとかといっしょ）
    //public OnCompleteDelegate onComplete;//変数作成

    public void CountDown()//TimerSystemから呼び出し
    {

            Debug.Log("3,2,1,Callback");
            //コールバック
            onComplete.Invoke();//onComplete()
    }
}
