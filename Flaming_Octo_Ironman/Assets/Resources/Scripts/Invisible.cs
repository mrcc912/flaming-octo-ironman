using UnityEngine;
using System.Collections;

public class Invisible : MonoBehaviour {

	private SpriteRenderer r;

	void Awake()
	{
		r = GetComponentInChildren<SpriteRenderer>();

		Color c = r.color;
		c.a = 0;
		r.color = c;
	}

	public void SetVisible(bool visible)
	{
		Color c = r.color;
		c.a = visible ? 1.0f : 0f;
		r.color = c;
		Debug.Log ("Color is now" + r.color.a);
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		Debug.Log("trigger enter!");
		if(c.GetComponent<MagicLens>())
			SetVisible(true);
	}

	void OnTriggerExit2D(Collider2D c)
	{
		Debug.Log("trigger exit!");
		if(c.GetComponent<MagicLens>())
			SetVisible(false);
	}
}
