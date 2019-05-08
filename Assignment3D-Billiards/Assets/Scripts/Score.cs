using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text P1_TotalScore;
    public Text P2_TotalScore;

    public int P1_totalScore;
    public int P2_totalScore;

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
            GetComponent<Text>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
