using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	[SerializeField] private GameObject projectile;
	[SerializeField] private Transform spawnLocation;
	[SerializeField] private float repeatRate = 0.5f;


	void Start()
	{
		InvokeRepeating("launchProjectile", 0, repeatRate);
	}

	private void launchProjectile()
	{
		Instantiate(projectile, spawnLocation.position, Quaternion.identity);
	}
}
