using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
[RequireComponent(typeof(Collider))]

public class ReadPolarizer : Polarizer
{
    private void OnTriggerEnter(Collider other)
    {
        Photon ph = other.gameObject.GetComponent<Photon>();

        if (other.gameObject.CompareTag("Photon"))
        {
            if (ph.GetBasis() != m_Basis)
            {
                ph.SetBasis(m_Basis);
                int a =  Random.Range(0,2);
                ph.SetPolarization((PhotonPolar)a); 
            }
        }
    }
}
