using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[System.Serializable]
public class TrigggerButtonEvent : UnityEvent<float> { }
[System.Serializable]
public class GripButtonEvent : UnityEvent<float> { }
[System.Serializable]
public class ButtonPressEvent : UnityEvent<bool> { }
[System.Serializable]
public class TouchEvent : UnityEvent<bool> { }
[System.Serializable]
public class Axis2DEvent : UnityEvent<Vector2> { }

public class InputWatcher : MonoBehaviour
{
    InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
    InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

    /* EVENTS */
    public TrigggerButtonEvent leftTriggerButtonPress;
    public GripButtonEvent leftGripButtonPress;
    public TouchEvent leftAxisTouch;
    public TouchEvent leftPrimaryTouch;
    public TouchEvent leftSecondaryTouch;
    public TouchEvent leftIndexTouch;
    public ButtonPressEvent leftPrimaryButtonPress;
    public ButtonPressEvent leftSecondaryButtonPress;
    public ButtonPressEvent leftAxisPress;

    public TrigggerButtonEvent rightTriggerButtonPress;
    public GripButtonEvent rightGripButtonPress;
    public TouchEvent rightAxisTouch;
    public TouchEvent rightPrimaryTouch;
    public TouchEvent rightSecondaryTouch;
    public TouchEvent rightIndexTouch;
    public ButtonPressEvent rightPrimaryButtonPress;
    public ButtonPressEvent rightSecondaryButtonPress;
    public ButtonPressEvent rightAxisPress;

    public Axis2DEvent leftPrimary2DAxisEvent;
    public Axis2DEvent rightPrimary2DAxisEvent;


    private float _lastLeftTriggerButtonState = 0.0f;
    private float _lastLeftGripButtonState = 0.0f;
    private bool _lastLeftIndexTouchState = false;
    private bool _lastLeftAxisTouchState = false;
    private bool _lastLeftPrimaryTouchState = false;
    private bool _lastLeftSecondaryTouchState = false;
    private bool _lastLeftPrimaryButtonState = false;
    private bool _lastLeftSecondaryButtonState = false;
    private bool _lastLeftAxisButtonState = false;
    private Vector2 _lastLeftPrimary2DAxisState = Vector2.zero;
    private float lastLeftTriggerButtonState
    {
        get => _lastLeftTriggerButtonState;
        set
        {
            if (_lastLeftTriggerButtonState == value)
                return;
            _lastLeftTriggerButtonState = value;
            leftTriggerButtonPress?.Invoke(value);
        }
    }
    private float lastLeftGripButtonState
    {
        get => _lastLeftGripButtonState;
        set
        {
            if (_lastLeftGripButtonState == value)
                return;
            _lastLeftGripButtonState = value;
            leftGripButtonPress?.Invoke(value);
        }
    }
    private bool lastLeftIndexTouchState
    {
        get => _lastLeftIndexTouchState;
        set
        {
            if (_lastLeftIndexTouchState == value)
                return;
            _lastLeftIndexTouchState = value;
            leftIndexTouch?.Invoke(value);
        }
    }
    private bool lastLeftAxisTouchState
    {
        get => _lastLeftAxisTouchState;
        set
        {
            if (_lastLeftAxisTouchState == value)
                return;
            _lastLeftAxisTouchState = value;
            leftAxisTouch?.Invoke(value);
        }
    }
    private bool lastLeftPrimaryTouchState
    {
        get => _lastLeftPrimaryTouchState;
        set
        {
            if (_lastLeftPrimaryTouchState == value)
                return;
            _lastLeftPrimaryTouchState = value;
            leftPrimaryTouch?.Invoke(value);
        }
    }
    private bool lastLeftSecondaryTouchState
    {
        get => _lastLeftSecondaryTouchState;
        set
        {
            if (_lastLeftSecondaryTouchState == value)
                return;
            _lastLeftSecondaryTouchState = value;
            leftSecondaryTouch?.Invoke(value);
        }
    }
    private bool lastLeftPrimaryButtonState
    {
        get => _lastLeftPrimaryButtonState;
        set
        {
            if (_lastLeftPrimaryButtonState == value)
                return;
            _lastLeftPrimaryButtonState = value;
            leftPrimaryButtonPress?.Invoke(value);
        }
    }
    private bool lastLeftSecondaryButtonState
    {
        get => _lastLeftSecondaryButtonState;
        set
        {
            if (_lastLeftSecondaryButtonState == value)
                return;
            _lastLeftSecondaryButtonState = value;
            leftSecondaryButtonPress?.Invoke(value);
        }
    }
    private bool lastLeftAxisButtonState
    {
        get => _lastLeftAxisButtonState;
        set
        {
            if (_lastLeftAxisButtonState == value)
                return;
            _lastLeftAxisButtonState = value;
            leftAxisPress?.Invoke(value);
        }
    }
    private Vector2 lastLeftPrimary2DAxisState
    {
        get => _lastLeftPrimary2DAxisState;
        set
        {
            if (_lastLeftPrimary2DAxisState == value)
                return;
            _lastLeftPrimary2DAxisState = value;
            leftPrimary2DAxisEvent?.Invoke(value);
        }
    }



