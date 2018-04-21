using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingObject
{

public Text nameText;
	public enum  State
	{
		Idle,
		Chasing,
		Attacking}

	;
	//get the material when lauching the attach the color will turn angry
	Material outfit;
	State currentState;
	//get the nav mesh agent component
	NavMeshAgent navMeshAgent;
	//need to know the game object that we need to chase
	Transform target;

	float fixedAttackDistance = 2.1f;

	float timeBetweenAttack = 1;
	float nextAttackTime;

	//when the enemy launch the attation the enemy need to keep some distance to the player
	float myRadius;
	float targetRadius;

	LivingObject targetEntity = null;

	//sign that indecate that if the target is alive
	bool hasLiveTarget;
	// Use this for initialization


	protected override void Start()
	{
		base.Start();

		outfit = GetComponent<Renderer>().material;
		//reference of the path finder agent
		navMeshAgent = GetComponent<NavMeshAgent>();

		nameText.text = LevelLoader.enemyName;

		//if the player object exist 
		if (GameObject.FindGameObjectWithTag("Player") != null)
		{
			//set this flag to be true
			hasLiveTarget = true;
			currentState = State.Chasing;
			//give the reference of out player
			target = GameObject.FindGameObjectWithTag("Player").transform;


			//get the enemy radius
			myRadius = GetComponent<NavMeshAgent>().radius;
			//get the target radius
			targetRadius = target.GetComponentInChildren<CapsuleCollider>().radius;

			//this enetty needs to the play entity
			targetEntity = target.GetComponent<LivingObject>();

			//assign the text to the starting HP
			//targetHealthText.text = targetEntity.startingHP.ToString();

			targetEntity.Dying += onTargetDeath;
			//A coroutine is a function that can suspend its execution (yield) 
			//until the given given YieldInstruction finishes.
			StartCoroutine(UpdatePath());
		}
	}

	//the target die
	void onTargetDeath()
	{

		hasLiveTarget = false;
		//set the state to idle
		currentState = State.Idle;

		//SceneManager.LoadScene("Lose");

	}
	
	// Update is called once per frame when the ememy is too near the player the
	//enemy should turnning a angry color and launch an attack
	void Update()
	{
		
		//this will save the frame rate by fixing the attach time is 1 sec after the previous attach
		//only do this block of code when we have target 
		if (Time.time > nextAttackTime && hasLiveTarget)
		{
			//Vector3.Distance is using the squart root-could Be really expensive as it will drop down the frame rate 
			//so that we use another 
			float attackDis = (target.position - transform.position).sqrMagnitude;

			//if we are close enough
			if (attackDis < Mathf.Pow(fixedAttackDistance, 2))
			{
				nextAttackTime = Time.time + timeBetweenAttack;
				//start attck corroutine.
				StartCoroutine(Attack());
			}
		}
	}

	//enemy start attack the player this will gives out an animation from the stating position to the
	//target position and then turns out as an angry color
	//while we are attcking we dont want to use the path finding
	IEnumerator Attack()
	{
		//when we attack the current state changed. 
		currentState = State.Attacking;
		//disable the pathfinder agent
		navMeshAgent.enabled = false;

		Vector3 originalPos = transform.position;
		//leap right on top the player
		Vector3 attackPos = target.GetChild(2).position;

		float percent = 0;

		float attackSpeed = 3;
		//change the colro to red while attaching
		outfit.color = Color.red;

		bool hasBeenAttacked = false;

		while (percent <= 1)
		{

			//when the quadraticEquation equal to oen the percentage will equal to half 
			//then take damage to the player
			if (percent >= .5f && !hasBeenAttacked)
			{
				hasBeenAttacked = true;
			//take damage 1 of the heal point
				targetEntity.TakeAttaction(1);
				//if the player died after the attack it should load to the lose scene
			}


			percent += Time.deltaTime * attackSpeed;

			//the quadraticEquation numebr is between 0 to 1
			float quadraticEquation = (-percent * percent + percent) * 4;
			//transform from the orginal position to the attack position
			transform.position = Vector3.Lerp(originalPos, attackPos, quadraticEquation);

			//here the health point need to be subtract  
			//skip a frame between each steps in the while loop
			yield return null;
		}

		//clear the color when finished attacking
		outfit.color = Color.white;
		//current state go back to chasing 
		currentState = State.Chasing;
		navMeshAgent.enabled = true;


	}

	IEnumerator UpdatePath()
	{
		float refreshRate = .25f;

		//double checking to garentee there is a target to chase
		while (target != null && hasLiveTarget )
		{
			//we only do the pathing finding only when the state is in chasing 
			if (currentState == State.Chasing)
			{
				//here I want the enemy attack goes a little into the target 
				//firstly get the direction to the target 
				//Vector3 dirToTarget = (target.position - transform.position).normalized;

				Vector3 destination = new Vector3(target.position.x, 0, target.position.z);
				//move the enemy towards the player try to collide with the 
				//player
				//once the object destoryed pathfinding will not be called.
				if (!dead)
				{
					navMeshAgent.SetDestination(destination);
				}
			}
			yield return new WaitForSeconds(refreshRate);
		}
	}
}
