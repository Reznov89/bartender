using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerator : MonoBehaviour 
{
	[System.Serializable]
	public struct orderGenerator
	{
		public Sprite[] chopBlack,
						chopBlonde,
						chopRed,
						portoBlack,
						portoBlonde,
						portoRed;
	};
	
	public orderGenerator masterOrderGenerator;

	public void OrderABeer(int glass, int beer, int amount)
	{

	}
}