    private float _lastRightTriggerButtonState = 0.0f;
    private float _lastRightGripButtonState = 0.0f;
    private bool _lastRightIndexTouchState = false;
    private bool _lastRightAxisTouchState = false;
    private bool _lastRightPrimaryTouchState = false;
    private bool _lastRightSecondaryTouchState = false;
    private bool _lastRightPrimaryButtonState = false;
    private bool _lastRightSecondaryButtonState = false;
    private bool _lastRightAxisButtonState = false;
    private Vector2 _lastRightPrimary2DAxisState = Vector2.zero;
    private float lastRightTriggerButtonState
    {
        get => _lastRightTriggerButtonState;
        set
        {
            if (_lastRightTriggerButtonState == value)
                return;
            _lastRightTriggerButtonState = value;
            rightTriggerButtonPress?.Invoke(value);
        }
    }
    private float lastRightGripButtonState
    {
        get => _lastRightGripButtonState;
        set
        {
            if (_lastRightGripButtonState == value)
                return;
            _lastRightGripButtonState = value;
            rightGripButtonPress?.Invoke(value);
        }
    }
    private bool lastRightIndexTouchState
    {
        get => _lastRightIndexTouchState;
        set
        {
            if (_lastRightIndexTouchState == value)
                return;
            _lastRightIndexTouchState = value;
            rightIndexTouch?.Invoke(value);
        }
    }
    private bool lastRightAxisTouchState
    {
        get => _lastRightAxisTouchState;
        set
        {
            if (_lastRightAxisTouchState == value)
                return;
            _lastRightAxisTouchState = value;
            rightAxisTouch?.Invoke(value);
        }
    }
    private bool lastRightPrimaryTouchState
    {
        get => _lastRightPrimaryTouchState;
        set
        {
            if (_lastRightPrimaryTouchState == value)
                return;
            _lastRightPrimaryTouchState = value;
            rightPrimaryTouch?.Invoke(value);
        }
    }
    private bool lastRightSecondaryTouchState
    {
        get => _lastRightSecondaryTouchState;
        set
        {
            if (_lastRightSecondaryTouchState == value)
                return;
            _lastRightSecondaryTouchState = value;
            rightSecondaryTouch?.Invoke(value);
        }
    }
    private bool lastRightPrimaryButtonState
    {
        get => _lastRightPrimaryButtonState;
        set
        {
            if (_lastRightPrimaryButtonState == value)
                return;
            _lastRightPrimaryButtonState = value;
            rightPrimaryButtonPress?.Invoke(value);
        }
    }
    private bool lastRightSecondaryButtonState
    {
        get => _lastRightSecondaryButtonState;
        set
        {
            if (_lastRightSecondaryButtonState == value)
                return;
            _lastRightSecondaryButtonState = value;
            rightSecondaryButtonPress?.Invoke(value);
        }
    }
    private bool lastRightAxisButtonState
    {
        get => _lastRightAxisButtonState;
        set
        {
            if (_lastRightAxisButtonState == value)
                return;
            _lastRightAxisButtonState = value;
            rightAxisPress?.Invoke(value);
        }
    }
    private Vector2 lastRightPrimary2DAxisState
    {
        get => _lastRightPrimary2DAxisState;
        set
        {
            if (_lastRightPrimary2DAxisState == value)
                return;
            _lastRightPrimary2DAxisState = value;
            rightPrimary2DAxisEvent?.Invoke(value);
        }
    }



    private List<InputDevice> leftHandDevices;
    private List<InputDevice> rightHandDevices;

