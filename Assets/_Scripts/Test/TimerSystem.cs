using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Timer timer = new Timer();//タイマーのインスタンス生成

        //デリゲート（onComplete）にAlarmメソッドを直接代入
        //timer.onComplete += Alarm;

        // UnityEventを使う場合はAddListenerメソッドを使ってコールバックに使うメソッド（Alarm）を指定
        timer.onComplete.AddListener(Alarm);

        timer.CountDown();//CountDownメソッドを呼び出す
    }

    void Alarm()
    {
        Debug.Log("カウントダウン終了");
    }

}
