using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private float movementSpeedAmount = 10f;
	private bool horizontalLock = false;
	private MovingObject mover;

	void Awake()
	{
		mover = GetComponent<MovingObject>();
	}
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.D))
		{
			//mover.AddX(movementSpeedAmount);
			mover.SetX(movementSpeedAmount);
		}
		if (Input.GetKeyUp(KeyCode.D))
		{
			//mover.AddX(-movementSpeedAmount);
			mover.SetX(0);
		}

		if (Input.GetKeyDown(KeyCode.A))
		{
			//mover.AddX(-movementSpeedAmount);
			mover.SetX(-movementSpeedAmount);
		}
		if (Input.GetKeyUp(KeyCode.A))
		{
			//mover.SetX(movementSpeedAmount);
			mover.SetX(0);
		}

		if (Input.GetKeyDown(KeyCode.S))
		{
			
		}

		if (Input.GetKeyDown(KeyCode.W))
		{

		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			mover.addForce(new Vector2(0, 10));

		}
	}
}
