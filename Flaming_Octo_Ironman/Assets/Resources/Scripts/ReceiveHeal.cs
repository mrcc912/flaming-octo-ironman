using UnityEngine;
using System.Collections;

public class ReceiveHeal : MonoBehaviour {

	public Sprite healedSprite;
	private bool dying = true;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<Heal>() != null && dying)
		{
			gameObject.GetComponent<SpriteRenderer>().sprite = healedSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

			dying = false;
		}
	}
}