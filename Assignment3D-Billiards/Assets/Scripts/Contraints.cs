using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contraints : MonoBehaviour
{
    public Rigidbody rb;
    

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Board")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
}
