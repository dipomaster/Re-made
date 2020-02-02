using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject player;
    public float mass=1.1f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PC");
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (player.GetComponent<Rigidbody>().mass >= mass)
            {
                GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezeRotationY;
                GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
            }

        }
    }

}
