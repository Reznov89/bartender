//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barman : MonoBehaviour 
{
	public delegate void GomeOverHandler();
	public static event GomeOverHandler gomeOverHandler;


	public Slider drunkenLevel;
	bool drinking = false;
	//public PanelMovement panelMovement;
	//Animator anim;
	//bool isMoving = false;
	//int target = 1;
	//float step = 0;
	/* public Transform beerDark,
					 beerRed,
					 beerBlonde;
					 */
	void Awake () 
	{
	
	}

	void MoveToBeer(int b)
	{
		//target = b;
		//isMoving = true;
	}
	
	void Update () 
	{

		if (drinking)
		{
			float current = drunkenLevel.value;
			while (current > drunkenLevel.value-1)
			{
				drunkenLevel.value =- Time.deltaTime;
				if (current == 0) BarmanIsDrunk();
			}
			drinking = false;
		}
		/* if (isMoving)
		{
			switch (target)
			{
				case 1:
					transform.position = Vector3.Lerp(this.transform.position, beerDark.position, step);
				break;
			}
		}*/
	}

	public void Drink()
	{
		drinking = true;
	}

	public static void BarmanIsDrunk()
	{
		if (gomeOverHandler != null) gomeOverHandler();
	}
}
