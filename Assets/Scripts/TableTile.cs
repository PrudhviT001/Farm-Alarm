using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTile : MonoBehaviour
{
	public SpriteRenderer overlay;

	public Crop crop;
	public Tool tool;

	private void Start()
	{
		if (crop.HasCrop())
			overlay.sprite = crop.GetCropSprite();
		else if (tool != null)
			overlay.sprite = tool.sprite;
	}

	public void Interact(Crop c, Tool t, PlayerInteraction player)
	{
		player.SetCrop(crop);
		crop = c;
		player.SetTool(tool);
		tool = t;

		if (tool != null)
			overlay.sprite = tool.sprite;
		else if (crop != null)
			overlay.sprite = crop.GetCropSprite();
		else
			overlay.sprite = null;
	}

}
