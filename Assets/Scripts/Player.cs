using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	float horizInput = 0f;
	float vertInput = 0f;

	public float leftBound = -6f;
	public float rightBound = 6f;
	public float topBound = 3f;
	public float bottomBound = -3f;
	
	public float speed = 0.75f;

	//public float thrust = 100f;
	//public float backwardsModifier = 0.75f;
	//public float rotationRate = 10f;

	public GameObject laserPrefab;
	float lastFire = 0f;
	public float fireDelay = 0.25f;


	void Update () 
	{
		horizInput = Input.GetAxis ("Horizontal");
		vertInput = Input.GetAxis ("Vertical");

		float xPos = transform.position.x;
		xPos += (horizInput * speed);
		xPos = Mathf.Clamp (xPos, leftBound, rightBound);
		float yPos = transform.position.y;
		yPos += (vertInput * speed);
		yPos = Mathf.Clamp (yPos, bottomBound, topBound);
		transform.position = new Vector3 (xPos, yPos, transform.position.z);

		if (Input.GetButton ("Fire1")) {
			if (Time.time >= lastFire + fireDelay) {
				lastFire = Time.time;
				Instantiate (laserPrefab, transform.position, transform.rotation);
			}
		}
	}

//	void FixedUpdate () 
//	{
//
//		if (vertInput > 0f) {
//			rigidbody2D.AddForce (transform.up * thrust);
//		} else if (vertInput < 0f) {
//			rigidbody2D.AddForce (-transform.up * thrust * backwardsModifier);
//		}
//	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		if (col.collider.tag == "Meteor") 
		{
			Destroy (this.gameObject);
		}
	}
}
