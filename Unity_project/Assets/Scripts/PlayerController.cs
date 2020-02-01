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
    public bool Jump=false;
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
        //ChangeSize();
    }
    private void FixedUpdate()
    {
       

    }

    void Move()
    {
        RaycastHit hit;
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
        if (Input.GetButtonDown("Jump")&& Physics.Raycast(transform.position, Vector3.down,out hit))
        {
           if(Jump)
             rb.AddForce (Vector3.up * speed* speedmultiplier * Physics.gravity.y*(-1));                       
        }

        if(Jump==false)
        {
            rb.AddForce(Vector3.up * Physics.gravity.y );
        }
    }
    
    private void OnColliderEnter(Collider other)
    {


        hitPosition = other.transform.position*0.1f;
        if (other.gameObject.CompareTag("Ground"))
            Jump = true;
        

        if (Physics.Raycast(transform.position, transform.TransformDirection(other.transform.position)) && gameObject.transform.localScale == baseScale)

            enter = true;
        exit = false;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Ground"))
    //        Jump = false;

    //    enter = false;
       
    //    exit = true;
    //}

  void ChangeSize()
    {
        if (exit)
            gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, baseScale, smoothSpeed / 100f);
        if (enter)
            gameObject.transform.localScale = Vector3.Slerp(gameObject.transform.localScale, hitPosition, smoothSpeed / 100f);
    }
}
