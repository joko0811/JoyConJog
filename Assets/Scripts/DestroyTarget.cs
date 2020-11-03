using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    GameObject player;

    public float destroyRange = 5.0f;
    public GameObject Audio_Object;
    
    public AudioClip se;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //ヌルポ対策
        if (this.gameObject != null)
        {
            if (this.transform.position.z < player.transform.position.z - destroyRange )
            {
                destroy();
            }

        }
    }
    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.tag == "Player")
        {
        */
        Instantiate(Audio_Object, transform.position, transform.rotation);
        destroy();
        /*1
        }
        */
    }

    void destroy()
    {
        Destroy(this.gameObject);
    }
}
