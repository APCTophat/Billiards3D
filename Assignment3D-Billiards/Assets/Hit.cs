using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject Que;
    public GameObject MainBall;
    public Rigidbody Mainball;
   public Vector3 offset;
    // Start is called before the first frame update
    //void Start()
    //{
    //    MoveQue();
    //   Rigidbody Mainball = MainBall.GetComponent<Rigidbody>();
    //}

    // Update is called once per frame
    void Update()
    {
    
        if (Mainball.velocity.magnitude <= 0.001)
        {
            
        }
        transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
    }

    //void MoveQue()
    //{
    //    Vector3 MainBallPos = MainBall.transform.position;                                  
    //    Vector3 MoveCam = Vector3.Lerp(transform.position, MainBallPos, 0.2f);            
    //    transform.position = MoveCam;
    //}
}
