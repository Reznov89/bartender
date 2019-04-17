using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassFill : MonoBehaviour 
{
	/* public Settings lists;
	
	public static int selectedBeer,
					  selectedGlass;
	public Button one, 
				  two,
				  three,
				  four;

	public Animator glassFilling,
					barman;
	

	float counter = 0f, //beer level
		  timer = 30f;
	bool stillFilling = false,
		 begunFilling = false,
		 justOnce = false;
	
	Transform target;
	public Transform barmanTransform,
					 beerTap1,
					 beerTap2,
		  			 beerTap3;

	[Header("Scripts")]
	public DragHandler dragHandler;
	public BeerProperties beerProperties;
	public DefinitiveBeerManager definitiveBeerManager;
*/
	/* void Update () 
	{
		if (begunFilling)
		{
			timer -= 0.1f;
			dragHandler.SetDrag();
			barmanTransform.position = Vector3.MoveTowards(barmanTransform.position, target.position, 13f * Time.deltaTime * 2);
			if (barmanTransform.position == target.position) StartAnimations();
		}

		if (timer < 0)
		{
			stillFilling = false;
			begunFilling = false;
			//print("Fin del juego");
			barman.Play("BartenderIdle");
		}
		else 
			stillFilling = true;
	}

	public void StartTapping()
	{
		if (!justOnce)
		{
			begunFilling = true;
			justOnce = true;
	
		
			//Send values to the beer's properties
			beerProperties.SetGlassSelected(selectedGlass);
			beerProperties.SetBeerSelected(selectedBeer);
			definitiveBeerManager.ChangeFillingState();
			
			// Move the barman
			switch (selectedBeer) 
			{
				case 0:
					//StartAnimations(beerTap1);
					target = beerTap1;
					break;
				case 1:
					//StartAnimations(beerTap2);
					target = beerTap2;
					break;
				case 2:
					//StartAnimations(beerTap3);
					target = beerTap3;
					break;
			}
		}
		
		if (stillFilling) counter += 0.05f;
		glassFilling.SetFloat("Filling", counter);

		beerProperties.SetBeerLevel(counter);

		//check for spilled beer
		if (counter > 1.1f)
		{
			Spilled();
		}
	}

	void Remake()
	{
		begunFilling = true;
		stillFilling = true;
		justOnce = false;
		counter = 0f;
		timer = 30f;
		//EnableButtoms();
	}

	/* void DisableButtoms()
	{
		one.interactable = false;
		two.interactable = false;
		three.interactable = false;
		four.interactable = false;
	}

	void EnableButtoms()
	{
		one.interactable = true;
		two.interactable = true;
		three.interactable = true;
		four.interactable = true;
	}

	void Spilled () //spilled beer
	{
		print("Spilled!!!");
	}

	void StartAnimations()
	{
		barman.Play("BartenderServing");
	}*/

}
