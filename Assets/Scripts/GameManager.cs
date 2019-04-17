using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	int level = 0; 
		//score = 0;
	
	void Start()
	{
		Barman.gomeOverHandler += GameOverScreen;
	}

	void CheckLevel()
	{
		if (level > 1 && level <= 4)
		{
			Settings.dificulty = 2f;
		}
		else if (level >= 5 && level <= 8)
		{
			Settings.dificulty = 1.5f;
		}
		else if (level >= 9 && level <= 12)
		{
			Settings.dificulty = 1f;
		}
		else if (level >= 13 && level <= 15)
		{
			Settings.dificulty = 0.5f;
		}
		else
		{
			Settings.dificulty = 0.2f;
		}
	}

	public void GameOverScreen()
	{
		print("GAME OVER MAN");
	}
}
