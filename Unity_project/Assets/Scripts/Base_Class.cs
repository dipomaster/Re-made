using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Class : MonoBehaviour
{
    private Rigidbody rb;

    private float var;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
            gameObject.AddComponent<Rigidbody>();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