    void Awake()
    {
        leftHandDevices = new List<InputDevice>();
        rightHandDevices = new List<InputDevice>();


        if (leftTriggerButtonPress == null)
            leftTriggerButtonPress = new TrigggerButtonEvent();
        if (leftGripButtonPress == null)
            leftGripButtonPress = new GripButtonEvent();
        if (leftAxisTouch == null)
            leftAxisTouch = new TouchEvent();
        if (leftIndexTouch == null)
            leftIndexTouch = new TouchEvent();
        if (leftPrimaryTouch == null)
            leftPrimaryTouch = new TouchEvent();
        if (leftSecondaryTouch == null)
            leftSecondaryTouch = new TouchEvent();
        if (leftAxisPress == null)
            leftAxisPress = new ButtonPressEvent();
        if (leftPrimaryButtonPress == null)
            leftPrimaryButtonPress = new ButtonPressEvent();
        if (leftSecondaryButtonPress == null)
            leftSecondaryButtonPress = new ButtonPressEvent();


        if (rightTriggerButtonPress == null)
            rightTriggerButtonPress = new TrigggerButtonEvent();
        if (rightGripButtonPress == null)
            rightGripButtonPress = new GripButtonEvent();
        if (rightAxisTouch == null)
            rightAxisTouch = new TouchEvent();
        if (rightIndexTouch == null)
            rightIndexTouch = new TouchEvent();
        if (rightPrimaryTouch == null)
            rightPrimaryTouch = new TouchEvent();
        if (rightSecondaryTouch == null)
            rightSecondaryTouch = new TouchEvent();
        if (rightAxisPress == null)
            rightAxisPress = new ButtonPressEvent();
        if (rightPrimaryButtonPress == null)
            rightPrimaryButtonPress = new ButtonPressEvent();
        if (rightSecondaryButtonPress == null)
            rightSecondaryButtonPress = new ButtonPressEvent();


        if (leftPrimary2DAxisEvent == null)
            leftPrimary2DAxisEvent = new Axis2DEvent();
        if (rightPrimary2DAxisEvent == null)
            rightPrimary2DAxisEvent = new Axis2DEvent();
    }

