using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour {

	public Health health;

	float horizInput = 0f;
	float vertInput = 0f;

	public float leftBound = -6f;
	public float rightBound = 6f;
	public float topBound = 3f;
	public float bottomBound = -3f;
	
	public float speed = 0.75f;
	
	//public Weapon[] weapons;
	public List<Weapon> weapons = new List<Weapon>();

	private int currentWeapon = 0;

	public const int MAX_WEAPONS = 9;

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
			if ( currentWeapon >= 0 && currentWeapon < weapons.Count ) {
				weapons[ currentWeapon ].Fire();
			}
		}

		// handle input on number keys to switch weapons
		for( int i=0; i < MAX_WEAPONS; i++) {
			if (Input.GetKeyDown(string.Format("{0}", i+1)) || Input.GetKeyDown(string.Format("[{0}]", i+1)))
			{
				SetWeapon( i );
				break;
			}
		}
	}

	public void SetWeapon( int idx ) 
	{
		if ( idx >= 0 && idx < weapons.Count ) {
			currentWeapon = idx;
			for( int i=0; i < MAX_WEAPONS && i < weapons.Count; i++) {
				if ( i == currentWeapon ) {
					weapons[i].gameObject.SetActive( true );
				} else {
					weapons[i].gameObject.SetActive( false );
				}
			}
		}
	}

	public void AddWeapon( Weapon w )
	{
		weapons.Add( w );
		w.transform.parent = transform;
		w.transform.localPosition = Vector3.zero;
		SetWeapon( weapons.Count - 1 );
	}

	public void HandlePickupItem( GameObject item )
	{
		Weapon w = item.GetComponent<Weapon>();
		if (w != null)
		{
			AddWeapon( w );
		}
	}
}
