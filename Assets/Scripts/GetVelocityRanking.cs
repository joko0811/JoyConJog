using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetVelocityRanking : MonoBehaviour
{
    public int i;
    private Text velocityText;
    string[] velocityRanking = {"速度1位", "速度2位","速度3位"};
    // Start is called before the first frame update
    void Start()
    {
        velocityText = this.GetComponent<Text>();
        velocityText.text = PlayerPrefs.GetFloat(velocityRanking[i]).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
