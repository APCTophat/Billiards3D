using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HoleTrigger : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public bool inMenu;
    public bool isPlayer_1;

    public Text startText;
    public Text quitText;
    public Text scoreText;

    public int score_P1;
    public int score_P2;




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
        isPlayer_1 = true;
    }

   
    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            Invoke("ReloadPLayer", 0);
        }

        if(inMenu == false && other.gameObject.tag != "Player")
        {
            if(other.gameObject.tag == "Blue")
            {
                score_P1 = score_P1 + 1;
            }
            if(other.gameObject.tag == "Orange")
            {
                score_P2 = score_P2 + 1;
            }
            if(other.gameObject.tag == "FINALBALL")
            {
                if(isPlayer_1 == false)
                {
                    FindObjectOfType<Score>().Invoke("Did_P1_WIn", 0.5f);
                }
                if (isPlayer_1 == true)
                {
                    FindObjectOfType<Score>().Invoke("Did_P2_WIn", 0.5f);
                }
            }
            
        }

        Destroy(other.gameObject);
    }

    void ReloadPLayer()
    {
        Vector3 position = new Vector3(32, 12, 0);
        Instantiate(PlayerPrefab, position, Quaternion.Euler(0, 0, 90));
    }


    void SwitchPlayer()
    {
        isPlayer_1 = !isPlayer_1;

    }
}
