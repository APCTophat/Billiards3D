using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoleTrigger : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public bool inMenu;

    public Text startText;
    public Text quitText;
    public Text scoreText;

    public int score;


    private void Start()
    {
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

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            Vector3 position = new Vector3(32, 12, 0);
           Instantiate(PlayerPrefab, position, Quaternion.Euler(0 , 0 , 90));

            
        }

        if(inMenu == false)
        {
            score = score + 1;
        }



        Destroy(other.gameObject);
    }
}
