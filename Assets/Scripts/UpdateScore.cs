using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScore : MonoBehaviour
{
    private Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<Text>();
        scoreText.text = SaveScoreAndVelocity.updateScoreText;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = SaveScoreAndVelocity.updateScoreText;
        
    }
}
