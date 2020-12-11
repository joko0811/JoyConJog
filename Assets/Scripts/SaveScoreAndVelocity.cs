using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScoreAndVelocity : MonoBehaviour
{
    string[] scoreRanking = {"score1位", "score2位","score3位"};
    string[] velocityRanking = {"速度1位", "速度2位","速度3位"};

    int[] scoreRankingValue = new int[3];
    float[] velocityRankingValue = new float[3];

    int score;
    float velocity;

    bool isUpdateScore = false;
    bool isUpdateVelocity = false;
    public static string updateScoreText = "";
    public static string updateVelocityText = "";


    // Start is called before the first frame update
    void Start()
    {
        isUpdateScore = false;
        isUpdateVelocity = false;
        updateScoreText = "";
        updateVelocityText = "";
        GetRanking();
        PlayerPrefs.SetInt("SCORE", PrintScore.score);
        PlayerPrefs.SetFloat("VELOCITY", float.Parse(PrintVelocity.maxVelocity.ToString("f1")));
        PlayerPrefs.Save();
        score = PrintScore.score;
        velocity = float.Parse(PrintVelocity.maxVelocity.ToString("f1"));
        UpdateRanking();
    }


    void GetRanking()
    {
        for(int i = 0;i < scoreRanking.Length; i++)
        {
            scoreRankingValue[i] = PlayerPrefs.GetInt(scoreRanking[i]);
            velocityRankingValue[i] = PlayerPrefs.GetFloat(velocityRanking[i]);
        }
    }

    void UpdateRanking()
    {
        for(int i = 0;i < scoreRanking.Length; i++)
        {
            if(score > scoreRankingValue[i])
            {
                if(isUpdateScore == false)
                {
                    updateScoreText = "スコア第" + (i+1) + "位！"; 
                    isUpdateScore = true;
                }
                int tmp = scoreRankingValue[i];
                scoreRankingValue[i] = score;
                score = tmp;
            }

            if(velocity > velocityRankingValue[i])
            {
                if(isUpdateVelocity == false)
                {
                    updateVelocityText = "最高速度第" + (i+1) + "位！"; 
                    isUpdateVelocity = true;
                }
                float tmp = velocityRankingValue[i];
                velocityRankingValue[i] = velocity;
                velocity = tmp;
            }
        }

        for(int i = 0;i < scoreRanking.Length; i++)
        {
            PlayerPrefs.SetInt(scoreRanking[i], scoreRankingValue[i]);
            PlayerPrefs.SetFloat(velocityRanking[i], velocityRankingValue[i]);
        }
    }
}
