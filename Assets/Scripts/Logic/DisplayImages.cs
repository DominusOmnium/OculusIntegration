using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;




public class DisplayImages : MonoBehaviour
{
    public enum DisplayType
    {
        Input,
        Output
    }
    [SerializeField] PhotonDisplay[] outputArray  = null;
    [SerializeField] Sprite basisOne  = null;
    [SerializeField] Sprite basisTwo  = null;
    [SerializeField] Sprite polarOneBOne  = null;
    [SerializeField] Sprite polarTwoBOne = null;
    [SerializeField] Sprite polarOneBTwo = null;
    [SerializeField] Sprite polarTwoBTwo = null;
    [SerializeField] Sprite empty = null;
    [SerializeField] Text aliceText = null;
    [SerializeField] Text bobText = null;

    //[SerializeField] PrefabricatedController aliceController;

    [SerializeField] private LightSource lightSource = null;
    [SerializeField] private Detector detector = null;

    private List<PhotonData> _inputData = null;
    [SerializeField] private DisplayType displayType = DisplayType.Input;


    public void UpdateDisplay()
    {
        if (displayType == DisplayType.Input)
        {
            _inputData = lightSource.GetData();
        }
        if (displayType == DisplayType.Output)
        { 
            _inputData = detector.GetData(); 
        }

        for (int i = 0; i < outputArray.Length; i++)
        {
            if (i < _inputData.Count)
            {
                outputArray[i].Enable();
                if (_inputData[i].basis == Basis.First)
                {
                    outputArray[i].SetBasis(basisOne);
                    if (_inputData[i].polarization == PhotonPolar.True)
                    {
                        outputArray[i].SetBit(polarOneBOne);
                    }
                    else
                    {
                        outputArray[i].SetBit(polarTwoBOne);
                    }
                }
                else
                {
                    outputArray[i].SetBasis(basisTwo);
                    if (_inputData[i].polarization == PhotonPolar.True)
                    {
                        outputArray[i].SetBit(polarOneBTwo);
                    }
                    else
                    {
                        outputArray[i].SetBit(polarTwoBTwo);
                    }
                }
            }
            else
            {
                outputArray[i].Clear();
            }
        }
    }

    public void onAliceStateChanged(PrefabricatedState oldState, PrefabricatedState newState, int wrongParts)
    {
        if (newState == PrefabricatedState.Correct)
        {
            aliceText.text = "Alice: correct!";
            aliceText.color = Color.green;
        }
        else
        {
            aliceText.text = "Alice: " + wrongParts + " wrong parts!";
            aliceText.color = Color.red;
        }
    }

    public void onBobStateChanged(PrefabricatedState oldState, PrefabricatedState newState, int wrongParts)
    {
        if (newState == PrefabricatedState.Correct)
        {
            bobText.text = "Bob: correct!";
            bobText.color = Color.green;
        }
        else
        {
            bobText.text = "Bob: " + wrongParts + " wrong parts!";
            bobText.color = Color.red;
        }
    }

    public void ClearDisplay()
    {
         lightSource.ResetPhotons();
         detector.ClearDecodedMessage();
    }
}
