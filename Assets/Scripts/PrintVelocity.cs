using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintVelocity : MonoBehaviour
{
    //Rigidbodyを変数に入れる
    public Rigidbody rb;
    private Text velocityText;
    private float velocity = 0f;
    public static float maxVelocity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        velocityText = this.GetComponent<Text>();
        // テキストの表示を入れ替える

        velocity = rb.velocity.magnitude;
        velocityText.text =  velocity.ToString("f1");
        if (velocity > maxVelocity)
        {
            maxVelocity = velocity;
        }
    }
}

