﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]

public class TargetedProjectile : MonoBehaviour {

	public float Force;

	public void Launch(Vector2 direction)
	{
		rigidbody2D.transform.position += (Vector3)direction * .1f;
		rigidbody2D.AddForce(gameObject.transform.up * Force);
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.GetComponent<Character>() == null)
		{
			Destroy(gameObject);
		}
	}
}
