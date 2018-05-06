using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{

//set this valuse in the script
	private Vector3 offset;

	public GameObject player;
	// Use this for initialization
	void Start()
	{
		offset = transform.position - player.transform.position;

	}
	// Update is called once per frame
	//this method will allow the camera follow the player and fix a angle for the player
	void LateUpdate()
	{
	//check when the player is not dead
		if (player != null)
		{
			transform.position = player.transform.position + offset;
		}
	}
}
