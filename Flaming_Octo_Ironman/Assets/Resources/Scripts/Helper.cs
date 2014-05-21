using UnityEngine;
using System.Collections;

public class Helper : MonoBehaviour {

	public static void SetXRotation(Transform t, float x)
	{
		Quaternion r = t.localRotation;
		r.x = x;
		t.localRotation = r;
	}

	public static void SetYRotation(Transform t, float y)
	{
		Quaternion r = t.localRotation;
		r.y = y;
		t.localRotation = r;
	}
}
