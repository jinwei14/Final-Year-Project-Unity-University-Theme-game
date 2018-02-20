using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * use raycasts instead of OnTriggerEnter to detect projectile collisions:
 * At very high projectile speeds OnTriggerEnter might not be called 
 * (since the projectile would be in front of enemy one frame, and 
 * through it the next). Raycasting just makes sure that collisions 
 * will work no matter the projectile speed.
 * 
 * 
 **/
public class Projectile : MonoBehaviour {

    float speed = 10;
    //determind which layer or object the projectile will hit
    public LayerMask mask;

    //the damage of the projectile
    float damage = 1;
    public void setSpeed(float newSpeed) {
        speed = newSpeed;
    }

    void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        Destroy(this);
    }

    void CollisionDetection(float distance) {
        //starting position and position
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit objectHit;

        /*
         bullets with high velocity might fly through obstacles even if it's 
         rendered in fixedUpdate(). You can prevent it by making thick obstacles
         but the best solution is to detect whether there is obstacle blocks 
         the bullet's direction or not by raycasts
         ﻿*/
        if (Physics.Raycast(ray, out objectHit, distance, mask, QueryTriggerInteraction.Collide))
        {
            //print out the name for debug
            print(objectHit.collider.gameObject.name);

            //before the object destory it self it need to inform the object that it 
            //collied with that object has been hit

            //get the object we collide with and get the component
            interfaceDam damagedObj = objectHit.collider.GetComponent<interfaceDam>();

            //not all the game object are attached to that
            if (damagedObj != null) {
                damagedObj.TakeDamage(damage, objectHit);
            }
            GameObject.Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        //the movelength of the projectile
        float moveLength = speed * Time.deltaTime;
        CollisionDetection(moveLength);

        transform.Translate (Vector3.forward * Time.deltaTime * speed);

        if (moveLength > 5) {
            DestroyScriptInstance();
        }

    }
}
