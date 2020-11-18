using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    static public Queue<GameEvent> _gameEvents = new Queue<GameEvent>();
    [SerializeField] private GameObject[] objects;
    private int _currentEventObject = 0;
    private bool _eventFinished  = false;
    private void Awake()
    {
        // _gameEvents.Enqueue(new GameEvent("first", 0));
        // _gameEvents.Enqueue(new GameEvent("second", 0));
        // _gameEvents.Enqueue(new GameEvent("third", 0));
      

    }

    private void SubscribeToEvent()
    {
        if (objects[_currentEventObject] != null)
        {
            
            _gameEvents.Peek().gameEvent.AddListener(FinishEvent);
            _eventFinished = false;
        }
        else
        {
            Debug.Log("No events objects");
        }
    }
    private void Start()
    {
        _gameEvents.Enqueue(new GameEvent("First", 0,  objects[0].GetComponent<IEventInterectable>().GetEvent(0), objects[0])); // Subscribe to quest
        _gameEvents.Enqueue(new GameEvent("First", 0,  objects[0].GetComponent<IEventInterectable>().GetEvent(1), objects[0]));

        SubscribeToEvent();
    }

    void FinishEvent()
    {
            Debug.Log("finished: " + _gameEvents.Peek().name);
            GameEvent gameEventTemp = _gameEvents.Peek();
            gameEventTemp.gameEvent.RemoveListener(FinishEvent);
            Debug.Log(gameEventTemp.nEvent);
            Debug.Log(gameEventTemp.parentObject.name);
            if(gameEventTemp.parentObject.GetComponent<IEventInterectable>() != null)
                Debug.Log("Exists");
            else
            {
                Debug.Log("Null");
            }
           gameEventTemp.parentObject.GetComponent<IEventInterectable>().Resolve(gameEventTemp.nEvent); 
            gameEventTemp.SetInactive();
            _gameEvents.Dequeue().data += 1; // if remove this line dont forget Dequeue
            _eventFinished = true;
            _currentEventObject++;
    }
    private void Update()
    {
        if (_eventFinished == true && _gameEvents.Count > 0)
        {
            _gameEvents.Peek().gameEvent.AddListener(FinishEvent);
            _eventFinished = false;
        }
    }
}
