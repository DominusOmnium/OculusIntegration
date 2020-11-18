using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSourceEve : MonoBehaviour
{
   public List<PhotonData> data;
   [SerializeField] private GameObject photon = null;
   [SerializeField] private Transform shootingPoint;
   [SerializeField] public DisplayImages display;
   private void OnEnable()
   {
      DetectorEve.OnPhotonDetected += AddData;
   }

   void Awake()
   {
      data = new List<PhotonData>();
   }
   private void OnDisable()
   {
      DetectorEve.OnPhotonDetected -= AddData;
   }

   private void ShootPhoton(PhotonData photonDatadata)
   {
      
      if (data.Count > 0)
      {
         Photon inst = Instantiate(photon, shootingPoint.position, Quaternion.identity).GetComponent<Photon>();
         inst.SetSpeed((0.1f * shootingPoint.forward).z);
         inst.SetPolarization(photonDatadata.polarization);
         inst.SetBasis(photonDatadata.basis);
         display.UpdateDisplay();
      }
   }
   void AddData(PhotonData photonDatadata)
   {
      data.Add(photonDatadata);
      ShootPhoton(photonDatadata);
   }

}