    void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
            InputDevices_deviceConnected(device);

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        leftHandDevices.Clear();
        rightHandDevices.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        if ((device.characteristics & leftControllerCharacteristics) == leftControllerCharacteristics)
            leftHandDevices.Add(device);
        if ((device.characteristics & rightControllerCharacteristics) == rightControllerCharacteristics)
            rightHandDevices.Add(device);
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (leftHandDevices.Contains(device))
            leftHandDevices.Remove(device);
        if (rightHandDevices.Contains(device))
            rightHandDevices.Remove(device);
    }


    void Update()
    {
        float   float_value;
        bool    bool_value;
        Vector2 vec2_value;

        /*   LEFT TRIGGER EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.LIndexTrigger)) != lastLeftIndexTouchState)
            lastLeftIndexTouchState = bool_value;
        if ((float_value = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger)) != lastLeftTriggerButtonState)
            lastLeftTriggerButtonState = float_value;

        /*   LEFT GRIP EVENTS   */
        if ((float_value = OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger)) != lastLeftGripButtonState)
            lastLeftGripButtonState = float_value;

        /*   LEFT BUTTONS X/Y EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.X)) != lastLeftPrimaryTouchState)
            lastLeftPrimaryTouchState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.X)) != lastLeftPrimaryButtonState)
            lastLeftPrimaryButtonState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.Y)) != lastLeftSecondaryTouchState)
            lastLeftSecondaryTouchState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.Y)) != lastLeftSecondaryButtonState)
            lastLeftSecondaryButtonState = bool_value;

        /*   LEFT THUMBSTICK EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.LThumbstick)) != lastLeftAxisTouchState)
            lastLeftAxisTouchState = bool_value;
        if ((vec2_value = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick)) != lastLeftPrimary2DAxisState)
            lastLeftPrimary2DAxisState = vec2_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.LThumbstick)) != lastLeftAxisButtonState)
            lastLeftAxisButtonState = bool_value;



        /*   RIGHT TRIGGER EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.RIndexTrigger)) != lastRightIndexTouchState)
            lastRightIndexTouchState = bool_value;
        if ((float_value = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger)) != lastRightTriggerButtonState)
            lastRightTriggerButtonState = float_value;

        /*   RIGHT GRIP EVENTS   */
        if ((float_value = OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)) != lastRightGripButtonState)
            lastRightGripButtonState = float_value;

        /*   RIGHT BUTTONS A/B EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.A)) != lastRightPrimaryTouchState)
            lastRightPrimaryTouchState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.A)) != lastRightPrimaryButtonState)
            lastRightPrimaryButtonState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.B)) != lastRightSecondaryTouchState)
            lastRightSecondaryTouchState = bool_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.B)) != lastRightSecondaryButtonState)
            lastRightSecondaryButtonState = bool_value;

        /*   RIGHT THUMBSTICK EVENTS   */
        if ((bool_value = OVRInput.Get(OVRInput.RawTouch.RThumbstick)) != lastRightAxisTouchState)
            lastRightAxisTouchState = bool_value;
        if ((vec2_value = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick)) != lastRightPrimary2DAxisState)
            lastRightPrimary2DAxisState = vec2_value;
        if ((bool_value = OVRInput.Get(OVRInput.RawButton.RThumbstick)) != lastRightAxisButtonState)
            lastRightAxisButtonState = bool_value;


        /*if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonState)
                    && triggerButtonState != lastLeftTriggerButtonState)
            lastLeftTriggerButtonState = triggerButtonState;
        if (device.TryGetFeatureValue(CommonUsages.grip, out float gripButtonState)
                    && gripButtonState != lastLeftGripButtonState)
            lastLeftGripButtonState = gripButtonState;
        if (device.TryGetFeatureValue(CommonUsages.indexTouch, out float indexTouch))
            lastLeftIndexTouchState = indexTouch > 0.01f ? true : false;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool primary2DAxisTouch)
                    && primary2DAxisTouch != lastLeftAxisTouchState)
           lastLeftAxisTouchState = primary2DAxisTouch;
        if (device.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouch)
                    && primaryTouch != lastLeftPrimaryTouchState)
            lastLeftPrimaryTouchState = primaryTouch;
        if (device.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouch)
                    && secondaryTouch != lastLeftSecondaryTouchState)
            lastLeftSecondaryTouchState = secondaryTouch;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxis)
                    && primary2DAxis != lastLeftPrimary2DAxisState)
            lastLeftPrimary2DAxisState = primary2DAxis;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton)
                    && primaryButton != lastLeftPrimaryButtonState)
            lastLeftPrimaryButtonState = primaryButton;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton)
                    && secondaryButton != lastLeftSecondaryButtonState)
            lastLeftSecondaryButtonState = secondaryButton;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2DAxisClick)
                    && primary2DAxisClick != lastLeftAxisButtonState)
            lastLeftAxisButtonState = primary2DAxisClick;*/


        /*if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonState)
                    && triggerButtonState != lastRightTriggerButtonState)
            lastRightTriggerButtonState = triggerButtonState;
        if (device.TryGetFeatureValue(CommonUsages.grip, out float gripButtonState)
                    && gripButtonState != lastRightGripButtonState)
            lastRightGripButtonState = gripButtonState;
        if (device.TryGetFeatureValue(CommonUsages.indexTouch, out float indexTouch))
            lastRightIndexTouchState = indexTouch > 0.01f ? true : false;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisTouch, out bool primary2DAxisTouch)
                    && primary2DAxisTouch != lastRightAxisTouchState)
            lastRightAxisTouchState = primary2DAxisTouch;
        if (device.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouch)
                    && primaryTouch != lastRightPrimaryTouchState)
            lastRightPrimaryTouchState = primaryTouch;
        if (device.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouch)
                    && secondaryTouch != lastRightSecondaryTouchState)
            lastRightSecondaryTouchState = secondaryTouch;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxis)
                    && primary2DAxis != lastRightPrimary2DAxisState)
            lastRightPrimary2DAxisState = primary2DAxis;
        if (device.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButton)
                    && primaryButton != lastRightPrimaryButtonState)
            lastRightPrimaryButtonState = primaryButton;
        if (device.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButton)
                    && secondaryButton != lastRightSecondaryButtonState)
            lastRightSecondaryButtonState = secondaryButton;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool primary2DAxisClick)
                    && primary2DAxisClick != lastRightAxisButtonState)
            lastRightAxisButtonState = primary2DAxisClick;*/
    }
}
