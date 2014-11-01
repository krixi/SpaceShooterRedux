using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour {

	public Health health;
	public GUIManager guiManager;

	float horizInput = 0f;
	float vertInput = 0f;

	public float leftBound = -6f;
	public float rightBound = 6f;
	public float topBound = 3f;
	public float bottomBound = -3f;
	
	public float speed = 0.75f;

	public GameObject laserPrefab;
	public AudioClip laserSound;
	float lastFire = 0f;
	public float fireDelay = 0.25f;

	void Start ()
	{
		guiManager.DrawGUILayout += DrawHealthGUI;
	}

	void Update () 
	{
		if (health.IsDead) {
			Destroy (this.gameObject);
		}

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
				audio.PlayOneShot (laserSound);
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		health.Damage (1);
	}

	void DrawHealthGUI () 
	{
		GUILayout.Label (string.Format ("Player health: {0}", health.health));
	}
}
