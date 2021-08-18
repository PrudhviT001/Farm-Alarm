using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtTile : MonoBehaviour
{
	public Crop crop;

	public SpriteRenderer overlay;

	public bool needsPlowing = true;
	public Sprite extraDirt;
	public GameObject waterIndicator;

	public string onGroundLayer;
	public string normalCropLayer;

	public bool hasCrow = false;

	private void Start()
	{
		if (needsPlowing)
		{
			AddDirt();
		}
	}

	public void Interact (Crop c, Tool t, PlayerInteraction player)
	{
		if (c.HasCrop())
		{
			if (!needsPlowing)
				PlantSeed(c, player);
			else
				Debug.Log("Ground needs plowing!");

			return;
		}

		if (t != null)
		{
			if (t.toolType == ToolType.Plow && needsPlowing)
			{
				Plow();
			} else if (t.toolType == ToolType.Watercan && crop.state == CropState.Planted)
			{
				WaterCrop();
			}

			return;
		}

		if (crop.HasCrop())
		{
			HarvestCrop(player);
		}
	}

	void PlantSeed (Crop c, PlayerInteraction player)
	{
		if (c.state != CropState.Seed)
		{
			Debug.Log("Crop not seed, can't plan't.");
			return;
		}
		Debug.Log("Planting " + c.GetName());
		crop = c;
		crop.state = CropState.Planted;

		UpdateSprite();

		player.SetCrop(new Crop(null));
	}

	void HarvestCrop (PlayerInteraction player)
	{
		if (crop.state == CropState.Done || crop.state == CropState.Dead)
		{
			player.SetCrop(crop);
			crop = new Crop(null);
			needsPlowing = true;
			AddDirt();
		}
	}

	public void BirdEatsCrop()
	{
		crop = new Crop(null);
		needsPlowing = true;
		AddDirt();
	}

	void AddDirt()
	{
		overlay.sprite = extraDirt;
		overlay.sortingLayerName = onGroundLayer;
	}

	void Plow ()
	{
		Debug.Log("Plowing...");
		overlay.sprite = null;
		needsPlowing = false;
	}

	void WaterCrop ()
	{
		if (crop.GetWaterState() == WaterState.Dry)
		{
			crop.Water();
			UpdateSprite();
			waterIndicator.SetActive(false);
		}
	}

	void UpdateSprite ()
	{
		overlay.sprite = crop.GetCropSprite();
		if (crop.IsOnGround())
		{
			overlay.sortingLayerName = onGroundLayer;
		} else
		{
			overlay.sortingLayerName = normalCropLayer;
		}
	}

	private void Update()
	{
		if (crop.HasCrop())
		{
			if (crop.state == CropState.Planted)
			{
				bool isDone = crop.Grow(Time.deltaTime);
				if (isDone)
				{
					UpdateSprite();
				} else
				{
					WaterState state = crop.Dry(Time.deltaTime);
					if (state == WaterState.Dry)
					{
						waterIndicator.SetActive(true);
					} else if (state == WaterState.Dead)
					{
						UpdateSprite();
						waterIndicator.SetActive(false);
					}
				}
			}
		}
	}

}
