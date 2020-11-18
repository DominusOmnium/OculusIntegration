using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class testd : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private UnityEvent[] _events;
    void Start()
    {
            _events[0].AddListener(Print);
    }    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _events[0].Invoke();
        }
    }

    void Print()
    {
        Debug.Log("ASdsadas");
    }
}
