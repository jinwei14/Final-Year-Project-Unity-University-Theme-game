using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

	//the positin of the gun mouth
	public Transform gunMouth;

	//which type of the bullet we are shoting the type is projectile
	public Projectile bullet;
	//the rate of the fire
	public float msBetweenshots = 100;
	//the speed the bullet will leave the gun
	public float muzzleVelocity = 35;

	// Use this for initialization
	float nextShotTime;
	//call this method when player left mouse is press down
	//shot bullet every ms 

	public void shoot(){
		
		if (Time.time > nextShotTime) {
			//assign the next time by plus the 100 ms
			nextShotTime = Time.time + msBetweenshots / 1000;

			//instantiate the bullet 
			Projectile newProjectile = Instantiate (bullet, gunMouth.position, gunMouth.rotation) as Projectile;
			newProjectile.setSpeed (muzzleVelocity);
		}
	}
}
