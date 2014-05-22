using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Death : MonoBehaviour {
	
	private float levelResetDelay = 2f;
	private float flashTimer = 2f;

	public IEnumerator Die()
	{
		SpriteRenderer sr = this.gameObject.GetComponentInChildren<SpriteRenderer>();

		StartCoroutine(FlashyDeath(sr));

		if (this.gameObject.GetComponent<MovingObject>() != null)
		{
			this.gameObject.GetComponent<MovingObject>().ArrestMovement();
		}

		if (this.gameObject.GetComponent<Character>() != null)
		{
			this.gameObject.GetComponent<Character>().enabled = false;

			yield return new WaitForSeconds(levelResetDelay);
			ResetLevel();
		}
	}

	private IEnumerator FlashyDeath(SpriteRenderer sr)
	{
		sr.material.color = Color.red;

		while (flashTimer > 0)
		{
			sr.material.color = (sr.material.color == Color.red) ? Color.white : Color.red;
			flashTimer -= Time.deltaTime;

			yield return null;
		}
	}

	private void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
