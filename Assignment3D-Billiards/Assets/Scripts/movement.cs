using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject Aimer;
    public Rigidbody rb;
    public Renderer rend;

    public bool isMoving;
    public bool Contact;

    public float speed;
    public float RotateSpeed;
    public float StopSpeed;

   
    void Start()
    {
        rend = Aimer.GetComponent<Renderer>();
        isMoving = false;
        Contact = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(RotateSpeed, 0, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-RotateSpeed, 0, 0, Space.Self);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.forward * speed);
            rend.enabled = false;
            Contact = false;

            
        }

        if (rb.velocity.magnitude > StopSpeed && isMoving == true)
        {
            
            isMoving = false;
        }


        //Vector3 targetDir = Aimer.transform.position - transform.position;
        //float angle = Vector3.Angle(targetDir, transform.forward);
        //Debug.Log(angle);

        Stop();
        PlayerRestriction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "StartHole")
        {
            FindObjectOfType<GameManager>().Invoke("Begin", 0.5f);
        }
        
        if(other.gameObject.name == "QuitHole")
        {
            Application.Quit();
        }
    }

    private void PlayerRestriction()
    {
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -1000, 1000), Mathf.Clamp(rb.position.y, 10, 12), Mathf.Clamp(rb.position.z, -1000, 1000));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Board")
        {
            Contact = true;
            //rb.AddForce((transform.forward * rb.velocity.magnitude) / 2);
        }
       
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Board")
        {
            Contact = false;
            
        }
    }

    public void Stop()
    {

    
        if (rb.velocity.magnitude <= StopSpeed && isMoving == false && Contact == false)
        {
       
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rend.enabled = true;
            isMoving = true;
        }
    }
}
