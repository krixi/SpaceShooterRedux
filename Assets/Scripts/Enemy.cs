using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour {

	public Health health;

	public Vector2 velocity = new Vector2 (0f, -1f);
	
	public GameObject laserPrefab;
	float lastFire = 0f;
	public float fireDelay = 0.25f;

	// Update is called once per frame
	void FixedUpdate () 
	{
		rigidbody2D.velocity = velocity;
	}

	void Update ()
	{
		if (health.IsDead)
		{
			Destroy (this.gameObject);
		}

		if (Time.time >= lastFire + fireDelay) {
			lastFire = Time.time;
			Quaternion rotation = Quaternion.LookRotation (Vector3.forward, -transform.up);
			Instantiate (laserPrefab, transform.position, rotation);
		}
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		health.Damage (1);
	}

}
