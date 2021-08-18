using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deliveries : MonoBehaviour
{

	public static Deliveries instance;

	private void Awake()
	{
		instance = this;
	}

	public int deliveryCount = 6;

	public CropAsset[] availableCrops;

	public GameObject iconPrefab;
	public Transform grid;
	
	public List<CropAsset> deliveries;
	public List<GameObject> deliveryObjects;

	private void Start()
	{
		for (int i = 0; i < deliveryCount; i++)
		{
			AddDelivery();
		}
	}

	void AddDelivery()
	{
		int rndmNumber = Random.Range(0, availableCrops.Length);
		CropAsset d = availableCrops[rndmNumber];
		deliveries.Add(d);

		GameObject go = Instantiate(iconPrefab, grid);
		deliveryObjects.Add(go);

		Image img = go.GetComponent<Image>();
		img.sprite = d.doneSprite;

		for (int i = 0; i < deliveryObjects.Count; i++)
		{
			Image dImg = deliveryObjects[i].GetComponent<Image>();

			if (i == 0)
			{
				dImg.color = Color.white;
			} else
			{
				dImg.color = new Color(1f, 1f, 1f, .5f);
			}
		}
	}

	public bool CompleteDelivery(CropAsset d)
	{
		if (d == deliveries[0])
		{
			deliveries.RemoveAt(0);
			Destroy(deliveryObjects[0]);
			deliveryObjects.RemoveAt(0);
			AddDelivery();
			return true;
		} else
		{
			return false;
		}
	}

}
