using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public GameObject Starthole;
    public GameObject Quithole;
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;
    public GameObject H4;

    public Text P1_TotalScore;
    public Text P2_TotalScore;
    public Text StartText;
    public Text QuitText;

    public int P1_totalScore;
    public int P2_totalScore;
    public int StartHole_Score;

    public bool inMenu;

    // Start is called before the first frame update
    void Start()
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

        if(inMenu == false)
        {
            StartText.GetComponent<Text>().enabled = false;
            QuitText.GetComponent<Text>().enabled = false;
        }
    }

    
    void Update()
    {
        StartHole_Score = Starthole.GetComponent<HoleTrigger>().score;
    }
}
