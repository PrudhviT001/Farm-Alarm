using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static int Score = 0;
	public static float TimeLeft = 312f;

	public GameObject endGameUI;

	public static bool GameHasEnded;

	private void Awake()
	{
		Score = 0;
		GameHasEnded = false;
	}

	public static void IncreaseScore (int amount)
	{
		if (GameHasEnded)
			return;

		Score += amount;
	}

	private void Update()
	{
		TimeLeft -= Time.deltaTime;
		if (TimeLeft <= 0f)
		{
			TimeLeft = 0f;
			if (!GameHasEnded)
			{
				EndGame();
			}
		}
	}

	void EndGame()
	{
		GameHasEnded = true;
		endGameUI.SetActive(true);
	}

}
