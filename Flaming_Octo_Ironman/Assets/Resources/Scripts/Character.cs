﻿ using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

	private enum Direction { Left, Right };

	private Direction collisionDirection;
	private MovingObject mover;
	private Animator animator;

	private bool isCollidingWithWall;
	private bool canJump;

	private float speed = 10f;

	public float jumpPush = 100f;

	void Awake()
	{
		mover = GetComponent<MovingObject>();
		animator = GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update ()
	{
		float horizontal = Input.GetAxisRaw("Horizontal");

		if (horizontal != 0)
		{
			mover.Move(new Vector2(horizontal * speed, 0));
			mover.isMoving = true;
			animator.SetInteger("State", 2);
			if(horizontal >0 )
			{
				Helper.SetYRotation(animator.transform, 0);
			}
			else
			{
				Helper.SetYRotation(animator.transform, 180);
			}
		}
		else
		{
			mover.isMoving = false;
			animator.SetInteger("State", 1);
		}

		if (Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			animator.SetInteger("State", 3);
			if (isCollidingWithWall)
			{
				if (collisionDirection == Direction.Left)
				{
					mover.Jump(jumpPush);
				}
				else
				{
					mover.Jump(-jumpPush);
				}
			}
			else
			{
				mover.Jump();
			}
			canJump = false;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Platform>() != null)
		{
			animator.SetInteger("State", 1);
			mover.isInAir = false;

			isCollidingWithWall = true;
			canJump = true;

			collisionDirection = DetermineCollisionDirection(collision);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Platform>() != null)
		{
			mover.isInAir = true;
			isCollidingWithWall = false;
			canJump = false;
		}
	}

	private Direction DetermineCollisionDirection(Collision2D collision)
	{
		Vector2 hitDirection = collision.contacts[1].point - (Vector2)transform.position;
		Vector2 left = transform.TransformDirection(Vector3.left);

		if (Vector2.Dot(left, hitDirection) > 0)
		{
			return Direction.Left;
		}
		else
		{
			return Direction.Right;
		}
	}
}
