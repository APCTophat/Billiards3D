using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject BallPreFab;
    

    void Start()
    {
        Vector3 position = new Vector3(0, 13, 0);
        Instantiate(BallPreFab, position, Quaternion.identity);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
