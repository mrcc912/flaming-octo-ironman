using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	public Character character;
	public GameObject magicLens;
	public GameObject[] levels = new GameObject[4];

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
		character.transform.position = GameObject.Find("Spawn").transform.position;
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

			character.transform.position = GameObject.Find("Spawn").transform.position;
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

			character.transform.position = GameObject.Find("Spawn").transform.position;
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

			character.transform.position = GameObject.Find("Spawn").transform.position;
		}

		// Level transition: Apples --> YOU WIN MOTHAFUCKA
		if (spawner.furthestCheckpoint == 20 && currentLevelID == 3)
		{
			// YOU WIN THE GAME
		}
	}
}