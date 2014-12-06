using UnityEngine;
using System.Collections;

public class CompoundWeapon : Weapon 
{
	public Weapon[] subweapons;

	override public void Fire()
	{
		foreach( Weapon w in subweapons )
		{
			w.Fire();
		}
	}
}
