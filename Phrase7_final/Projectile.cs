using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

	
	public LayerMask collisionMask;
	//speed and the damage point of the bullet 
	float speed = 10;
	float damage = 1;

	//since let the bullet flying in the game world is costy so that 
	//we create a life time 4 sec of the bullet 
	float existTime = 4; 

	void Start()
	{
	//the bullet will aotomatically destoried after 4 seconds
	  Destroy(gameObject,existTime);
	  //here need to thing about when the enemy is too near the player
	  //the gun will actually inside the player this can be soved by adding the 
	  //collision array 
	}
	public void setSpeed (float newSpeed)
	{
		speed = newSpeed;
	}
	// Update is called once per frame
	void Update ()
	{
		float moveDistance = speed * Time.deltaTime;
		checkCollisions (moveDistance);
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void checkCollisions(float moveDistance)
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide)) 
		{
			OnHitObject (hit);
			 
		}
	}

	void OnHitObject (RaycastHit hit)
	{
		interfaceDam damageableObject = hit.collider.GetComponent<interfaceDam> ();
		if (damageableObject != null) {
			damageableObject.TakeDamage(damage, hit);
		}
		GameObject.Destroy (gameObject);
	}
}
