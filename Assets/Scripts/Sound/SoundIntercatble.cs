using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class SoundIntercatble : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rb;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Furniture") || other.gameObject.CompareTag("Floor"))
        {
            if (_rb.velocity.magnitude > 0.9f)
            {
                _audioSource.volume = 0.3f;
                SoundManager.Play("DropPlasticOnTable", _audioSource);
            }
        }
    }


   

    public  void SoundOnAttachSocket()
    {
        SoundManager.Play("SnapObject", _audioSource);
    }
  
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
