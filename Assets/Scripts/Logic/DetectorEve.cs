using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorEve : Detector
{
  public delegate void addData(PhotonData data);
  public static event addData OnPhotonDetected;
  
  private void  OnTriggerEnter(Collider other) 
  {
    if (other.gameObject.CompareTag("Photon"))
    {
      Photon ph = other.gameObject.GetComponent<Photon>();
      if (ph.GetPolarization() == PhotonPolar.True)
      {
        ph.SetDirection(directionCorrect);
        decodedMessage.Add(ph.data);
        OnPhotonDetected?.Invoke(ph.data);
      }
      else
      { 
        decodedMessage.Add(ph.data);
        ph.SetDirection(directionError);
        OnPhotonDetected?.Invoke(ph.data);
      } // #? add change color

      decodedMessage.Add(ph.data);
    }
  }
  
}
