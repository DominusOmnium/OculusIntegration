using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UIElements;


public class LightSource : MonoBehaviour
{
    [SerializeField] private GameObject proton = null;
    [SerializeField] public PhotonPolar polarization ;
    [SerializeField] private bool multiple = false;
    [SerializeField] private List<PhotonData> data = null;
    [SerializeField] private float speed = 0;
    [SerializeField] private int dataCounter = 0;
    private float _instantiationTimer = 2f;
    private bool _shoot  = false;
    [SerializeField] private Transform shootingPoint = null;
    [SerializeField] private DisplayImages uiControl = null;
    [SerializeField] private PrefabricatedController bobState  = null;
    [SerializeField] private PrefabricatedController aliceState  = null;

    private void Start()
    {
        data = new List<PhotonData>();
    }

    public List<PhotonData> GetData()
    {
        return data; 
    }
    public void AddPhotonOne()
    { 
        data.Add(new PhotonData(Basis.First, PhotonPolar.True));
    }

    public void ChangePhotonBasis(int nPhoton)
    {
        if (data.Count >= nPhoton)
        {
            if (data[nPhoton].basis == Basis.First)
                data[nPhoton].basis = Basis.Second;
            else
            {
               data[nPhoton].basis = Basis.First; 
            }
        }
    }
    public void ChangePhotonPolar(int nPhoton)
    {
        if (data.Count >= nPhoton)
        {
            if (data[nPhoton].polarization == PhotonPolar.True)
                data[nPhoton].polarization = PhotonPolar.False;
            else
            {
               data[nPhoton].polarization = PhotonPolar.True; 
            }
        }
    }

    public void SpawnProton()
    {
        if (data.Count > 0 && bobState.state == PrefabricatedState.Correct && aliceState.state == PrefabricatedState.Correct)
        {
            Photon inst = Instantiate(proton, shootingPoint.position, Quaternion.identity).GetComponent<Photon>();
            inst.SetSpeed((speed * shootingPoint.forward).z);
            inst.SetPolarization(data[data.Count - 1].polarization);
            inst.SetBasis(data[data.Count - 1].basis);
            data.RemoveAt(data.Count - 1);
        }
    }
    
    public void SpawnMultiple()
    {
        _shoot = true;
        Photon inst = Instantiate(proton, shootingPoint.position, Quaternion.identity).GetComponent<Photon>();
        inst.SetSpeed((speed * shootingPoint.forward).z);
        
        if (data.Count < 1)
            throw new Exception("Wrong length of arrays " + data.Count);
        inst.SetBasis(data[dataCounter].basis);
        inst.SetPolarization(data[dataCounter].polarization);
        _instantiationTimer = 2f;
        dataCounter++;
        if (dataCounter >= data.Count)
        {
            dataCounter = 0;
            _shoot = false;
        }
    }
    void Update()
    {

         // _instantiationTimer -= Time.deltaTime;
         // if (Input.GetKeyDown(KeyCode.A))
         // {
         //     if (multiple)
         //         _shoot = true;
         //     else
         //         SpawnProton(polarization);
         // }
         //
         // if (_shoot && dataCounter > 0 && _instantiationTimer <= 0)
         //     SpawnMultiple();
         uiControl.UpdateDisplay(); // change to only on changes
    }


    public void ResetPhotons()
    {
        data.Clear();
        dataCounter = 0;
    }
    
}
