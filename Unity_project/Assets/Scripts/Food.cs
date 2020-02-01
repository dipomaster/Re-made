using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            player.GetComponent<PlayerController>().baseScale += new Vector3(0.2f, 0.2f, 0.2f);
            player.GetComponent<Rigidbody>().mass += 0.1f;
            player.GetComponent<PlayerController>().exit = true;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
