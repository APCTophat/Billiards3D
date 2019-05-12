using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contraints : MonoBehaviour
{
    public Rigidbody rb;
    public Light Halo;

    private void Start()
    {
        Halo.GetComponent<Light>().enabled = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Board")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
           
        }
        if (collision.gameObject.tag != "Board")
        {
            Halo.GetComponent<Light>().enabled = true;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Board")
        {
            Invoke("TurnOffHalo", 0.5f);
        }
    }
    void TurnOffHalo()
    {
        Halo.GetComponent<Light>().enabled = false;
    }
}
