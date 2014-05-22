 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {

	private enum Direction { Left, Right };

	private List<Collision2D> collidedObjects;
	private Direction collisionDirection;
	private MovingObject mover;
	private Animator animator;

	private bool isCollidingWithWall;
	private bool canJump;

	private float speed = 10f;

	public float jumpPush = 100f;

	public float teleportDistance = 10f;

	void Awake()
	{
		mover = GetComponent<MovingObject>();
		animator = GetComponentInChildren<Animator>();
		collidedObjects = new List<Collision2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{
			Teleport();
		}
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

	private void Teleport()
	{
		Vector2 direction = ((animator.transform.localRotation.y == 0) ? 1 : -1) *  Vector2.right;
		float destinationX = 0;
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, teleportDistance);
		if(hits.Length > 1)
		{
			for(int i=1; i<hits.Length; i++)
			{

				if(!hits[i].collider.GetComponent<MagicLens>() && Vector2.Distance(hits[i].point, transform.position) <= teleportDistance)
				{
					destinationX = hits[i].point.x - (direction.x * (mover.box.size.x/2));
					break;
				}
			}
		}
		if(destinationX == 0)
			destinationX = transform.position.x + (direction.x * teleportDistance);
		
		transform.position = new Vector3(destinationX, transform.position.y, transform.position.z);
		
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

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Platform>() != null)
		{
			collidedObjects.Add(collision);

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
			collidedObjects.Remove(collision);

			// If not colliding with anything, character must be in the air
			if (collidedObjects.Count == 0)
			{
				mover.isInAir = true;
				isCollidingWithWall = false;
				canJump = false;
			}
		}
	}

}
