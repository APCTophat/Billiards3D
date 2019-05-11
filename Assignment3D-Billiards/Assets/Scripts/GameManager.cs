using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject BallPreFab;
    public GameObject Player;
    public Rigidbody rb;

    public bool inMenu;
    public bool DisplayMax;
    public bool isPlayer_1;

    public float speed;
    public float speedFraction;
    public float ChangeColour;

    public Image PowerBar;
    public Image PB_Backdrop;
    public Text MaxPower;


    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(sceneName == "MenuScene")
        {
            inMenu = true;
        }
        else
        {
            inMenu = false;
        }
        

        if(inMenu == false)
        {
            Vector3 position = new Vector3(0, 13, 0);
            Instantiate(BallPreFab, position, Quaternion.identity);
        }
        PB_Backdrop.enabled = false;
        MaxPower.enabled = false;
        DisplayMax = false;
        isPlayer_1 = true;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("MenuScene");
        }
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = Player.GetComponent<Rigidbody>();
        PowerIndicator();
    }

    void Begin()
    {
        SceneManager.LoadScene("MainScene");
      
    }

    void Close()
    {
        Application.Quit();
    }

  void PowerIndicator()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            speed = speed + 2000 * Time.deltaTime;
            if (speed >= 10000)
            {
                speed = 10000;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            speed = 1000;
        }

            speedFraction = speed / 10000;
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
        if (rb.velocity.magnitude <= 1)
        {
            DisplayMax = false;
          PowerBar.enabled = true;
        }
        if (rb.velocity.magnitude > 1)
        {
            PB_Backdrop.enabled = false;
            MaxPower.enabled = false;
            PowerBar.enabled = false;
        }
    }
    
}
