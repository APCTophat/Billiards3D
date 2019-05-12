using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public GameObject AimerP1;
    public GameObject AimerP2;
    public Rigidbody rb;
    public Renderer rend_P1;
    public Renderer rend_P2;

    public bool inMenu;
    public bool isMoving;
    public bool Contact;
    public bool canShoot;
    public bool isPlayer_1;

    public float speed;
    public float RotateSpeed;
    public float StopSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float OnWall;

   
    
   
    void Start()
    {
        rend_P1 = AimerP1.GetComponent<Renderer>();
        rend_P2 = AimerP2.GetComponent<Renderer>();
        isMoving = false;
        Contact = false;
        canShoot = true;
        maxSpeed = 10000;
        minSpeed = 1000;
        speed = minSpeed;
        OnWall = 1;
        isPlayer_1 = true;

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "MenuScene")
        {
            inMenu = true;
        }
        else
        {
            inMenu = false;
        }
      
    }

    
    void FixedUpdate()
    {
        HoleTriggerSwitch();
        PlayerMovement();
        Stop();
        PlayerRestriction();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(inMenu == true)
        {
            if (other.gameObject.name == "StartHole")
            {

                FindObjectOfType<GameManager>().Invoke("Begin", 0.5f);
               

            }

            if (other.gameObject.name == "QuitHole")
            {
                FindObjectOfType<GameManager>().Invoke("Close", 0.5f);

            }
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
            speed = minSpeed;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            isMoving = true;
            canShoot = true;

            if(isPlayer_1 == true)
            {
                rend_P2.enabled = false;
                rend_P1.enabled = true;
            }
            else
            {
                rend_P1.enabled = false;
                rend_P2.enabled = true;
            }
         
        }
        if (rb.velocity.magnitude > StopSpeed && isMoving == true)
        {
            canShoot = false;
            isMoving = false;
           
        }

        if (Contact == true)
        {
            OnWall -= Time.deltaTime;
            if (OnWall <= 0 && rb.velocity.magnitude <= StopSpeed)
            {
                Contact = false;
                OnWall = 1;
            }
        }
    }

    public void PlayerMovement()
    {
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(RotateSpeed, 0, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-RotateSpeed, 0, 0, Space.Self);
        }
        if (canShoot == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {

                rb.AddForce(transform.forward * speed);
                rend_P1.enabled = false;
                rend_P2.enabled = false;
                Contact = false;
                FindObjectOfType<GameManager>().Invoke("SwitchPlayer", 0.1f);
                Invoke("SwitchPlayer", 0.1f);
                Invoke("HoleTriggerSwitch", 0.1f);
            }
        }
        if (canShoot == true)
        {
           
            if (Input.GetKey(KeyCode.Space))
            {
               
                speed = speed + 2000 * Time.deltaTime;
                if (speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
        }
        
    }
    void SwitchPlayer()
    {
        isPlayer_1 = !isPlayer_1;

    }
    void HoleTriggerSwitch()
    {
        FindObjectOfType<HoleTrigger>().Invoke("SwitchPlayer", 0.1f);
    }
}
