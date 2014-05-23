using UnityEngine;
using System.Collections;

public class ReceiveHeal : MonoBehaviour {

	public Sprite sprite;
	private bool dying = true;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<Heal>() != null && dying)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
			dying = false;
		}
	}
}