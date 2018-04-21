using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//instead of do it script by script hook up all the script in one mainmenu script is more
//easy to handle
public class MainMenuController : MonoBehaviour {

//the image using to fadd in and out
public Image blackImage;
//the fade in and out animator
public Animator anim;

	public void PlayGame(string name)
	{
	//add the scene to the queue and load to the next level 
	 //SceneManager.LoadScene(name);
		//load the new scene
		SceneManager.LoadScene(name);

	}

	//quit the programe
	public void QuitGame()
	{
	  Debug.Log("QUITT");
	  Application.Quit();
	}

	//change the menu no need to script

//	//the fade out animation 
//	public void FadeOut()
//	{
//	//start the fade out
//		anim.SetBool("Fade",true);
//		//wait until the alpha is 1
//		//yield return new WaitUntil(()=>blackImage.color.a ==1);
//
//
//	}	

}
