using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [SerializeField]
    OVRInput.Controller controllerType = OVRInput.Controller.None;
    /*[SerializeField]
    XRBaseControllerInteractor controllerInteractor = null;*/
    [SerializeField]
    float hapticUpdateTime = 0.025f;
    [SerializeField]
    float hapticStrength = 0.025f;
    [SerializeField]
    float hapticDelay = 0.5f;

    private InputWatcher inputWatcher;
    private Animator animator;
    private float lastHapticTime;

    private void Awake()
    {
        lastHapticTime = Time.time;
        animator = GetComponent<Animator>();
        inputWatcher = FindObjectOfType<InputWatcher>();
    }

    private void OnEnable()
    {
        if (controllerType == OVRInput.Controller.LTouch)
        {
            inputWatcher.leftIndexTouch.AddListener(onIndexFingerTouch);
            inputWatcher.leftAxisTouch.AddListener(onThumbFingerTouch);
            inputWatcher.leftPrimaryTouch.AddListener(onThumbFingerTouch);
            inputWatcher.leftSecondaryTouch.AddListener(onThumbFingerTouch);
            inputWatcher.leftGripButtonPress.AddListener(onGripButtonPress);
            inputWatcher.leftTriggerButtonPress.AddListener(onTriggerButtonPress);
        }
        else
        {
            inputWatcher.rightIndexTouch.AddListener(onIndexFingerTouch);
            inputWatcher.rightAxisTouch.AddListener(onThumbFingerTouch);
            inputWatcher.rightPrimaryTouch.AddListener(onThumbFingerTouch);
            inputWatcher.rightSecondaryTouch.AddListener(onThumbFingerTouch);
            inputWatcher.rightGripButtonPress.AddListener(onGripButtonPress);
            inputWatcher.rightTriggerButtonPress.AddListener(onTriggerButtonPress);
        }
        //controllerInteractor.onHoverEnter.AddListener(onHoverEnter);
        //controllerInteractor.onHoverExit.AddListener(onHoverExit);
        //controllerInteractor.onSelectEnter.AddListener(onSelectEnter);
        //controllerInteractor.onSelectExit.AddListener(onSelectExit);
    }

    private void OnDisable()
    {
        if (controllerType == OVRInput.Controller.LTouch)
        {
            inputWatcher.leftIndexTouch.RemoveListener(onIndexFingerTouch);
            inputWatcher.leftAxisTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.leftPrimaryTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.leftSecondaryTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.leftGripButtonPress.RemoveListener(onGripButtonPress);
            inputWatcher.leftTriggerButtonPress.RemoveListener(onTriggerButtonPress);
        }
        else
        {
            inputWatcher.rightIndexTouch.RemoveListener(onIndexFingerTouch);
            inputWatcher.rightAxisTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.rightPrimaryTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.rightSecondaryTouch.RemoveListener(onThumbFingerTouch);
            inputWatcher.rightGripButtonPress.RemoveListener(onGripButtonPress);
            inputWatcher.rightTriggerButtonPress.RemoveListener(onTriggerButtonPress);
        }
        //controllerInteractor.onHoverEnter.RemoveListener(onHoverEnter);
        //controllerInteractor.onHoverExit.RemoveListener(onHoverExit);
        //controllerInteractor.onSelectEnter.RemoveListener(onSelectEnter);
        //controllerInteractor.onSelectExit.RemoveListener(onSelectExit);
    }

    /*private void onHoverEnter(XRBaseInteractable interactable)
    {
        animator.SetBool("PrepareSnapping", true);
    }

    private void onHoverExit(XRBaseInteractable interactable)
    {
        animator.SetBool("PrepareSnapping", false);
    }

    private void onSelectEnter(XRBaseInteractable interactable)
    {
        if (controllerType == ControllerType.Left)
        {
            foreach (var c in interactable.colliders)
                if (c.gameObject.layer == LayerMask.NameToLayer("Default") || c.gameObject.layer == LayerMask.NameToLayer("GrabbedByRightHand"))
                    c.gameObject.layer = LayerMask.NameToLayer("GrabbedByLeftHand");
        }
        else
        {
            foreach (var c in interactable.colliders)
                if (c.gameObject.layer == LayerMask.NameToLayer("Default") || c.gameObject.layer == LayerMask.NameToLayer("GrabbedByLeftHand"))
                    c.gameObject.layer = LayerMask.NameToLayer("GrabbedByRightHand");
        }
        animator.SetBool("Snapping", true);
    }

    private void onSelectExit(XRBaseInteractable interactable)
    {
        StartCoroutine(LayerChanging(interactable));
        animator.SetBool("Snapping", false);
    }

    IEnumerator LayerChanging(XRBaseInteractable interactable)
    {
        yield return new WaitForSeconds(0.05f);
        if (controllerType == ControllerType.Left)
        {
            foreach (var c in interactable.colliders)
                if (c.gameObject.layer == LayerMask.NameToLayer("GrabbedByLeftHand"))
                    c.gameObject.layer = LayerMask.NameToLayer("Default");
        }
        else
        {
            foreach (var c in interactable.colliders)
                if (c.gameObject.layer == LayerMask.NameToLayer("GrabbedByRightHand"))
                    c.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }*/

    private void onIndexFingerTouch(bool val)
    {
        animator.SetBool("IndexTouch", val);
    }

    private void onGripButtonPress(float val)
    {
        animator.SetFloat("Grip", val);
    }

    private void onTriggerButtonPress(float val)
    {
        animator.SetFloat("Trigger", val);
    }

    private void onThumbFingerTouch(bool val)
    {
        animator.SetBool("ThumbTouch", val);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time - lastHapticTime < hapticDelay)
            return;
        //controllerInteractor.SendHapticImpulse(hapticStrength, hapticUpdateTime);
        OVRInput.SetControllerVibration(hapticUpdateTime, hapticStrength, controllerType);
        lastHapticTime = Time.time;
    }
}
    