﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]

public class Passed : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.GetComponent<Character>() != null)
		{
			particleSystem.startSpeed = 1;
		}
	}
}