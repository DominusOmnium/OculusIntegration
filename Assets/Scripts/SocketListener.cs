using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketListener : MonoBehaviour
{
    /*Transform attachTransform;
    XRSocketInteractor socketInteractor;
    Collider trigger;
    private void Start()
    {
        trigger = GetComponent<Collider>();
        socketInteractor = GetComponent<XRSocketInteractor>();
        socketInteractor.onSelectEnter.AddListener(Socket_onSelectEnter);
        socketInteractor.onSelectExit.AddListener(Socket_onSelectExit);
        attachTransform = GetComponent<XRSocketInteractor>().attachTransform;
    }

    void Socket_onSelectEnter(XRBaseInteractable interactable)
    {
        Quaternion snapRotation;

        trigger.enabled = false;
        float y = interactable.transform.eulerAngles.y;
        Debug.Log(y);
        if (y < 20f || y > 340f)
            snapRotation = Quaternion.Euler(attachTransform.eulerAngles.x, 0f, attachTransform.eulerAngles.z);
        else if (y < 110f && y > 70f)
            snapRotation = Quaternion.Euler(attachTransform.eulerAngles.x, 90f, attachTransform.eulerAngles.z);
        else if (y < 200f && y > 160f)
            snapRotation = Quaternion.Euler(attachTransform.eulerAngles.x, 180f, attachTransform.eulerAngles.z);
        else if (y < 290f && y > 250f)
            snapRotation = Quaternion.Euler(attachTransform.eulerAngles.x, 240f, attachTransform.eulerAngles.z);
        else
            snapRotation = Quaternion.Euler(attachTransform.eulerAngles.x, interactable.transform.eulerAngles.y, attachTransform.eulerAngles.z);
        attachTransform.rotation = snapRotation;
        Debug.Log("onSelectEnter");
    }

    void Socket_onSelectExit(XRBaseInteractable interactable)
    {
        trigger.enabled = true;
        Debug.Log("onSelectExit");
    }

    private void OnTriggerEnter(Collider other)
    {
        PlacebleObject placeble;

        if ((placeble = other.GetComponentInParent<PlacebleObject>()) != null)
            attachTransform.localPosition = new Vector3(attachTransform.localPosition.x, placeble.centerOfMass.localPosition.y*0.007f, attachTransform.localPosition.z);
    }*/
}
