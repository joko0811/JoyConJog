using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVelocity : MonoBehaviour
{
    private Text velocityText;
    
    // Start is called before the first frame update
    void Start()
    {
        velocityText = this.GetComponent<Text>();
        velocityText.text = SaveScoreAndVelocity.updateVelocityText;
    }

    private void Update()
    {
        velocityText.text = SaveScoreAndVelocity.updateVelocityText;
        
    }
}
