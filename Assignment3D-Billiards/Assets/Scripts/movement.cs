using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public GameObject Aimer;
    public Rigidbody rb;
    public Renderer rend;

    //public GameObject StartHole;

    public bool inMenu;
    public bool isMoving;
    public bool Contact;
    public bool canShoot;
    public bool DisplayMax;

    public float speed;
    public float RotateSpeed;
    public float StopSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float speedFraction;
    public float ChangeColour;
    public float OnWall;

    public Image PowerBar;
    public Image PB_Backdrop;
    public Text MaxPower;
    
   
    void Start()
    {
        rend = Aimer.GetComponent<Renderer>();
        isMoving = false;
        Contact = false;
        canShoot = true;
        maxSpeed = 10000;
        minSpeed = 1000;
        speed = minSpeed;
        PB_Backdrop.enabled = false;
        MaxPower.enabled = false;
        DisplayMax = false;
        OnWall = 1;

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
        if(canShoot == true)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.AddForce(transform.forward * speed);
                rend.enabled = false;
                Contact = false;
            }
        }
       

        if (rb.velocity.magnitude > StopSpeed && isMoving == true)
        {
            canShoot = false;
            isMoving = false;
            PB_Backdrop.enabled = false;
            MaxPower.enabled = false;
            PowerBar.enabled = false;
        }

        speedFraction = speed / maxSpeed;
        PowerBar.fillAmount = speedFraction;
          if (speedFraction == 1)
            {
                if (DisplayMax == false)
                {
                    PB_Backdrop.enabled = true;
                    MaxPower.enabled = true;
                    DisplayMax = true;
                }


                ChangeColour -= Time.deltaTime;
                if (ChangeColour <= 0)
                {
                    ChangeColour = 0.50f;
                }


                if (ChangeColour <= 0.25)
                {
                    MaxPower.GetComponent<Text>().color = new Color(1, 1, 1, 1);
                }
                else
                {
                    MaxPower.GetComponent<Text>().color = new Color(1, 0, 0, 1);
                }
            }
        
       


       if(Contact == true)
        {
            OnWall -= Time.deltaTime; 
            if(OnWall <= 0 && rb.velocity.magnitude <= StopSpeed)
            {
                Contact = false;
                OnWall = 1;
            }
        }
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
                //StartHole.GetComponent<HoleTrigger>().inMenu = false;

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
            rend.enabled = true;
            isMoving = true;
            canShoot = true;
            DisplayMax = false;
            PowerBar.enabled = true;
        }
    }
}
