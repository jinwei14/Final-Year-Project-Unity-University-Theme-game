using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//player enemy both need to take damage die have health etc
//this class can be shared (inherented)
public class LivingObject : MonoBehaviour, interfaceDam
{

	//it is not gonna be visable for other class and inspector
	//but player and enemy instance can access this
	public float startingHP;
	protected bool dead;
	//constant change it into public to debug
	public float health;
	//the death effect when any living entity dies
	public GameObject deathEffect;

	//assign the text to the starting HP
	public Text	healthText;
	public Slider healthBar;

	//the animation for the booming destory
	public GameObject destoryAnim;

	private bool hasBoomDam = false;
	//delegate method
	public event System.Action Dying;

	//getter setter for the booming property
	public bool hasBeenBoom()
	{
		return hasBoomDam;
	}

	public void setHasBeenBoom(bool flag)
	{
		hasBoomDam = flag;
	}

	//start the game with a plalyer starting health
	protected virtual void Start()
	{
		health = startingHP;

		healthBar.value = 1;
		//set up the text to the string;
		healthText.text = health.ToString();

		//SoundManager.PlaySound("startScene");


	}
	//shoot the enemy by calling this method
	public void TakeDamage(float damage, RaycastHit hit)
	{

		health = health - damage;


		healthBar.value = health / startingHP;
		//uodating the text
		healthText.text = health.ToString();
		if (health <= 0)
		{
			SoundManager.PlaySound("yelling");
			Die();
			//produce the death effect here 
			//destory after 2 sec
			Destroy(Instantiate(deathEffect, transform.position, Quaternion.FromToRotation(Vector3.down, Vector3.forward)) as GameObject, 2);

		}
	}

	//need to be fix duplicated code!!
	public void TakeAttaction(float damage)
	{
		//player been attacked
		SoundManager.PlaySound("pain");
		health = health - damage;
		healthBar.value = health / startingHP;
		healthText.text = health.ToString();
		if (health <= 0)
		{    
			//if the player died
			Die();
			//load to the lose scene
			//SceneManager.LoadScene("Lose");

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
			Dying();
		}

		GameObject.Destroy(gameObject);
	}


}
