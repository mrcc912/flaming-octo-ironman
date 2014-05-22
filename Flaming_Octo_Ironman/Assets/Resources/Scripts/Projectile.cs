using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

	private Launcher.Direction direction = Launcher.Direction.DOWN;
	private float xMagnitude;
	private float yMagnitude;

	public void init(Launcher.Direction dir, float xMag, float yMag)
	{
		direction = dir;
		xMagnitude = xMag;
		yMagnitude = yMag;
	}

	void Start()
	{
		Vector2 movementVector = Vector2.zero;
		switch(direction)
		{
		case Launcher.Direction.UP:
			movementVector = new Vector2(0, yMagnitude);
			break;
		case Launcher.Direction.DOWN:
			movementVector = new Vector2(0, -yMagnitude);
			break;
		case Launcher.Direction.RIGHT:
			movementVector = new Vector2(xMagnitude, 0);
			break;
		case Launcher.Direction.LEFT:
			movementVector = new Vector2(-xMagnitude, 0);
			break;
			
		}
		GetComponent<Rigidbody2D>().velocity = movementVector;
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		Destroy(this.gameObject);
	}
}
