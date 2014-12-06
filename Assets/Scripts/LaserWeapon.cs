using UnityEngine;
using System.Collections;

public class LaserWeapon : Weapon {

	public GameObject projectilePrefab;
	public AudioClip projectileSound;
	float lastFire = 0f;
	public float fireDelay = 0.25f;
	
	override public void Fire () {

		// Fire if possible.
		if (Time.time >= lastFire + fireDelay) {
			lastFire = Time.time;
			Instantiate (projectilePrefab, transform.position, transform.rotation);
			audio.PlayOneShot (projectileSound);
		}

	}
}
