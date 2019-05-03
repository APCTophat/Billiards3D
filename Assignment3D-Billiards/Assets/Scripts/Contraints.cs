using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contraints : MonoBehaviour
{
    public Rigidbody rb;
    // Update is called once per frame
    void Update()
    {
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, -1000, 1000), Mathf.Clamp(rb.position.y, 10, 12), Mathf.Clamp(rb.position.z, -1000, 1000));
    }
}
