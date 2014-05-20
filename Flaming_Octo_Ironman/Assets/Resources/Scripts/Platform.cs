using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Platform : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D c)
	{
	}

	void OnCollisionExit2D(Collision2D c)
	{
	}
}
