using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject PlayerPrefab;
        

    private void OnTriggerEnter(Collider other)
    {

       
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Help");
            Vector3 position = new Vector3(32, 12, 0);
            Instantiate(PlayerPrefab, position, Quaternion.Euler(0 , 0 , 90));
        }

        Destroy(other.gameObject);
    }
}
