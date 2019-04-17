using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApearAndDesapear : MonoBehaviour 
{
	private Animator floatAndVanish;
	float timer = 2f;
	bool animationActivated = false;

	void Awake () 
	{
		floatAndVanish = GetComponent<Animator>();
	}

	void Update ()
	{
		if (animationActivated)
		{
			timer -= Time.deltaTime;
			if (timer < 0)
			{
				 ResetAnimation();
				 timer = 2f;
				 animationActivated = false;
			}
		}
	}

	void OnEnable()
	{
		floatAndVanish.Play("Spilled");
		animationActivated = true;
	}

	void ResetAnimation () 
	{
		floatAndVanish.Play("SpilledIdle");
	}
}
