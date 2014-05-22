using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]

public class Damage : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		GameObject collidedObject = collision.collider.transform.gameObject;

		if (collidedObject.GetComponent<Character>() != null)
		{
			StartCoroutine(collidedObject.GetComponent<Death>().Die());
		}
	}
}