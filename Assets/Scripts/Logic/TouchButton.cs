﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchButton : MonoBehaviour, IInteractive 
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Execute()
    {
        Print();
    }

    public void Print()
    {
        Debug.Log("Hello");
    }
}
