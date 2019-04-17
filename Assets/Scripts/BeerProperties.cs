using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerProperties : MonoBehaviour 
{
	[SerializeField] int beerSelected = 0;
	[SerializeField] int glassSelected = 0;
	[SerializeField] int beerLevel = 0;

	#region Setters
	public void SetBeerSelected(int e) {beerSelected = e;}

	public void SetGlassSelected(int e) {glassSelected = e;}

	public void SetBeerLevel(int e) {beerLevel = e;}

	#endregion

	#region Getters
	public int GetBeer() {return beerSelected;}

	public int GetGlassSelected(){return glassSelected;}

	public int GetBeerLevel() {return beerLevel;}

	#endregion

	void Printnumber()
	{
		print("Cerveza: " + GetBeer().ToString());
		print("Nivel: " + GetBeerLevel().ToString());
		print("Vaso: " + GetGlassSelected().ToString());
	}
	
}
