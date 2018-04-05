using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//require class have rigid to attach to it
[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	// Use this for initialization contrain to collision
	Rigidbody myRigidBody;

	Vector3 moveVelocity;
	// Use this for initialization
	void Start () {
		//find the Rigidbody and refer to this player
		myRigidBody = GetComponent<Rigidbody> ();
	}

	public void Move(Vector3 _velocity){
		moveVelocity = _velocity;
	}

	//need to be executed at small regular steps
	//if you got slow frame rate get the frame increament
	void FixedUpdate(){
		//velocity times time between each fixed frame
		myRigidBody.MovePosition (myRigidBody.position + moveVelocity * Time.fixedDeltaTime);
	}
		
	public void LookAt(Vector3 lookPoint){
		//instead of turn to the cursor fix the y axis
		Vector3 heightCollectedPoint = new Vector3 (lookPoint.x, transform.position.y, lookPoint.z);
		//the real point //need to rise to the Z axis
		transform.LookAt (heightCollectedPoint);
	}
		
}
