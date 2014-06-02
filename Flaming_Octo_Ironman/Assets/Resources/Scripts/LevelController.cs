using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {

	public Character character;
	public GameObject magicLens;
	public GameObject[] levels = new GameObject[4];
	public int unitsHealed = 0;

	private TargetedShot shooter;
	private Respawn spawner;
	private GameObject currentLevel;
	private int currentLevelID;

	void Awake()
	{
		currentLevelID = 0;
		currentLevel = (GameObject)Instantiate(levels[currentLevelID], Vector3.zero, Quaternion.identity);

		spawner = character.GetComponent<Respawn>();
		shooter = character.GetComponent<TargetedShot>();

		magicLens.SetActive(false);
		character.canTeleport = false;
		shooter.canShoot = false;
	}

	void Start()
	{
		character.transform.position = currentLevel.transform.Find("Spawn").transform.position;
	}
	
	void Update()
	{
		/* Level transition: Intro --> Teleport
		 * Mechanics:
		 * 		1. Teleport: True
		 * 		2. Scry: False
		 * 		3. Shoot: False
		 */
		if (spawner.furthestCheckpoint == 3 && currentLevelID == 0)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);

			character.canTeleport = true;

			character.transform.position = currentLevel.transform.Find("Spawn").transform.position;

			SetTrapsToKinematic();
		}

		/* Level transition: Teleport --> Ghostery
		 * Mechanics:
		 * 		1. Teleport: False
		 * 		2. Scry: True
		 * 		3. Shoot: False
		 */
		if (spawner.furthestCheckpoint == 8 && currentLevelID == 1)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);

			character.canTeleport = false;
			magicLens.SetActive(true);

			character.transform.position = currentLevel.transform.Find("Spawn").transform.position;

			SetTrapsToKinematic();
		}

		/* Level transition: Ghostery --> Apples
		 * Mechanics:
		 * 		1. Teleport: False
		 * 		2. Scry: False
		 * 		3. Shoot: True
		 */
		if (spawner.furthestCheckpoint == 12 && currentLevelID == 2)
		{
			currentLevelID++;
			Destroy (currentLevel);
			currentLevel = (GameObject)Instantiate (levels[currentLevelID], Vector3.zero, Quaternion.identity);

			magicLens.SetActive(false);
			shooter.canShoot = true;

			character.transform.position = currentLevel.transform.Find("Spawn").transform.position;

			SetTrapsToKinematic();
		}

		// Level transition: Apples --> YOU WIN MOTHERFUCKER
		if (unitsHealed == 10 && currentLevelID == 3)
		{
			Destroy (currentLevel);
			Destroy (character.gameObject);
		}
	}

	private void SetTrapsToKinematic()
	{
		List<GameObject> traps = GetObjectsWithWord("trap");

		foreach (GameObject trap in traps)
		{
			if (trap.GetComponent<Rigidbody2D>() != null)
			{
				trap.rigidbody2D.isKinematic = true;
			}
		}
	}

	private List<GameObject> GetObjectsWithWord(string keyword)
	{
		List<GameObject> gameObjects = new List<GameObject>();
		Object[] allObjects = FindObjectsOfType(typeof(GameObject));

		foreach (GameObject thing in allObjects)
		{
			if (thing.activeInHierarchy)
			{
				if (thing.name.ToLower().Contains(keyword.ToLower()))
				{
					gameObjects.Add((GameObject) thing);
				}
			}
		}

		return gameObjects;
	}
}