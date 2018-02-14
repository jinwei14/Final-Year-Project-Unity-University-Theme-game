using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    //the positin of the gun mouth
    public Transform mouth;

    //which type of the bullet we are shoting the type is projectile
    public Projectile bullet;
    //the rate of the fire
    public float timeBetweenShots = 100;
    //the speed the bullet will leave the gun
    public float shotVelocity = 35;
    // Use this for initialization
    float nextTimeShot;

    public void Shoot()
    {

        //we can only if the current time is greater than the next shot time
        if (Time.time > nextTimeShot)
        {

            //assign the next time by plus the 100 ms
            nextTimeShot = Time.time + timeBetweenShots/1000;
            //instantiate the bullet 
            Projectile newBullet = Instantiate(bullet, mouth.position, mouth.rotation) as Projectile;

            newBullet.setSpeed(shotVelocity);

        }


    }
}
