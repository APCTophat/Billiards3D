using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject PlayerPrefab
        ;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
