using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMovement : MonoBehaviour 
{
	public Transform startSpot, endSpot, panel;
	public bool chopping = false;
	Animator anim;
	
	void Awake()
	{
		anim = GetComponent<Animator>();
	}

	public void BeginChopp()
	{
		anim.Play("PanelMovingDown");
	}

	public void EndChopp()
	{
		anim.Play("PanelMovingUp");
	}
}
