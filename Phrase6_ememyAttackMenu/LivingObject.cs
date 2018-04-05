using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player enemy both need to take damage die have health etc
//this class can be shared (inherented)
public class LivingObject : MonoBehaviour, interfaceDam {

	//it is not gonna be visable for other class and inspector
    //but player and enemy instance can access this 
	public float startingHP;
	protected bool dead;
	protected float health;


	//delegate method
	public event System.Action Dying;

	protected virtual void Start()
	{
		health = startingHP;
	}
	public void TakeDamage (float damage, RaycastHit hit)
	{
		health = health - damage;

		if (health <= 0) 
		{
			Die ();
		}
	}

	//in here we dont need to find the producer which to die
    //we can use a event this event will be triggered when
    //the living object died

	protected void Die()
	{
		dead = true;
		if (Dying != null) 
		{
			Dying ();
		}
		GameObject.Destroy (gameObject);
	}

}
