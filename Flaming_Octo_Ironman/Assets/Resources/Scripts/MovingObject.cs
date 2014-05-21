using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class MovingObject : MonoBehaviour {

	public bool isMoving;
	public bool isInAir;

	private float decelerateFactor = .99f;
	private float maxVelocity = 25f;

	private Vector2 acceleration = Vector2.zero;
	private Vector2 velocity = Vector2.zero;
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs(rigidbody2D.velocity.x) >= .1f)
		{
			if (!isMoving && !isInAir)
			{
				rigidbody2D.AddForce(new Vector2(-rigidbody2D.velocity.x * decelerateFactor, 0));
			}
		}
		else
		{
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
		}
	}

	public void Move(Vector2 vec)
	{
		if (rigidbody2D.velocity.x + vec.x <= maxVelocity)
		{
			rigidbody2D.AddForce(vec);
		}
		else
		{
			rigidbody2D.velocity = new Vector2(maxVelocity, rigidbody2D.velocity.y);
		}
	}

	public void Jump(float push = 0f)
	{
		rigidbody2D.AddForce(new Vector2(push, -Physics2D.gravity.y * 50));
	}

	public void arrestMomentum()
	{
		acceleration = Vector2.zero;
		velocity = Vector2.zero;
	}
}
