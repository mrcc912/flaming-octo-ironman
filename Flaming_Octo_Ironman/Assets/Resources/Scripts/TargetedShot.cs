using UnityEngine;
using System.Collections;

public class TargetedShot : MonoBehaviour {

	public GameObject projectile;
	public bool canShoot;

	void Awake()
	{
		canShoot = true;
	}

	void Update()
	{
		if (Input.GetMouseButtonUp(0) && canShoot)
		{
			Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			Quaternion rotation = Quaternion.FromToRotation(Vector2.up, direction);

			GameObject shot = (GameObject)Instantiate(projectile, transform.position, rotation);
			shot.GetComponent<TargetedProjectile>().Launch(direction);
		}
	}
}
