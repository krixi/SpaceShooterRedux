using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int health = 3;

	public string playerTag = "Player";

	public GameObject target;

	public float thrust = 10f;

	void Start() {
		if (target == null) {
			target = GameObject.FindWithTag (playerTag);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (target != null) {
			Vector3 direction = target.transform.position - transform.position;
			Debug.DrawRay (transform.position, direction);
			rigidbody2D.AddForce (direction.normalized * thrust);
			//rigidbody2D.velocity = new Vector2 (direction.x, direction.y);
		}
	}

	void Update ()
	{
		if (IsDead)
		{
			Destroy (this.gameObject);
		}
	}


	public void Damage (int amount) {
		health = Mathf.Max (0, health - amount);
	}

	public bool IsDead {
		get {
			return (health == 0);
		}
	}

	void OnCollisionEnter2D (Collision2D col) 
	{
		Damage (1);
	}

}
