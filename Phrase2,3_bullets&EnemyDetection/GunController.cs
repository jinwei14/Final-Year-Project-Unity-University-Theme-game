using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//can be used for equip weapon enemy can also equip guns 
public class GunController : MonoBehaviour
{
    ////gun have two state fire or not firing
    //public bool isFiring;

    //public BulletController bullet;
    //public float bulletSpeed;

    ////every time we set up the gun we set the timeBetweenShots equal to 
    ////the shot counter
    //public float timeBetweenShots;
    //private float shotCounter;

    ////the start function that the bullet will fire
    //public Transform firepoint;
    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (isFiring)
    //    {
    //        shotCounter -= Time.deltaTime;

    //    }
    //}

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

    public void EquipGun(Gun gun)
    {

        if (gunUsing != null)
        {
            Destroy(gunUsing.gameObject);
        }
        //initiate the gun 
        gunUsing = Instantiate(gun, weaponHold.position, weaponHold.rotation) as Gun;

        //make gun a child 
        gunUsing.transform.parent = weaponHold;
    }

    public void Shoot() {
        //check if there is equiped weapon 
        if (gunUsing != null) {
            gunUsing.Shoot();
        }
    }
}
