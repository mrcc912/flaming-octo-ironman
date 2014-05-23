using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PrefabHolder : MonoBehaviour {


	public GameObject spikePrefab;
	public GameObject sandPrefab;
	public GameObject stonePrefab;

	public static PrefabHolder instance;

	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if(!Application.isPlaying)
		{
			instance = this;
		}
	}
}
