using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveCity : MonoBehaviour
//ここまではおまじないみたいなものだと思ってくれればOK。
{
    public GameObject city;
    //走らせたい距離
    public int endPosition = 500;
    //ターゲットキャラクターの指定が出来る様にするよ
    public Transform character;
    //現在位置
    int charaPos = 0;
    //基準値との差
    int def = 0;
    void Start()
    {
        def = (int)character.position.z * -1;
    }

    void Update()
    {
        //キャラクターがステージの区切れ目に来たら移動処理
        charaPos = (int)character.position.z;


        //TODO　今はマイナスのポジションしか歩いてないけどプラスになったら別処理が必要
        //そもそも0,0,0から走らせられたらこんな処理いらんけどね
        if (charaPos + def > 500 )
        {
            ChangePosition();
            def = (int)character.position.z * -1;
        }
    }

    void ChangePosition()
    {
        city.transform.position += new Vector3(0, 0, 20);
    }
}


