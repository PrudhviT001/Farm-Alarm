using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
	public void Interact(Crop c, Tool t, PlayerInteraction player)
	{
		if (t == null && c.HasCrop())
		{
			player.SetCrop(new Crop(null));
		}
	}
}
