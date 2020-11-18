using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorLed : MonoBehaviour
{
	[SerializeField]
	public DisplayImages outPutDisplay;
	public delegate void ClickAction();
	public static event ClickAction OnClicked;
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Photon"))
		{
			// blink led
			if (OnClicked != null)
				OnClicked();
			Destroy(other.gameObject);
			outPutDisplay.UpdateDisplay();
		}
	}
}
