﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject BallPreFab;
    public GameObject StartHole;
    public GameObject QuitHole;
    public GameObject H1;
    public GameObject H2;
    public GameObject H3;
    public GameObject H4;

    public bool inMenu;

    // Start is called before the first frame update
    void Start()
    {
        inMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Begin()
    {
        Vector3 position = new Vector3(0, 13, 0);
        Instantiate(BallPreFab, position, Quaternion.identity);
    }
}
