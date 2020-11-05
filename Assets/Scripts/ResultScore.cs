using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    private Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = PrintScore.score;
        scoreText = this.GetComponent<Text>();
        scoreText.text =  float.Parse(score.ToString("f1")) + "p";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
