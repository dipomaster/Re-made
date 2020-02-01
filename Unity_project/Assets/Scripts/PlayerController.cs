using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;
    [Range(1f, 50f)]
    public float speed;
    [Range(1f, 10f)]
    public float smoothSpeed;

    public Vector3 baseScale;
    public float speedmultiplier;
    public Vector3 smoothScale;
    private Vector3 hitPosition;
    public bool exit=true;
    private bool enter = false;
    private void Awake()
    {
gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, baseScale, smoothSpeed / 100f);
        if (rb == null)
            gameObject.AddComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
    }
    private void FixedUpdate()
    {
        if (exit)
        gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, baseScale, smoothSpeed / 100f);
        if (enter)
            gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, hitPosition, smoothSpeed / 100f);

    }

    void Move()
    {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward *speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * speed);
        }
        if (Input.GetButtonDown("Jump"))
        {

           

             rb.AddForce (Vector3.up * speed* speedmultiplier * Physics.gravity.y*(-1));
           
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        hitPosition = other.transform.position;


        if (Physics.Raycast(transform.position, transform.TransformDirection(other.transform.position)) && gameObject.transform.localScale == baseScale)

            enter = true;
        exit = false;
    }

    private void OnTriggerExit(Collider other)
    {
        enter = false;
       
        exit = true;
    }
}
