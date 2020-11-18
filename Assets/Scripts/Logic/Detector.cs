using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Detector : MonoBehaviour
{
   // [SerializeField] private PhotonPolar polarization;
    [SerializeField] public Vector3 directionCorrect;
    [SerializeField] public Vector3 directionError;
    [SerializeField] public List<PhotonData> decodedMessage;

    private void Awake()
    {
        decodedMessage = new List<PhotonData>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Photon"))
        {
            Photon ph = other.gameObject.GetComponent<Photon>();
            if (ph.GetPolarization() == PhotonPolar.True)
                ph.SetDirection(directionCorrect);
            else
                ph.SetDirection(directionError);                 // #? add change color
            decodedMessage.Add(ph.data);
        }
    }

    public List<PhotonData> GetData()
    {
        return  decodedMessage;
    }
    public void ClearDecodedMessage()
    {
        decodedMessage.Clear();
    }
}
