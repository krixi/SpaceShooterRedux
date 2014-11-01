using UnityEngine;
using System.Collections;

public class SetRigidbody2dVelocity : MonoBehaviour 
{
	public Vector2 movementSpeed = new Vector2 (0f, -1f);

	// Use this for initialization
	void Start () {
		// Set the movement speed of the asteroid
		rigidbody2D.velocity = movementSpeed;
	}
}
