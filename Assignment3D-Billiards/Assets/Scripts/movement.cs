using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody rb;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Hdirect = Input.GetAxis("Horizontal");
        float Vdirect = Input.GetAxis("Vertical");

  

       
        
            rb.AddForce(Hdirect * 30, rb.velocity.y, Vdirect * 30);
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Got");
    }

    
}
