using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    [Header("Set Target Prefab")]
    //敵プレハブ
    public GameObject targetPrefab;

    [Header("Set Interval Min and Max")]
    //時間間隔の最小値
    [Range(1f, 3f)]
    public float minTime = 2f;
    //時間間隔の最大値
    [Range(5f, 10f)]
    public float maxTime = 5f;

    [Header("Set X Position Min and Max")]
    //X座標の最小値
    [Range(-10f, 0f)]
    public float xMinPosition = -10f;
    //X座標の最大値
    [Range(0f, 30f)]
    public float xMaxPosition = 10f;
    [Header("Set Y Position Min and Max")]
    //Y座標の最小値
    [Range(-10f, 0f)]
    public float yMinPosition = 0f;
    //Y座標の最大値
    [Range(0f, 30f)]
    public float yMaxPosition = 10f;
    [Header("Set Z Position Min and Max")]
    //Z座標の最小値
    [Range(-10f, 0f)]
    public float zMinPosition = -10f;
    //Z座標の最大値
    [Range(0f, 30f)]
    public float zMaxPosition = 20f;

    //敵生成時間間隔
    private float interval;
    //経過時間
    private float time = 0f;


    // Start is called before the first frame update
    void Start()
    {
        interval = GetRandomTime();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > interval)
        {
            GameObject enemy = Instantiate(targetPrefab);//targetをインスタンス化する(生成する)
            enemy.transform.position = GetRandomPosition();
            time = 0f;
            interval = GetRandomTime();//次に発生する時間間隔を決定する
        }
    }
    
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private Vector3 GetRandomPosition()
    {
        //それぞれの座標をランダムに生成する
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        float z = Random.Range(zMinPosition, zMaxPosition);

        //Vector3型のPositionを返す
        return new Vector3(x, y, z);
    }
}
