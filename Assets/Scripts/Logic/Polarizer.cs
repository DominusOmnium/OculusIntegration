using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Polarizer : MonoBehaviour
{
  [SerializeField] protected Basis m_Basis;


  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Photon"))
    { 
      other.gameObject.GetComponent<Photon>().SetBasis(m_Basis);
    }
  }
}
