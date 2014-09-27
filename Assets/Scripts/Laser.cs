using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	public float speed = 100f;
	public float timeOut = 5f;
	public int damage = 1;

	// Use this for initialization
	void Start () 
	{
		Destroy (this.gameObject, timeOut);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.up * Time.deltaTime * speed;
	}

	void OnTriggerEnter2D (Collider2D col) {
		Enemy e = col.GetComponent<Enemy>();
		if (e) {
			e.Damage (damage);
			Destroy (this.gameObject);
		} else {
			if (col.tag != "Player") {
				Destroy (col.gameObject);
				Destroy (this.gameObject);
			}
		}
	}
}
