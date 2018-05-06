using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//as for code reusable set the damage interface 
//for more object to use
public interface interfaceDam {
	//take attacktion example the enemy damage the player
	void TakeAttaction (float damage);

//take damage by clicking the mouse shoot a raycast to damage the enemy
	void TakeDamage (float damage, RaycastHit hit);

}
