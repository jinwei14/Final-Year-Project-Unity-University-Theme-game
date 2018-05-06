using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
	//will be update later
	public static AudioClip fireSound;
	public static AudioClip painSound;
	public static AudioClip killingSound;
	public static AudioClip yellingSound;
	public static AudioClip explosionSound;
	public static AudioClip screamSound;
	public static AudioSource audioSrc;
	// Use this for initialization
	void Start()
	{
		fireSound = Resources.Load<AudioClip>("GUN_FIRE") as AudioClip;
		painSound = Resources.Load<AudioClip>("Pain")as AudioClip;
		killingSound = Resources.Load<AudioClip>("I_will_kill_you")as AudioClip;
		//Evil Yelling
		yellingSound = Resources.Load<AudioClip>("Evil Yelling")as AudioClip;

		explosionSound = Resources.Load<AudioClip>("GrenadeExplosion")as AudioClip;
		screamSound = Resources.Load<AudioClip>("PsychoScream")as AudioClip;
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

			case "pain":
				audioSrc.PlayOneShot(painSound);
				break;

			case "killYou":
				audioSrc.PlayOneShot(killingSound);
				break;

			case "yelling":
				audioSrc.PlayOneShot(yellingSound);
				break;

			case "boom":
				
				audioSrc.PlayOneShot(explosionSound);

				break;


			case "scream":
				audioSrc.PlayOneShot(screamSound);
				break;
		
		}
		//}
	}
}
