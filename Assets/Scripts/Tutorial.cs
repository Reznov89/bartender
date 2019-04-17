using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour 
{
	public Text tutorial;
	bool firstTime = true;
	float timer = 3f;
	
	void Start () 
	{
		if (firstTime) ShowDumper();
	}

	void Update () 
	{
		
	}

	void ShowDumper()
	{
		tutorial.text = "Bad beers goes here";
		Invoke("DestroyMesssage", 3f);
	}

	void DestroyMesssage()
	{
		tutorial.gameObject.SetActive(false);
	}
}
