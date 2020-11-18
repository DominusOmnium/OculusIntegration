using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandWithControllerController : MonoBehaviour
{
    enum ControllerType { Left, Right }
    [SerializeField]
    ControllerType controllerType;
    [SerializeField]
    Animator thumbAnimator;

    private InputWatcher inputWatcher;
    private Animator animator;
    private float axisPress = 0.0f;
    private float primaryPress = 0.0f;
    private float secondaryPress = 0.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputWatcher = FindObjectOfType<InputWatcher>();
        if (inputWatcher is null)
            Debug.LogError("No XRInputWatcher on scene!");
    }

    private void OnEnable()
    {
        if (controllerType == ControllerType.Left)
        {
            inputWatcher.leftIndexTouch.AddListener(onIndexFingerTouch);
            inputWatcher.leftAxisTouch.AddListener(onAxisTouch);
            inputWatcher.leftPrimaryTouch.AddListener(onPrimaryTouch);
            inputWatcher.leftSecondaryTouch.AddListener(onSecondaryTouch);
            inputWatcher.leftPrimaryButtonPress.AddListener(onPrimaryPress);
            inputWatcher.leftSecondaryButtonPress.AddListener(onSecondaryPress);
            inputWatcher.leftAxisPress.AddListener(onAxisPress);
            inputWatcher.leftGripButtonPress.AddListener(onGripButtonPress);
            inputWatcher.leftTriggerButtonPress.AddListener(onTriggerButtonPress);
        }
        else
        {
            inputWatcher.rightIndexTouch.AddListener(onIndexFingerTouch);
            inputWatcher.rightAxisTouch.AddListener(onAxisTouch);
            inputWatcher.rightPrimaryTouch.AddListener(onPrimaryTouch);
            inputWatcher.rightSecondaryTouch.AddListener(onSecondaryTouch);
            inputWatcher.rightPrimaryButtonPress.AddListener(onPrimaryPress);
            inputWatcher.rightSecondaryButtonPress.AddListener(onSecondaryPress);
            inputWatcher.rightAxisPress.AddListener(onAxisPress);
            inputWatcher.rightGripButtonPress.AddListener(onGripButtonPress);
            inputWatcher.rightTriggerButtonPress.AddListener(onTriggerButtonPress);
        }
    }

    private void OnDisable()
    {
        if (controllerType == ControllerType.Left)
        {
            inputWatcher.leftIndexTouch.RemoveListener(onIndexFingerTouch);
            inputWatcher.leftAxisTouch.RemoveListener(onAxisTouch);
            inputWatcher.leftPrimaryTouch.RemoveListener(onPrimaryTouch);
            inputWatcher.leftSecondaryTouch.RemoveListener(onSecondaryTouch);
            inputWatcher.leftPrimaryButtonPress.RemoveListener(onPrimaryPress);
            inputWatcher.leftSecondaryButtonPress.RemoveListener(onSecondaryPress);
            inputWatcher.leftAxisPress.RemoveListener(onAxisPress);
            inputWatcher.leftGripButtonPress.RemoveListener(onGripButtonPress);
            inputWatcher.leftTriggerButtonPress.RemoveListener(onTriggerButtonPress);
        }
        else
        {
            inputWatcher.rightIndexTouch.RemoveListener(onIndexFingerTouch);
            inputWatcher.rightAxisTouch.RemoveListener(onAxisTouch);
            inputWatcher.rightPrimaryTouch.RemoveListener(onPrimaryTouch);
            inputWatcher.rightSecondaryTouch.RemoveListener(onSecondaryTouch);
            inputWatcher.rightPrimaryButtonPress.RemoveListener(onPrimaryPress);
            inputWatcher.rightSecondaryButtonPress.RemoveListener(onSecondaryPress);
            inputWatcher.rightAxisPress.RemoveListener(onAxisPress);
            inputWatcher.rightGripButtonPress.RemoveListener(onGripButtonPress);
            inputWatcher.rightTriggerButtonPress.RemoveListener(onTriggerButtonPress);
        }
    }

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

    private void onPrimaryPress(bool val)
    {
        thumbAnimator.SetBool("PrimaryPress", val);
    }

    private void onSecondaryPress(bool val)
    {
        thumbAnimator.SetBool("SecondaryPress", val);
    }

    private void onAxisPress(bool val)
    {
        thumbAnimator.SetBool("AxisPress", val);
    }

    private void onAxisTouch(bool val)
    {
        thumbAnimator.SetBool("AxisTouch", val);
    }

    private void onPrimaryTouch(bool val)
    {
        thumbAnimator.SetBool("PrimaryTouch", val);
    }

    private void onSecondaryTouch(bool val)
    {
        thumbAnimator.SetBool("SecondaryTouch", val);
    }
}
