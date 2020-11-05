using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeGameScene : MonoBehaviour
{
    public static float levelValue = 1f;

    public float easyValue = 0.4f;
    public float normalValue = 1f;
    public float hardValue = 3f;


    public string startSceneName = "Start";
    public string gameSceneName = "GameScene";
    public string endSceneName = "End";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A) || OVRInput.GetDown(OVRInput.RawButton.B) || OVRInput.GetDown(OVRInput.RawButton.X) || OVRInput.GetDown(OVRInput.RawButton.Y) 
            || OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)|| OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)|| OVRInput.GetDown(OVRInput.RawButton.RHandTrigger)|| OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            SceneManager.LoadScene(gameSceneName);
        }
    }

    public void ChangeEasyScene()
    {
        levelValue = easyValue;
        SceneManager.LoadScene(gameSceneName);
    }

    public void ChangeNormalScene()
    {
        levelValue = normalValue;
        SceneManager.LoadScene(gameSceneName);
    }

    public void ChangeHardScene()
    {
        levelValue = hardValue;
        SceneManager.LoadScene(gameSceneName);
    }
}
