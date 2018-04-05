using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//can be used for equip weapon enemy can also equip guns
public class GunController : MonoBehaviour
{

	//the point that could hold the weapon
	public Transform weaponHold;

	//gun that is holding
	Gun gunUsing;
	//allow us to assign starting weapon
	//public so that the unity can assign
	public Gun startGun;

	void Start()
	{
		if (startGun != null)
		{
			EquipGun(startGun);
		}	
	}


	//instanciate the gun to the gun contorller
	public void EquipGun(Gun gunToEquip)
	{
		if (gunUsing != null)
		{
			Destroy(gunUsing.gameObject);
		}
		//initiate the gun and cast to the gun
		gunUsing = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;

		//make gun a child
		gunUsing.transform.parent = weaponHold;
	}

	public void Shoot()
	{

		//check if there is equiped weapon
		if (gunUsing != null)
		{
			
			gunUsing.shoot();
		}
	
	}
}
