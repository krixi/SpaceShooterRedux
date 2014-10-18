using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public GameObject[] prefabs;

	public Vector2 xRange = new Vector2(-6f, 6f);

	public float spawnRate = 1f;
	
	float lastSpawnTime = 0f;

	// Use this for initialization
	void Start () {
		if (prefabs.Length == 0){
			Debug.LogError ("You must set some asteroid prefabs");
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (Time.time >= lastSpawnTime + spawnRate)
		{
			Vector3 spawnPos = new Vector3 (Random.Range (xRange.x, xRange.y), 0f, 0f);
			GameObject obj = Instantiate (prefabs[Random.Range (0, prefabs.Length)], transform.TransformPoint(spawnPos), Quaternion.identity) as GameObject;
			obj.transform.parent = transform;
			lastSpawnTime = Time.time;
		}
		
	}
}
