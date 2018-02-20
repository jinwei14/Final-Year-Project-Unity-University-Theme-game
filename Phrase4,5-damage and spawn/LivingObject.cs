using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//player enemy both need to take damage die have health etc
//this class can be shared (inherented)
public class LivingObject : MonoBehaviour, interfaceDam {

    //it is not gonna be visable for other class and inspector
    //but player and enemy instance can access this 
    protected float health;
    protected bool dead;
    public float startingHP;

    //delegate method void method with no parametres
    public event System.Action Dying;
    //assign the starting health to health
    public virtual void Start() {
        health = startingHP;
    }

    //in here we dont need to find the producer which to die 
    //we can use a event this event will be triggered when 
    //the living object died
    protected void Die() {
        if (Dying != null)
        {
            Dying();
        }
        dead = true;
        GameObject.Destroy(gameObject);
    }
    public void TakeDamage(float damage, RaycastHit hit)
    {
        health = health - damage;

        if (health <= 0 && !dead) {
            Die();
        }
    }
}
