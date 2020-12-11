using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timeout : MonoBehaviour
{
    public static float limitTime = 60f;
    public string endSceneName = "ResultScene";
    private float count;
    // Start is called before the first frame update
    void Start()
    {
        count = limitTime; 
    }

    // Update is called once per frame
    void Update()
    {
        //時間をカウントダウンする
         count -= Time.deltaTime;

        //countdownが0以下になったとき
        if (count <= 0)
        {
            SceneManager.LoadScene(endSceneName);
        }
    }
}
