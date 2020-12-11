using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultMaxSpeed : MonoBehaviour
{
    private Text maxSpeedText;
    private float maxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = PrintVelocity.maxVelocity;
        maxSpeedText = this.GetComponent<Text>();
        maxSpeedText.text =  maxSpeed.ToString("f1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
