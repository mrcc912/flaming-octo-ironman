using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public GameObject character;
	public GameObject[] levels = new GameObject[4];

	private Respawn spawner;
	private GameObject currentLevel;
	private int currentLevelID;

	void Awake()
	{
		currentLevelID = 0;
		currentLevel = (GameObject)Instantiate(levels[currentLevelID], Vector3.zero, Quaternion.identity);

		spawner = character.GetComponent<Respawn>();
	}
	
	void Update()
	{
		if (spawner.furthestCheckpoint == 3 && currentLevelID == 0)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);
		}

		if (spawner.furthestCheckpoint == 8 && currentLevelID == 1)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);
		}

		if (spawner.furthestCheckpoint == 12 && currentLevelID == 2)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);
		}
	}
}