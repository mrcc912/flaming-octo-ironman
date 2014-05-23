using UnityEngine;
using System.Collections;

public class MouseFollower : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = pos;
	}
}
