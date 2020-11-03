using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintVelocity : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    public Rigidbody rb;
    private Text velocityText;
    float velocity;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        velocityText = this.GetComponent<Text>();
        // テキストの表示を入れ替える

        velocity = rb.velocity.magnitude;
        velocityText.text =  float.Parse(velocity.ToString("f1")) + "km/h";
    }
}

