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
    public int QuitHole_Score;
    public int H1_Score;
    public int H2_Score;
    public int H3_Score;
    public int H4_Score;

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
        if (inMenu == false)
        {
            StartHole_Score = Starthole.GetComponent<HoleTrigger>().score;
            QuitHole_Score = Quithole.GetComponent<HoleTrigger>().score;
            H1_Score = H1.GetComponent<HoleTrigger>().score;
            H2_Score = H2.GetComponent<HoleTrigger>().score;
            H3_Score = H3.GetComponent<HoleTrigger>().score;
            H4_Score = H4.GetComponent<HoleTrigger>().score;

            P1_totalScore = StartHole_Score + QuitHole_Score + H1_Score + H2_Score + H3_Score + H4_Score;

            P1_TotalScore.text = ("Player 1:" + P1_totalScore.ToString());
        }
      
    }
}
