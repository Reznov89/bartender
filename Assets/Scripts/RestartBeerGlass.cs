using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartBeerGlass : MonoBehaviour 
{
	int imageIndex;
	Vector3 initialPos = new Vector3(323, 47, 0);
	public List<Sprite> glassList = new List<Sprite>();
	public Image glass;

	void Start()
	{
		//DefinitiveBeerManager.beerChanged += SetImageIndex;
	}

	public void ResetGlassPosition()
	{
		transform.localPosition = initialPos;
	}

	void SetImageIndex(int number)
	{
		imageIndex = number;
	}

	public void SetImage()
	{
		glass.sprite = glassList[imageIndex] as Sprite;
	}

	public void RestartGlass()
	{
		SetImage();
		ResetGlassPosition();
	}
}
