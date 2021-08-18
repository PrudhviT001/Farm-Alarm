using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
	public TextMeshProUGUI text;

    // Update is called once per frame
    void Update()
    {
		string minutes = Mathf.Floor(GameManager.TimeLeft / 60).ToString("00");
		string seconds = (GameManager.TimeLeft % 60).ToString("00");
		text.text = minutes + ":" + seconds;
    }
}
