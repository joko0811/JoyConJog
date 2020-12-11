using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBGMStopper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RepeatBGM.DontDestroyEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
