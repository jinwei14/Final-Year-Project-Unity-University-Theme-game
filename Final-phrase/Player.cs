using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
	Why are you creating a new plane every frame? Wouldn't it be better to do this only once?
	And why not use the ground plane? 
	Why did you decide to create two scripts for the player? The purpose of the classes does not 
	seem to be different enough to justify two classes.

	A) The impact of creating a new plane each frame should be pretty minimal, but certainly 
	creating it just once at start and storing it is the smarter way to go. I tend to worry 
	about minor optimizations such as this only at the end of development if there are any 
	performance issues.

	B) I'm not sure that using the ground plane is even an option, because the Plane class is 
	just a representation of a plane and can't 

	c) all the input part (Mouse) could be modified into phone (screen input) 
*/

//where the player input is comming from
//send the input to the controller

//add requirecomponent attribute
[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingObject
{

	public GameObject  wholeViewCam;
	//play owen certain amout of the grenade;
	public GameObject grenade;

	public Text numberGrenade;

	public float throwForce;
	public float moveSpeed = 5f;

	PlayerController playController;

	GunController gunController;
	// Use this for initialization
	//make the camera always look at the charater
	private Camera mainCamera;


	public Text nameText;

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		//play controller is attach to the same game object
		playController = GetComponent<PlayerController>();
		gunController = GetComponent<GunController>();
		mainCamera = Camera.main;

		//load the name of the players
			nameText.text = LevelLoader.playerName;

			//load the number of the grenade play have

		numberGrenade.text = Grenade.amount.ToString();
	}
	
	// Update is called once per frame
	void Update()
	{
		/**
         * 
         * 
         * 
         * 
         *          movement input
         * 
         * 
         */
		//get the movement input from the player Raw means it will not do default moveing
		Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		//player need to turn the movement into direction and times speed
		Vector3 moveVelocaity = moveInput.normalized * moveSpeed;
		//pass the moveVelocity to controller to handle the physics need a reference here
		playController.Move(moveVelocaity);

		/**
         * 
         * 
         * 
         * 
         * look input
         * 
         */
		//ray that from the camera through the mouse position 
		//look input
		//shoot a ray from camera the detack if cursor overlad with ground
		//then we can let the player rotate with the cursor
		Ray mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
		//abstract plane that used to detect the ray 
		Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
		float rayLength;

		//out gives back a variable value this statement retuen true if the ray intercepts
		//with the groundPlane we will know the length to the plane
		if (groundPlane.Raycast(mouseRay, out rayLength))
		{
			//returns a point at ditance units long
			Vector3 pointToLook = mouseRay.GetPoint(rayLength);

			//show lin start and end position
			Debug.DrawLine(mouseRay.origin, pointToLook, Color.blue);

			//handle the input 
			playController.LookAt(pointToLook);
		}

		/**
         * 
         * 
         * 
         * 
         * Weapon mouse input 
         * 
         */

		//if left mouse button is down
		if (Input.GetMouseButtonUp(0))
		{
			SoundManager.PlaySound("fire");

			gunController.Shoot();
		}

		//if the player press the v the big camera will be actived
		if (Input.GetKeyDown(KeyCode.V))
		{
			wholeViewCam.SetActive(true);
		}

		if (Input.GetKeyUp(KeyCode.V))
		{

			wholeViewCam.SetActive(false);
		}

		//if the player fall of the floor game over!
		if (transform.position.y < -20)
		{
//			AudioSource BGM = mainCamera.GetComponent<AudioSource>();
//			BGM.Stop();
//		//play the sound while the play is failling 
//			SoundManager.PlaySound("scream");


			this.Die();
			//SceneManager.LoadScene("Lose");
			
		}

		if (Input.GetMouseButtonDown(1))
		{

			if (Grenade.amount > 0)
			{
				//check if there is still grenade left if so then throw it! 
				ThrowGrenade();
				Grenade.amount--;
				numberGrenade.text = Grenade.amount.ToString();
			}
			else
			{
				numberGrenade.text = "0"; 
				numberGrenade.fontSize++;
				numberGrenade.color = Color.red;
				numberGrenade.fontSize--;


			}


		}



	}

	//this method will instanciate the grenade the from the weapon point and throw trows the raycast direction
	void ThrowGrenade ()
	{
	  //
		GameObject throwGrenade =  Instantiate(grenade,gunController.weaponHold.position,gunController.weaponHold.rotation);
		Rigidbody rb = throwGrenade.GetComponent<Rigidbody>();
		//add the rigidbudy a force
		rb.AddForce(transform.forward*throwForce,ForceMode.VelocityChange);


	}


}
