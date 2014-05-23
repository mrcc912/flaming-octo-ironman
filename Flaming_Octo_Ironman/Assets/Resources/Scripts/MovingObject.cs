using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class MovingObject : MonoBehaviour {

	public bool isMoving;
	public bool isInAir;

	private float maxVelocityX = 10f;

	public BoxCollider2D box;


	void Awake()
	{
		box = GetComponent<BoxCollider2D>();
	}
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs(rigidbody2D.velocity.x) > 0)
		{
			if (!isMoving && !isInAir)
			{
				//rigidbody2D.AddForce(new Vector2(-rigidbody2D.velocity.x * decelerateFactor, 0));
				rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			}
		}
		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}
	}

	public void Move(Vector2 vec)
	{
		/*
		if (rigidbody2D.velocity.x + vec.x <= maxVelocityX)
		{
			rigidbody2D.AddForce(vec * 5);
		}
		else
		{
			rigidbody2D.velocity = new Vector2(maxVelocityX, rigidbody2D.velocity.y);
		}
		*/
		float newXVelocity = ((vec.x >0) ? 1 : -1 )* Mathf.Max(maxVelocityX, Mathf.Abs(rigidbody2D.velocity.x));
		if(Mathf.Abs(newXVelocity) <= maxVelocityX)
		{
			rigidbody2D.AddForce(vec);
		}
		rigidbody2D.velocity = new Vector2(newXVelocity, rigidbody2D.velocity.y);
	}

	public void Jump(float push = 0f)
	{
		rigidbody2D.AddForce(new Vector2(push, -Physics2D.gravity.y * 50));
	}

	public void ArrestMovement()
	{
		rigidbody2D.velocity = Vector2.zero;
	}
}
