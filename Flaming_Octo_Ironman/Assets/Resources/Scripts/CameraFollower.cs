using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {
	
	void Update()
	{
		Camera.main.transform.position = transform.position;
	}
}
