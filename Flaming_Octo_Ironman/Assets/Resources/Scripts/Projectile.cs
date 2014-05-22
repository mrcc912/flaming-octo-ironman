using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

	[SerializeField] private Direction direction = Direction.DOWN;
	[SerializeField] private float xMagnitude;
	[SerializeField] private float yMagnitude;

	private Rigidbody2D rigidBody;


	void Awake()
	{
		Vector2 movementVector = Vector2.zero;
		switch(direction)
		{
		case Direction.UP:
			movementVector = new Vector2(0, yMagnitude);
			break;
		case Direction.DOWN:
			movementVector = new Vector2(0, -yMagnitude);
			break;
		case Direction.RIGHT:
			movementVector = new Vector2(xMagnitude, 0);
			break;
		case Direction.LEFT:
			movementVector = new Vector2(-xMagnitude, 0);
			break;
			
		}
		rigidBody = GetComponent<Rigidbody2D>();
		rigidbody2D.velocity = movementVector;
	}

	void FixedUpdate()
	{

	}

	private enum Direction
	{
		UP, DOWN, LEFT, RIGHT
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Destroy(this.gameObject);
	}
}
