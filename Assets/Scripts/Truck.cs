using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Truck : MonoBehaviour
{
	public float timeBetweenStops = 30f;
	public float stopDuration = 10f;

	public Animator anim;

	public List<Crop> crops;

	public GameObject iconPrefab;
	public Transform grid;

	private void Start()
	{
		StartCoroutine(TruckBehaviour());
	}

	IEnumerator TruckBehaviour ()
	{
		while(true)
		{
			yield return new WaitForSeconds(timeBetweenStops);

			anim.SetTrigger("MakeStop");

			yield return new WaitForSeconds(stopDuration);

			anim.SetTrigger("DriveAway");

			yield return new WaitForSeconds(2f);
			CashIn();
		}
	}

	void CashIn ()
	{
		foreach(Transform child in grid)
		{
			Destroy(child.gameObject);
		}

		crops.Clear();
	}

	public void Interact(Crop c, PlayerInteraction player)
	{
		if (c.state == CropState.Done)
		{
			Debug.Log("Loading " + c.GetName() + " onto truck.");

			crops.Add(c);
			player.SetCrop(new Crop(null));

			bool wasDelivery = Deliveries.instance.CompleteDelivery(c.asset);
			if (wasDelivery)
			{
				Debug.Log("DELIVERERY COMPLETED: " + c.GetName());
				GameManager.IncreaseScore(50);
			} else
			{
				Debug.Log("Delivered: " + c.GetName());
				GameManager.IncreaseScore(20);
			}

			GameObject go = Instantiate(iconPrefab, grid);
			Image img = go.GetComponent<Image>();
			if (img != null)
			{
				img.sprite = c.GetCropSprite();
			}
		}
	}
}
