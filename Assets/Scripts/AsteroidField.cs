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
	
	// Update is called once per frame
	void Update () {
		// Move all child objects by the movement speed.
		for (int i=0; i<transform.childCount; i++)
		{
			transform.GetChild(i).Translate (movementSpeed);
		}


		if (Time.time >= lastSpawnTime + spawnRate)
		{
			Vector3 spawnPos = new Vector3 (Random.Range (-6f, 6f), 0f, 0f);
			GameObject obj = Instantiate (asteroidPrefabs[Random.Range (0, asteroidPrefabs.Length)], transform.TransformPoint(spawnPos), Quaternion.identity) as GameObject;
			obj.transform.parent = transform;
			lastSpawnTime = Time.time;
		}

	}
}
