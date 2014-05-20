using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MovingObject : MonoBehaviour {

	public Vector2 velocity = Vector2.zero;

	public Vector2 acceleration = Vector2.zero;
	
	// Update is called once per frame
	void Update () {
		/*
		Vector2 newPosition = transform.position;
		newPosition += velocity;
		transform.position = newPosition;
		velocity += acceleration;
		*/

	}

	public void SetX(float x)
	{
		Vector2 v = rigidbody2D.velocity;
		v.x = x;
		rigidbody2D.velocity = v;
	}

	public void SetY(float y)
	{
		velocity.y = y;
	}

	public void AddY(float y)
	{
		Vector2 v = rigidbody2D.velocity;
		v.y += y;
		rigidbody2D.velocity = v;
	}

	public void AddX(float x)
	{
		Vector2 v = rigidbody2D.velocity;
		v.x += x;
		rigidbody2D.velocity = v;
	}

	public void arrestMomentum()
	{
		acceleration = Vector2.zero;
		velocity = Vector2.zero;
	}

	public void addForce(Vector2 F)
	{
		rigidbody2D.velocity =  rigidbody2D.velocity + F;
	}

}
