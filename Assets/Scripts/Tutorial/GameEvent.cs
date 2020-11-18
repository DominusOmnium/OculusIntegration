using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class GameEvent
{
    public string name;
    // public UnityAction action;
    private static int countEvents = 0;
    public int nEvent = 0;
    public int data = 0;
    private bool _isActive = false;
    public UnityEvent gameEvent;
    public GameObject parentObject;
    public GameEvent(string n, int d, UnityEvent g, GameObject o)
    {
        name = n;
        data = d;
        gameEvent = g;
        parentObject = o;
        nEvent = countEvents;
        if (parentObject == null)
            Debug.Log("Null in constructer");
        countEvents++;
    }

    public void SetActive()
    {
        _isActive = true;
    }

    public void SetInactive()
    {
        _isActive = false;
    }
}
