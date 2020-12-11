using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetMyVelocity : MonoBehaviour
{
    private Text velocityText;
    // Start is called before the first frame update
    void Start()
    {
        velocityText = this.GetComponent<Text>();
        velocityText.text = PlayerPrefs.GetFloat("VELOCITY").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        velocityText.text = PlayerPrefs.GetFloat("VELOCITY").ToString();
    }
}
