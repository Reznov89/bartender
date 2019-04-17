using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

	public Text scoreText,
				bestScore;

	int thisPoints = 0;

	float currentLevel = 0,
	 	  level1 = 0.08f,
	      level2 = 0.09f,
	      level3 = 0.1f,
	      level4 = 0.11f,
	      level5 = 0.12f,
	      level6 = 0.13f;

	public static int goodBeers = 0,
					  badBeers = 0;

	public static int spilled = 0;

	public static float dificulty = 2f, //Decrease for make harder
						patience = 0.1f; //velocidad de vaciamiento de paciencia a > nro mas difici,

	struct level //un struct para nivel
	{
		int number,
			perfect,
			good,
			regular,
			bad,
			dropped,
			points;
		string rank;
	};
	
	level monday;
	level thursday;
	level wednesday;
	level tuesday;
	level friday;
	level saturday;

	void Update()
	{
		
	}

	public void CurrentLevel(int level)
	{

	}

	public float GetCurrentDifficulty()
	{
		return 0.4f;
	}

	public void SetScores()
	{
		
	}

	public void AddPoints(int p)
	{
		thisPoints =+ p;
		scoreText.text = thisPoints.ToString(); 
	}

}
