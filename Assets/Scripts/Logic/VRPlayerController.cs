using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class VRPlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject leftHandDirectInteractor  = null;
    [SerializeField]
    GameObject rightHandDirectInteractor  = null;
    [SerializeField]
    GameObject leftHandUIRayInteractor  = null;
    [SerializeField]
    GameObject rightHandUIRayInteractor  = null;
    [SerializeField]
    GameObject rightHandTeleportRayInteractor;
    [SerializeField, Range(0.0f, 1.0f)]
    float teleportThreshold = 0.7f;
    [SerializeField, Range(0.0f, 1.0f)]
    float UIRayThreshold = 0.5f;

    private InputWatcher inputWatcher  = null;

    private void Awake()
    {
        inputWatcher = FindObjectOfType<InputWatcher>();
        if (inputWatcher == null)
            Debug.LogError("No XRInputWatcher on scene");
    }

    private void OnEnable()
    {
        inputWatcher.leftTriggerButtonPress.AddListener(onLeftTriggerButtonPress);
        inputWatcher.rightTriggerButtonPress.AddListener(onRightTriggerButtonPress);
        inputWatcher.rightPrimary2DAxisEvent.AddListener(onRightPrimaryAxis2DChange);
    }

    private void OnDisable()
    {
        inputWatcher.leftTriggerButtonPress.RemoveListener(onLeftTriggerButtonPress);
        inputWatcher.rightTriggerButtonPress.RemoveListener(onRightTriggerButtonPress);
        inputWatcher.rightPrimary2DAxisEvent.RemoveListener(onRightPrimaryAxis2DChange);
    }

    private void onLeftTriggerButtonPress(float value)
    {
        if (value >= UIRayThreshold)
        {
            //leftHandDirectInteractor.SetActive(false);
            leftHandUIRayInteractor.SetActive(true);
        }
        else
        {
            //leftHandDirectInteractor.SetActive(true);
            leftHandUIRayInteractor.SetActive(false);
        }
    }

    private void onRightTriggerButtonPress(float value)
    {
        if (value >= UIRayThreshold && !rightHandUIRayInteractor.activeSelf && !rightHandTeleportRayInteractor.activeSelf)
        {
            //rightHandDirectInteractor.SetActive(false);
            rightHandUIRayInteractor.SetActive(true);
        }
        else if (value < UIRayThreshold)
        {
            //rightHandDirectInteractor.SetActive(true);
            rightHandUIRayInteractor.SetActive(false);
        }
    }

    private void onRightPrimaryAxis2DChange(Vector2 axis)
    {
        if (axis.y >= teleportThreshold && !rightHandUIRayInteractor.activeSelf && !rightHandTeleportRayInteractor.activeSelf)
        {
            //rightHandDirectInteractor.SetActive(false);
            rightHandTeleportRayInteractor.SetActive(true);
        }
        else if (axis.y < teleportThreshold)
        {
            //rightHandDirectInteractor.SetActive(true);
            rightHandTeleportRayInteractor.SetActive(false);
        }
    }
}
