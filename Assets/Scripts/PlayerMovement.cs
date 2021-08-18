using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 2f;

	public Sprite rightSprite;
	public Sprite leftSprite;
	public Sprite upSprite;
	public Sprite downSprite;

	public BoxCollider2D rightCol;
	public BoxCollider2D leftCol;
	public BoxCollider2D upCol;
	public BoxCollider2D downCol;

	public SpriteRenderer sr;

	public string horizontalAxis;
	public string verticalAxis;

	private Vector2 movement = Vector2.zero;
	private Rigidbody2D rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
    {
		movement.x = Input.GetAxisRaw(horizontalAxis);
		movement.y = Input.GetAxisRaw(verticalAxis);
    }

	private void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

		if (movement.y > 0.1f)
		{
			sr.sprite = upSprite;
			upCol.enabled = true;
			downCol.enabled = false;
			rightCol.enabled = false;
			leftCol.enabled = false;
		}
		else if (movement.y < -0.1f)
		{
			sr.sprite = downSprite;
			upCol.enabled = false;
			downCol.enabled = true;
			rightCol.enabled = false;
			leftCol.enabled = false;
		}

		if (movement.x > 0.1f)
		{
			sr.sprite = rightSprite;
			upCol.enabled = false;
			downCol.enabled = false;
			rightCol.enabled = true;
			leftCol.enabled = false;
		} else if (movement.x < -0.1f)
		{
			sr.sprite = leftSprite;
			upCol.enabled = false;
			downCol.enabled = false;
			rightCol.enabled = false;
			leftCol.enabled = true;
		}

	}
}
