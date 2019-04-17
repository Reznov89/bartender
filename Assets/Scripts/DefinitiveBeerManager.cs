using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DefinitiveBeerManager : MonoBehaviour
{
	[Header("Listados")]
	public List<Sprite> beerList = new List<Sprite>();
	public List<Sprite> glassList = new List<Sprite>();

	[Header("Indices")]
	public int indexBeer = 0, //0 - black  1 - blonde  2 - red
			   indexGlass = 0;

	[Header("Other scripts references")]
	public BeerProperties beerProperties;
	public DragHandler dragHandler;

	public Button UIbeer,
				  one, 
				  two,
				  three,
				  four;

	[Header("UI References")]
	public GameObject spilledTxt;

	[Space]

	public Image beerSelected,
				 glassSelected;

	public Animator glassFilling,
					barman;
	
	Transform target;
	public Transform barmanTransform,
					 beerTap1,
					 beerTap2,
		  			 beerTap3;
	
	bool stillFilling = false,
		 begunFilling = false,
		 justOnce = false,
		 uiMessage = false,
		 pause = false;

	float counter = 0f, //beer level
		  timer = 10f, //set serving timer
		  uiTimer = 2f;

	[Space]

	[Header("SOUNDS")]
	public AudioSource audioSource;
	public AudioClip beerPunding,
					 beerSpilling;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Start()
	{
		glassFilling.Play("GlassEmptyForBlonde");
		UIbeer.image.sprite = beerList[indexBeer];
	}

	void Update()
	{
		if (begunFilling && !pause)
		{
			glassFilling.SetBool("Serving", true);
			glassFilling.SetInteger("BeerSelection", indexBeer);
			timer -= 0.1f;
			dragHandler.DraggingOn();
			barmanTransform.position = Vector3.MoveTowards(barmanTransform.position, target.position, 13f * Time.deltaTime * 2);
			if (barmanTransform.position == target.position) StartAnimations();
		}

		if (uiMessage)
		{
			uiTimer-=Time.deltaTime;
			if (uiTimer < 0)
			{
				uiMessage = false;
				uiTimer = 2f;
				spilledTxt.SetActive(false);
				pause = false;
			}
		}

		if (timer < 0)
		{
			stillFilling = false;
			begunFilling = false;
			DoneServing();
		}
		else 
			stillFilling = true;
	}

	public void StartTapping()
	{
		if (!justOnce && !pause)
		{
			begunFilling = true;
			justOnce = true;
			dragHandler.DraggingOn();
			//Sounds
			audioSource.clip = beerPunding;
			audioSource.Play();
			// Move the barman
			switch (indexBeer) 
			{
				case 0:
					target = beerTap1; //black
					break;
				case 1:
					target = beerTap2; //blonde
					break;
				case 2:
					target = beerTap3; //red
					break;
			}
		}
		
		if (stillFilling) 
		{
			counter += 0.1f;
			audioSource.volume = counter * 3;
		}
		
		glassFilling.SetFloat("Filling", counter);
		

		//check for spilled beer
		if (counter > 1.1f)
		{
			Spilled();
		}
	}

	void DoneServing()
	{
		//print("finish");
		audioSource.Stop();
		barman.Play("BartenderIdle");
		//Set the beer properties
		beerProperties.SetBeerLevel(ConvertBeerLevel(counter));
		beerProperties.SetBeerSelected(indexBeer);
		beerProperties.SetGlassSelected(indexGlass);
		pause = true;
	}

	int ConvertBeerLevel(float beerLevel)
	{
		if (beerLevel > 0.1f && beerLevel < 0.3f) return 1;
		else if (beerLevel > 0.3f && beerLevel < 0.5f) return 2;
		else if (beerLevel > 0.5f && beerLevel < 0.6f) return 3;
		else if (beerLevel > 0.6f && beerLevel < 0.8f) return 4;
		else if (beerLevel > 0.8f && beerLevel < 0.9f) return 5;
		else return 6;
	}

	#region Arrow buttoms

	// --------------------------------------- CERVEZAS

	public void BeerRight()
	{
		if (indexBeer < beerList.Count - 1) indexBeer++; else indexBeer = 0;
		ChangeBeerImages(indexBeer);
	}

	public void BeerLeft()
	{
		if (indexBeer > 0) indexBeer--; else indexBeer = 2;
		ChangeBeerImages(indexBeer);
	}

	// --------------------------------------- VASOS

	public void GlassRight()
	{
		if (indexGlass < glassList.Count - 1) indexGlass++; else indexGlass = 0;
		ChangeGlassImages(indexGlass);
	}

	public void GlassLeft()
	{
		if (indexGlass > 0) indexGlass--; else indexGlass = 1;
		ChangeGlassImages(indexGlass);
	}

	#endregion

	void ChangeBeerImages(int beer)
	{
		UIbeer.image.sprite = beerList[indexBeer];
		beerSelected.sprite = beerList[indexBeer];
	}

	public void ChangeGlassImages(int glass)
	{
		glassSelected.sprite = glassList[glass];
		
		switch (glass)
		{
		case 0:
			glassFilling.Play("GlassEmptyForBlonde");
			return;
		case 1:
			glassFilling.Play("PortoEmpty");
			return;
		}
	}

	void DisableButtoms()
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

	void StartAnimations()
	{
		barman.Play("BartenderServing");
	}

	public void Remake()
	{
		stillFilling = false;
		begunFilling = false;
		justOnce = false;
		timer = 10f;
		counter = 0;
		glassFilling.Play("GlassEmptyForBlonde");
		glassFilling.SetBool("Serving", false);
		glassFilling.SetFloat("Filling", 0f);
		glassFilling.SetInteger("BeerSelection", 10);
		barman.Play("BartenderIdle");
		pause = false;
		EnableButtoms();
		//spilledTxt.SetActive(false);
	}

	public void Spilled()
	{
		audioSource.Stop();
		audioSource.clip = beerSpilling;
		audioSource.Play();
		Settings.spilled++;
		spilledTxt.SetActive(true);
		spilledTxt.gameObject.transform.position = barmanTransform.position;
//		print("Spilled");
		uiMessage = true;
		pause = true;
		// ------------- UI message
		Invoke("Remake", 3f);
	}

}
