using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonDisplay : MonoBehaviour
{
	[SerializeField] private Image basis  = null;
	[SerializeField] private Image bit  = null;

	public void Clear()
	{
		basis.GetComponent<Image>().enabled = false; 
		bit.GetComponent<Image>().enabled = false;
	}
	public void Enable()
	{
		basis.GetComponent<Image>().enabled = true; 
		bit.GetComponent<Image>().enabled = true;
	}
	public void SetBasis(Sprite newSprite)
	{
		basis.sprite = newSprite;
	}
	
	public void SetBit(Sprite newSprite)
	{
		bit.sprite = newSprite;
	}
}
