using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        inMenu = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Help");
            Vector3 position = new Vector3(32, 12, 0);
           Instantiate(PlayerPrefab, position, Quaternion.Euler(0 , 0 , 90));

            if(gameObject.name == "StartHole")
            {
                Debug.Log("Start");
                inMenu = false;
                
            }
        }

        if(inMenu == false)
        {
            score = score + 1;
        }



        Destroy(other.gameObject);
    }
}
