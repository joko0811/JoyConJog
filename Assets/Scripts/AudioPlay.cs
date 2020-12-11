using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    private AudioSource Audio;
    bool isAudioStart = false;
    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();
        Audio.Play();
        isAudioStart = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Audio.isPlaying && isAudioStart)
        {
            Destroy(gameObject);
        }
        
    }
}
