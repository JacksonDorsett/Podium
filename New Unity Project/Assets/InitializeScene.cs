﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
public class InitializeScene : MonoBehaviour
{
    private GameObject server;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        if (GlobalControl.Instance.isHost)
        {
            InitializeHost();
        }
        else
        {
            InitializeNormal();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitializeHost()
    {
        GameObject.Instantiate(Resources.Load("Server") as GameObject);
    }
    private void InitializeNormal()
    {
        GameObject.Instantiate(Resources.Load("Client") as GameObject);
    }
}
