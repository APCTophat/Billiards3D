using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject Aimer;
    public Rigidbody rb;
    public Camera cameras;
    public Renderer rend;

    public bool isMoving;

    public float speed;
    public float RotateSpeed;
    public float StopSpeed;

   
    void Start()
    {
        rend = Aimer.GetComponent<Renderer>();
        isMoving = false;
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
      

            
        }

        if (rb.velocity.magnitude > StopSpeed && isMoving == true)
        {
            
            isMoving = false;
        }


        Stop();
        PlayerRestriction();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got");
    }

    private void PlayerRestriction()
    {
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -1000, 1000), Mathf.Clamp(rb.position.y, 10, 12), Mathf.Clamp(rb.position.z, -1000, 1000));
    }

    public void Stop()
    {

    
        if (rb.velocity.magnitude <= StopSpeed && isMoving == false)
        {
       
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            //transform.eulerAngles = new Vector3(0, 0, 90);
            rend.enabled = true;
            isMoving = true;
        }
    }
}
