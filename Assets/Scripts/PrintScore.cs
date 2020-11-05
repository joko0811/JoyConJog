using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintScore : MonoBehaviour
{
    public Rigidbody rb;
    private Text scoreText;
    public static int score = 0;//大変申し訳無いのですがスコアはdestroyTargetで加算されます
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text =  float.Parse(score.ToString("f1")) + "p";
    }
}

