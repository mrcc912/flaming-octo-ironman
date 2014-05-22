using UnityEngine;
using System.Collections;

public class MouseFollower : MonoBehaviour {

	private float movementScaler = 5;
	// Update is called once per frame
	void Update () {
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = pos;
	}
}
