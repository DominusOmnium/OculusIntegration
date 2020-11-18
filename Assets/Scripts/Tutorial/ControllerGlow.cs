using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;

public class ControllerGlow : MonoBehaviour, IEventInterectable
{
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject effect;

    //[SerializeField] private UnityEvent xBlink;
    [Header("Stuff")]

    [SerializeField] private UnityEvent[] eventList = new UnityEvent[2];
    void Start()
    {
        // _material = GetComponent<MeshRenderer>().material;
    }

    // public void Finish(int nquest)
    // {
    //     throw new System.NotImplementedException();
    // }

    public UnityEvent GetEvent(int i)
    {
        return eventList[i];
    }
    
    public void Resolve(int nquest)
    {
        Debug.Log("Resolve");
        // animator.SetBool("xBlink", true);
        //     effect.GetComponent<VisualEffect>().Play();
        //     
        //     Debug.Log("finished quest0");
        if (nquest ==  0)
        {
            animator.SetBool("xBlink", true);
            effect.GetComponent<VisualEffect>().Play();
            
            Debug.Log("finished quest0");
        }
        else if (nquest == 1)
        {
            animator.SetBool("xBlink", false);
            effect.GetComponent<VisualEffect>().Stop();
            Debug.Log("finished quest1");
        }
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) // collider trigger
        {
            eventList[0]?.Invoke();
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            eventList[1]?.Invoke();
        }
    }
}
