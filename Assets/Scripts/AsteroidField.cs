using UnityEngine;
using System.Collections;

public class AsteroidField : MonoBehaviour {


	public GameObject[] asteroidPrefabs;

	public Vector2 movementSpeed = new Vector2 (0f, -1f);

	public Vector2 xRange = new Vector2(-6f, 6f);

	public float spawnRate = 1f;

	float lastSpawnTime = 0f;

	// Use this for initialization
	void Start () {
		if (asteroidPrefabs.Length == 0){
			Debug.LogError ("You must set some asteroid prefabs");
		}
	}

	void Update() {

		if (Time.time >= lastSpawnTime + spawnRate)
		{
			Vector3 spawnPos = new Vector3 (Random.Range (xRange.x, xRange.y), 0f, 0f);
			GameObject obj = Instantiate (asteroidPrefabs[Random.Range (0, asteroidPrefabs.Length)], transform.TransformPoint(spawnPos), Quaternion.identity) as GameObject;
			obj.transform.parent = transform;
			lastSpawnTime = Time.time;
			// Set the movement speed of the asteroid
			obj.rigidbody2D.velocity = movementSpeed;
		}

	}
}
