using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    string[] scoreRanking = {"score1位", "score2位","score3位"};
    string[] velocityRanking = {"速度1位", "速度2位","速度3位"};

    int[] scoreRankingValue = new int[3];
    float[] velocityRankingValue = new float[3];

    // Start is called before the first frame update
    void Start()
    {
        GetRanking();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GetRanking()
    {
        for(int i = 0;i < scoreRanking.Length; i++)
        {
            scoreRankingValue[i] = PlayerPrefs.GetInt(scoreRanking[i]);
            velocityRankingValue[i] = PlayerPrefs.GetFloat(velocityRanking[i]);
        }
    }
}
