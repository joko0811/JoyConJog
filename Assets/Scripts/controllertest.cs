using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllertest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PressSomethingButton();
    }


    void PressSomethingButton()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.B) || OVRInput.GetDown(OVRInput.RawButton.X) || OVRInput.GetDown(OVRInput.RawButton.Y) 
            || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)|| OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)|| OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)|| OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {

            Debug.Log(PlayerPrefs.GetInt("SCORE",0));
            Debug.Log(PlayerPrefs.GetFloat("VELOCITY",0));
        }

    }
}
