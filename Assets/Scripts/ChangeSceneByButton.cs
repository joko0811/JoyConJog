using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneByButton : MonoBehaviour
{
    public string sceneName;
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
            SceneManager.LoadScene(sceneName);
        }

    }
}
