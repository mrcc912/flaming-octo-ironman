using UnityEngine;
using System.Collections;

public class ReceiveHeal : MonoBehaviour {

	public Sprite healedSprite;

	private bool dying = true;
	private LevelController controller;

	void Start()
	{
		controller = GameObject.Find("LevelManager").GetComponent<LevelController>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.GetComponent<Heal>() != null && dying)
		{
			gameObject.GetComponentInChildren<SpriteRenderer>().sprite = healedSprite;
			gameObject.GetComponent<BoxCollider2D>().enabled = false;

			controller.unitsHealed++;

			dying = false;
		}
	}
}