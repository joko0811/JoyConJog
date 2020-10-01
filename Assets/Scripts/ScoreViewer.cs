using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    //歩いた合計距離
    [SerializeField]
    private string score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = score;
    }

    private void setScore(string s)
    {
        this.score = s;
    }
}
