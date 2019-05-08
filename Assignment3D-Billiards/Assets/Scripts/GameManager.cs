using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject BallPreFab;

    public bool inMenu;

    // Start is called before the first frame update
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


    }

    // Update is called once per frame
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
       
    }

    void Begin()
    {
        SceneManager.LoadScene("MainScene");
      
    }

    void Close()
    {
        Application.Quit();
    }

   
}
