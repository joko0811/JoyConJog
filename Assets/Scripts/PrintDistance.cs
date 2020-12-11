using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintDistance : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    public Rigidbody rb;
    private Text distanceText;
    private float totalDistance = 0;
    private Vector3 prev = new Vector3( 0, 0, 0 );

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        distanceText = this.GetComponent<Text>();
        // テキストの表示を入れ替える

        Vector3 pos = transform.position;
        Vector3 dis = pos - prev;
        totalDistance += dis.magnitude;
        distanceText.text =  float.Parse(totalDistance.ToString("f1")) + "m";
        prev = pos;
    }
}
