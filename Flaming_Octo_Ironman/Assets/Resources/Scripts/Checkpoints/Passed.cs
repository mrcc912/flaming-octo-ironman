using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]

public class Passed : MonoBehaviour {

	public float speed = 6f;

	void Awake()
	{
		particleSystem.startSpeed = speed;
		particleSystem.startLifetime = 1f;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Character>() != null)
		{
			particleSystem.startSpeed = .5f;
		}
	}
}