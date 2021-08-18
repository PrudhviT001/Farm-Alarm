using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Crop
{
	public CropAsset asset;

	public CropState state;

	private float growthLevel;
	private float waterLevel;
	private bool isDead;

	public bool Grow(float amount)
	{
		if (GetWaterState() == WaterState.Watered)
		{
			growthLevel += amount / 20f;
		}

		if (growthLevel >= 1f)
		{
			state = CropState.Done;
			return true;
		}

		return false;
	}

	public WaterState Dry(float amount)
	{
		waterLevel -= amount / 8f;
		return GetWaterState();
	}

	public WaterState GetWaterState ()
	{
		if (waterLevel > 0f)
		{
			return WaterState.Watered;
		}
		else if (waterLevel > -1f)
		{
			return WaterState.Dry;
		}
		else
		{
			state = CropState.Dead;
			return WaterState.Dead;
		}
	}

	public void Water ()
	{
		waterLevel = 1f;
	}

	public Crop (CropAsset a) {
		asset = a;
		state = CropState.Seed;
		growthLevel = 0f;
		waterLevel = 1f;
		isDead = false;
	}

	public bool HasCrop()
	{
		if (asset == null)
			return false;
		else
			return true;
	}

	public Sprite GetCropSprite()
	{
		if (asset == null)
			return null;

		switch (state)
		{
			case CropState.Seed:
				return asset.seedSprite;
			case CropState.Planted:
				return asset.seedSprite;
			case CropState.Dead:
				return asset.deadSprite;
			case CropState.Done:
				return asset.doneSprite;
		}

		Debug.LogError("WHAT?!");
		return asset.seedSprite;
	}

	public bool IsOnGround()
	{
		if (state == CropState.Planted && asset.seedIsOnGround)
			return true;
		else
			return false;
	}

	public Sprite GetDoneSprite()
	{
		return asset.doneSprite;
	}

	public string GetName()
	{
		if (asset == null)
			return null;

		return asset.name;
	}
}

public enum CropState
{
	Seed,
	Planted,
	Dead,
	Done
}

public enum WaterState
{
	Watered,
	Dry,
	Dead
}
