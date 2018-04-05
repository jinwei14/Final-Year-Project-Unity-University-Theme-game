using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public LayerMask collisionMask;
	float speed = 10;
	float damage = 1;

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
