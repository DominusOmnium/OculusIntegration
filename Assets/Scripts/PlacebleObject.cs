using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class PlacebleObject : MonoBehaviour
{
    public Transform centerOfMass;
    public Transform grabTransform;
    //public Transform attachTransform;
    //public ElementType elementType;

    private void Awake()
    {
        centerOfMass.localPosition = GetComponent<Rigidbody>().centerOfMass;
        //GetComponent<OVRGrabbable>().attachTransform = grabTransform;
    }
}
