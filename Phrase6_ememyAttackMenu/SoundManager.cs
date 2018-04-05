using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	//will be update later
	public static AudioClip fireSound;
	static AudioSource audioSrc;
	// Use this for initialization
	void Start()
	{
		fireSound = Resources.Load<AudioClip>("GUN_FIRE") as AudioClip;

		audioSrc = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	//can be updated later on
	public static void PlaySound(string clip)
	{
		//if (!audioSrc.isPlaying)
		//{
			switch (clip)
			{
			
				case "fire":
					audioSrc.PlayOneShot(fireSound);
					//print("shooting testing");
					break;
		
			}
		//}
	}
}
