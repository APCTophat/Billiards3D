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
    public Text Winner;

    public int P1_totalScore;
    public int P2_totalScore;
    public int StartHole_Score;
    public int QuitHole_Score;
    public int H1_Score;
    public int H2_Score;
    public int H3_Score;
    public int H4_Score;
    public int StartHole_Score_2;
    public int QuitHole_Score_2;
    public int H1_Score_2;
    public int H2_Score_2;
    public int H3_Score_2;
    public int H4_Score_2;

    public bool inMenu;
    public bool isPlayer_1;



    void Start()
    {
        isPlayer_1 = true;
        Winner.GetComponent<Text>().enabled = false;
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
            StartHole_Score = Starthole.GetComponent<HoleTrigger>().score_P1;
            QuitHole_Score = Quithole.GetComponent<HoleTrigger>().score_P1;
            H1_Score = H1.GetComponent<HoleTrigger>().score_P1;
            H2_Score = H2.GetComponent<HoleTrigger>().score_P1;
            H3_Score = H3.GetComponent<HoleTrigger>().score_P1;
            H4_Score = H4.GetComponent<HoleTrigger>().score_P1;

            P1_totalScore = StartHole_Score + QuitHole_Score + H1_Score + H2_Score + H3_Score + H4_Score;

            P1_TotalScore.text = ("Player 1:" + P1_totalScore.ToString());

            StartHole_Score_2 = Starthole.GetComponent<HoleTrigger>().score_P2;
            QuitHole_Score_2 = Quithole.GetComponent<HoleTrigger>().score_P2;
            H1_Score_2 = H1.GetComponent<HoleTrigger>().score_P2;
            H2_Score_2 = H2.GetComponent<HoleTrigger>().score_P2;
            H3_Score_2 = H3.GetComponent<HoleTrigger>().score_P2;
            H4_Score_2 = H4.GetComponent<HoleTrigger>().score_P2;

            P2_totalScore = StartHole_Score_2 + QuitHole_Score_2 + H1_Score_2 + H2_Score_2 + H3_Score_2 + H4_Score_2;

            P2_TotalScore.text = ("Player 2:" + P2_totalScore.ToString());
        }
        if (Input.GetKeyUp(KeyCode.P))
        {

            Invoke("Did_P1_WIn", 0);


        }
    }

    void Did_P1_WIn()
    {
        if(isPlayer_1 == true)
        {
            if (P2_totalScore <= 7)
            {
                Winner.GetComponent<Text>().enabled = true;
                Winner.text = ("Player 1 Wins!");

            }
            if (P2_totalScore >= 7)
            {
                Winner.GetComponent<Text>().enabled = true;
                Winner.text = ("Player 2 Wins!");

            }
        }
        if(isPlayer_1 == false)
        {
            if (P1_totalScore <= 7)
            {
                Winner.GetComponent<Text>().enabled = true;
                Winner.text = ("Player 2 Wins!");

            }
            if (P1_totalScore >= 7)
            {
                Winner.GetComponent<Text>().enabled = true;
                Winner.text = ("Player 1 Wins!");
            }
        }
        

        
    }

  
    
    void SwitchPlayer()
    {
        isPlayer_1 = !isPlayer_1;

    }
}