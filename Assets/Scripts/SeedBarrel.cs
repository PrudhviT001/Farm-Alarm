using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBarrel : MonoBehaviour
{
	public Crop crop;

	public IconBox iconBox;

	public void Interact(Crop c, Tool t, PlayerInteraction player)
	{
		if (t == null && !c.HasCrop())
		{
			Debug.Log("Taking " + crop.GetName());
			player.SetCrop(new Crop(crop.asset));
		}
	}

	public void Select()
	{
		iconBox.SetIcon(crop.GetDoneSprite());
	}

	public void DeSelect()
	{
		iconBox.Close();
	}
}
