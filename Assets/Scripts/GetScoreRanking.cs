using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScoreRanking : MonoBehaviour
{
    public int i;
    private Text scoreText;
    string[] scoreRanking = {"score1位", "score2位","score3位"};
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text = PlayerPrefs.GetInt(scoreRanking[i]).ToString() + "p";
    }

    // Update is called once per frame
    void Update()
    {
    }
}


