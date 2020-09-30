using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityPlane : MonoBehaviour
//ここまではおまじないみたいなものだと思ってくれればOK。
{
  public GameObject Plane;
  const int stageSize = 5;
  //ターゲットキャラクターの指定が出来る様にするよ
  public Transform character;
  //ステージステップの配列
  GameObject[] stageStep = new GameObject[10];
  void Start()
  {
    //ステージを作成
    for (int i = 0; i < stageStep.Length; i++)
    {
      stageStep[i] = Instantiate(Plane, new Vector3(0, 0, 5 * i), Quaternion.identity);
    }
  }

  void Update()
  {
    //キャラクターがステージの区切れ目に来たら移動処理
    int charaPos = (int)character.position.z;
    if (charaPos % stageSize == 0)
    {
      MoveStage();
    }
  }

  void MoveStage()
  {
    float charaPos = character.position.z;
    for (int i = 0; i < stageStep.Length; i++)
    {
      //既にすぎたステージを移動
      if (stageStep[i].transform.position.z + 1 < charaPos)
      {
        ChangePosition(i);
      }
    }

    void ChangePosition(int i)
    {
      //一番最後にあるステージの場所から+stageSizeしたところにすでにすぎたステージを移動
      int prevIndex = (i + 9) % 10;
      stageStep[i].transform.position = new Vector3(0, 0, stageStep[prevIndex].transform.position.z + stageSize);
    }
  }

}

