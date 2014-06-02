 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour {



	public bool canTeleport = false;

	private List<GameObject> collidedObjects;
	private MovingObject mover;
	private Animator animator;

	private bool canJump;

	private float speed = 10f;

	public float jumpPush = 100f;

	public float teleportDistance = 10f;

	private float teleportDelay = .5f;

	void Awake()
	{
		mover = GetComponent<MovingObject>();
		animator = GetComponentInChildren<Animator>();
		collidedObjects = new List<GameObject>();
	}

	// Update is called once per frame
	void Update ()
	{
		if (canTeleport && teleportDelay > 0)
		{
			teleportDelay -= Time.deltaTime;
		}

		if(canTeleport && Input.GetKeyDown(KeyCode.F))
		{
			Teleport();
			return;
		}

		float horizontal = Input.GetAxisRaw("Horizontal");

		if (Input.GetKeyDown(KeyCode.Space) && canJump)
		{
			animator.SetInteger("State", 3);
			if (horizontal != 0)
			{
				if (horizontal > 0)
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
			mover.isInAir = true;
			canJump = false;
			return;
		}

		if (horizontal != 0)
		{
			mover.Move(new Vector2(horizontal * speed, 0));
			mover.isMoving = true;

			if (mover.isInAir)
			{
				animator.SetInteger("State", 4);
			}
			else
			{
				animator.SetInteger("State", 2);
			}

			if(horizontal > 0)
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
			if (!mover.isInAir)
			{
				animator.SetInteger("State", 1);
			}
		}
	}

	private void Teleport()
	{
		if (teleportDelay <= 0)
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

			teleportDelay = .5f;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Platform>() != null)
		{
			collidedObjects.Add(collision.gameObject);

			animator.SetInteger("State", 1);
			mover.isInAir = false;

			canJump = true;
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<Platform>() != null)
		{
			collidedObjects.Remove(collision.gameObject);

			// If not colliding with anything, character must be in the air
			if (collidedObjects.Count == 0)
			{
				mover.isInAir = true;
				canJump = false;
			}
		}
	}

}
