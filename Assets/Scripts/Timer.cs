using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{
	public Text timerText;
	float timer = 30f;

	
	void Update () 
	{
		timer -= Time.deltaTime;
		timerText.text = Mathf.Round(timer).ToString();

		if (timer <= 0) TimesUp();
	}

	void TimesUp()
	{
		//print("Tiempo");
	}
}
