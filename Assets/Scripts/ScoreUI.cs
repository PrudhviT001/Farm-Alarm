using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{

	public TextMeshProUGUI text;

	private void Update()
	{
		text.text = GameManager.Score.ToString();
	}

}
