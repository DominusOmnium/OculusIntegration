using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhotonPolar
{
    False,
    True
}
public enum Basis
{
    First,
    Second
}

public class PhotonData
{
     [SerializeField] public PhotonPolar polarization;
     [SerializeField] public Basis basis;

     public PhotonData(Basis b, PhotonPolar p)
     {
         basis = b;
         polarization = p;
     }
     public PhotonData()
     {
         
     }
}
public class Photon : MonoBehaviour
{
    
    [SerializeField] private float speed = 0.7f;
    private Transform m_Transform;
    private Vector3 m_Direction = new Vector3(0,0, 1);
    public  PhotonData data;
    private void Awake()
    {
        data = new PhotonData();
        m_Transform = this.transform;
    }

    private void Update()
    {
        m_Transform.position += m_Direction * (speed * Time.deltaTime);
    }

    public void SetSpeed(float s)
    {
        speed = s;
    }

    public void SetDirection(Vector3 v)
    {
        m_Direction = v;
    }
    public void SetDirection(float x, float y, float z)
    {
        m_Direction = new Vector3(x, y, z);
    }

    public void SetBasis(Basis b)
    {
        data.basis = b;
    }
    public Basis GetBasis()
    {
        return  data.basis;
    }
    public void SetPolarization(PhotonPolar p)
    {
        data.polarization = p;
    }
    public PhotonPolar GetPolarization()
    {
        return  data.polarization;
    }
}
