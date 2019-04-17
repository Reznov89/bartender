using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drunk : MonoBehaviour 
{
	public delegate void BeerSelectedHandler(int b);
	public static event BeerSelectedHandler BeerSelected; 

	public delegate void LeavingBar(int slot);
	public static event LeavingBar NewSlotFree;

	public GameObject dialog,
					  patienceTimer;
	public Slider patience;
	public Text beerText;
	public Image fill;
	public Sprite thumbDown,
				  thumbUp;
	Sprite orderSprite;
	Sprite[] beers;

	[SerializeField]
	SpriteRenderer beerImage;
	SpriteRenderer thisDrunk;
	
	int selectedBeer = 0,
		usingSlot,
		glass = 0,
		beer = 0,
		filling = 0;

	bool leaving = false, 
		 reachTable = false,
	  	 flag = true,
		 order = false;

	Vector3 tablePosition;
	
	public float speed; 
	float patienceValue,
		  destroyTime = 3f;

	string orderName;

	public Settings settings;

	void Awake()
	{
		settings = GetComponent<Settings>();
	}

	public void DrunkSeter(Vector3 goal, int slot)
	{
		tablePosition = goal;
		usingSlot = slot;
	}

	void Update()
	{
		if (!reachTable)
		{	
			float step = speed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, tablePosition, step);

			if (transform.position == tablePosition) 
			{
				if (!order) AskForBeer();
				reachTable = true;
				step = 0;
			}
		}
		else
		{
			patience.value -= Time.smoothDeltaTime * Settings.patience;
			fill.color = Color.Lerp(Color.red, Color.green, patience.value*1.1f);

			if (patience.value == 0 && flag)
			{
				UnSatisfied();
				flag = false;
			}

			if (leaving)
			{
				transform.Translate(Vector3.right / 4);
				destroyTime -= Time.deltaTime;
				if (destroyTime < 0) Destroy(this.gameObject);
			}
		}
	}

	void AskForBeer () 
	{
		order = true;
		selectedBeer = Random.Range(0,3);
		SelectBeer(selectedBeer);

		dialog.SetActive(true);

		//Generate order
		glass = Random.Range(0,2);
		beer = Random.Range(0,3);
		//int glass = 0, beer = 0;
		
		filling = Random.Range(2,5);
		
		orderName = glass.ToString() + beer.ToString() + filling.ToString();
		//print(orderName);

		if (glass == 0 && beer == 0) 
		{
			beers = Resources.LoadAll<Sprite>("Chop negra");
		}
		else if (glass == 0 && beer == 1)
		{
			beers = Resources.LoadAll<Sprite>("Chop roja");
		}
		else if (glass == 0 && beer == 2)
		{
			beers = Resources.LoadAll<Sprite>("Chop rubia");
		}
		else
		{
			beers = Resources.LoadAll<Sprite>("Porto");
		}
		
		beerImage.sprite = beers[GetIDByName(orderName)];

		patienceTimer.SetActive(true);
	}

	 int GetIDByName(string oName)
	{
		int index = 0;
		for (int i = 0; i < beers.Length; i++)
		{
			if (beers[i].name == oName) 
			index = i; 
		}
		return index;
	}

	void Satisfied()
	{
		beerImage.sprite = thumbUp;
		Settings.goodBeers++;
		LeaveBar();
	}

	void UnSatisfied()
	{
		beerImage.sprite = thumbDown;
		Settings.badBeers++;
		LeaveBar();
	}

	void LeaveBar()
	{
		patienceTimer.SetActive(false);
		LeavingSlot(usingSlot); //Avisa el slot que deja vacio
		leaving = true;
		//thisDrunk.flipX = true;
		GetComponent<SpriteRenderer>().flipX = true;
	}

	public void ReceiveBeer(int g, int b, int l)
	{
		//print("Tegno chaleco viteh");
		patienceTimer.SetActive(false);

		if (g != glass || b != beer) UnSatisfied();
		else if (filling == l) PerfectBeer();
		else if (filling < l) GoodBeer();
		else if (filling > l) RegularBeer();
		
		}

	void PerfectBeer()
	{
		beerText.gameObject.SetActive(true);
		beerText.text = "Perfect!";
		beerText.color = Color.green;
		beerText.gameObject.transform.position = this.transform.position;
		settings.AddPoints(3);
	}

	void GoodBeer()
	{
		beerText.gameObject.SetActive(true);
		beerText.text = "Good one!";
		beerText.color = Color.yellow;
		beerText.gameObject.transform.position = this.transform.position;
		settings.AddPoints(3);
	}

	void RegularBeer()
	{
		beerText.gameObject.SetActive(true);
		beerText.text = "Not bad...";
		beerText.color = Color.red;
		beerText.gameObject.transform.position = this.transform.position;
		settings.AddPoints(2);
	}

	void RandomMessages()
	{
		//settings.AddPoints(1);
	}

	//Send messages
	public static void SelectBeer (int beers) 
	{
		if (BeerSelected != null) BeerSelected(beers);
	}

	public static void LeavingSlot(int freeSlot)
	{
		if (NewSlotFree != null) NewSlotFree(freeSlot);
	}

}