using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkManager : MonoBehaviour 
{
	public Transform drunkStart;
	public Transform[] drunksPosition = new Transform[5];
	bool[] drunksSlots = new bool[5];
	int index = 0;
	float timer = 0;
	public GameObject drunk; 
	Vector3 slot;
	public bool generating = true;

	void Start()
	{
		//masterBeerGlass 
		Drunk.NewSlotFree += FreelingSlot;
	}

	void StartCreation () 
	{
		index = CheckSlots();
			if (index != -1)
			{
				slot = SelectCurrentSlot(index);
				PlaceDrunk(slot);
			}
			else
				MissADrunk();
			
	}

	void Update()
	{
		if (generating)
		{
			timer += Time.deltaTime;
			if (timer > 5) // cambiar para aumentar la dificultad mayor = mas facil
			{
				timer = 0;
				StartCreation();
			}
		}
	}

	int CheckSlots()
	{ 
		int empty = 0, counter = 0;

		for (int i = 0; i < 5; i++)
		{
			if (drunksSlots[i] == false)
			{
				drunksSlots[i] = true;
				empty = i;
				break;
			}
			else counter++;
		}
		if (counter == 5)
			return -1;
		else 
			return empty;
	}

	Vector3 SelectCurrentSlot(int freeSlot)
	{
		if (freeSlot ==  0)
		{
			return drunksPosition[0].position;
		} 
		else if(freeSlot == 1)
		{
			return drunksPosition[1].position;
		} 
		else if (freeSlot == 2)
		{
			return drunksPosition[2].position;
		}
		else if (freeSlot == 3)
		{
			return drunksPosition[3].position;
		}
		else return drunksPosition[4].position;
	}

	void PlaceDrunk(Vector3 slot)
	{
		Instantiate(drunk, drunkStart.position, Quaternion.identity);
		FindObjectOfType<Drunk>().DrunkSeter(slot, index);
	}

	void MissADrunk()
	{
		print("lost a borracho");
	}

	void FreelingSlot(int slot)
	{
		drunksSlots[slot] = false;
	}
	
	
}
