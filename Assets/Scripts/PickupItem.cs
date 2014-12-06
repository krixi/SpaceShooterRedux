using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour {
	
	public GameObject itemPrefab;

	void OnTriggerEnter2D (Collider2D other) 
	{
		Player p = other.GetComponent<Player>();
		if (p != null) 
		{
			GameObject obj = Instantiate( itemPrefab ) as GameObject;
			p.HandlePickupItem( obj );

			Destroy (this.gameObject);
		}
	}
}
