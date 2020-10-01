using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTarget : MonoBehaviour
{
    GameObject player;

    public float destroyRange = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z < player.transform.position.z - destroyRange)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
