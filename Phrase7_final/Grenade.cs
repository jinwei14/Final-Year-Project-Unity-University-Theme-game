using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public static float amount = 25f;
    //the grenda will have a count down explorsion effect which is 3 sec (reasonable)
    public float delay = 3f;

    //the radius and the explore force the grenada
    public float exploreRadius = 5f;
	public float exploreForce = 700f;
     float countDown; 

     bool hasExploded = false;

     public GameObject explosionAnim;
	// Use this for initialization
	void Start () {
		countDown = delay;
	}
	
	// Update is called once per frame
	void Update()
	{
		//keep minus down the sec to the explorsion 
		countDown -= Time.deltaTime;

		if (countDown <= 0 && !hasExploded)
		{
		  Explore();
			
		 hasExploded = true;

		}
	}

	//this will play the animation and make the explosion
	void Explore()
	{
		//1. show the explosion effect
		Destroy(Instantiate(explosionAnim, transform.position, transform.rotation), 3);

		//2. finding the nearby onjetc 
		//adding the force 
		//damage 

		//this method allow us to find the all the object will a given posiopn with given ridus.
		//unity will retuen a list 
		Collider[] colliderArr = Physics.OverlapSphere(transform.position, exploreRadius);

		foreach (Collider nearObjects in colliderArr)
		{
			//not all the object are rigid body 
			Rigidbody body = nearObjects.GetComponent<Rigidbody>();

			if (body != null)
			{
				//add force will need the distance between and the Mass of each obj etc
				body.AddExplosionForce(exploreForce, transform.position, exploreRadius);
			}

			LivingObject aliveThings = nearObjects.GetComponent<LivingObject>();
			if (aliveThings != null)
			{
				//the booming will damage 2 point of the health
				if (aliveThings.tag == "Enemy" && !aliveThings.hasBeenBoom())
				{
					
					RaycastHit empty = new RaycastHit();
					aliveThings.TakeDamage(3f, empty);
					aliveThings.setHasBeenBoom(true);
				}
				else if (aliveThings.tag == "Player")
				{
					aliveThings.TakeAttaction(5f);

				}

			}


			//Debug.Log("these are+ " + colliderArr.Length.ToString());
		}
	     //3. remove the grenade and play the sound
		SoundManager.PlaySound("boom");
	     Destroy(gameObject);

	}
}
