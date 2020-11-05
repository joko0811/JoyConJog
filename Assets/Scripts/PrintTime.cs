using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintTime : MonoBehaviour
{
    //カウントダウン
    private float countdown = 100f;

    //時間を表示するText型の変数
    private Text timeText;

    void Start()
    {
        countdown = Timeout.limitTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeText = this.GetComponent<Text>();
        //時間をカウントダウンする
        countdown -= Time.deltaTime;

        //時間を表示する
        timeText.text = countdown.ToString("f2");

        //countdownが0以下になったとき
        if (countdown <= 0)
        {
            timeText.text = "時間になりました！";
        }
    }
}
