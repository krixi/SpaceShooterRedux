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
		Health h = col.GetComponent<Health>();
		if (h) {
			h.Damage (damage);
		} else {
			Destroy (col.gameObject);
		}
		Destroy (this.gameObject);
	}
}
