using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestEvent : MonoBehaviour
{
    public enum EventStatus
    {
        Waiting,
        Current,
        Done
    };

    public string questName;
    public string description;
    public string id;
    public EventStatus status;
    
    public List<QuestPath> pathlist = new List<QuestPath>();

    public QuestEvent(string n, string d)
    {
        id = Guid.NewGuid().ToString();
        name = n;
        description = d;
        
    }
}
