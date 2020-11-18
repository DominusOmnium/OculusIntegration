using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    private Transform _originalTransform;
    private void Awake()
    {
        _originalTransform = this.transform;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            this.transform.position = _originalTransform.position;
            this.transform.rotation = _originalTransform.rotation;
        }
    }
}
