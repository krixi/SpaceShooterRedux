using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public int health = 3;

	public void Damage (int amount) 
	{
		health = Mathf.Max (0, health - amount);
	}
	
	public bool IsDead {
		get {
			return (health == 0);
		}
	}
}
