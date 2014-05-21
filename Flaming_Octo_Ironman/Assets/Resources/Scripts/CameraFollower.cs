using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public Camera cam;

	void Update()
	{
		cam.transform.position = transform.position;
	}
}
