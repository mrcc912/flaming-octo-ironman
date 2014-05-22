using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour {

	[SerializeField] private GameObject projectile;
	[SerializeField] private Transform spawnLocation;
	[SerializeField] private float repeatRate = 0.5f;
	[SerializeField] private Direction direction = Direction.DOWN;
	[SerializeField] private float xMagnitude;
	[SerializeField] private float yMagnitude;
	
	void Start()
	{
		InvokeRepeating("launchProjectile", 0, repeatRate);
	}

	private void launchProjectile()
	{
		GameObject toFire = (GameObject)Instantiate(projectile, spawnLocation.position, Quaternion.identity);
		toFire.GetComponent<Projectile>().init(direction, xMagnitude, yMagnitude);
	}

	public enum Direction
	{
		UP, DOWN, LEFT, RIGHT
	}

}
