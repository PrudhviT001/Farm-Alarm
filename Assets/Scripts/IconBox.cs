using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconBox : MonoBehaviour
{

	public Image icon;
	public GameObject iconBox;
	public Animator iconBoxAnim;

	public void SetIcon(Sprite s)
	{
		icon.sprite = s;
		if (s == null)
		{
			iconBoxAnim.SetBool("Enable", false);
		} else
		{
			iconBoxAnim.SetBool("Enable", true);
		}
	}

	public void Close ()
	{
		iconBoxAnim.SetBool("Enable", false);
	}

}
