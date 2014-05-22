using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

	private int furthestCheckpoint = -1;
	private Vector2 pointToReset;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Checkpoint" && other.GetComponent<ID>().identifier > furthestCheckpoint)
		{
			furthestCheckpoint = other.GetComponent<ID>().identifier;
			pointToReset = other.transform.position;
		}
	}

	public void Reset()
	{
		gameObject.GetComponent<Character>().enabled = true;

		transform.position = pointToReset;
	}
}