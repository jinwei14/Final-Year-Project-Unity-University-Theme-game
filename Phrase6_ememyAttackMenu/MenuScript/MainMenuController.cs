using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//instead of do it script by script hook up all the script in one mainmenu script is more
//easy to handle
public class MainMenuController : MonoBehaviour {

	public void PlayGame(string name)
	{
	//add the scene to the queue and load to the next level 
	 SceneManager.LoadScene(name);
	}

	//quit the programe
	public void QuitGame()
	{
	  Debug.Log("QUITT");
	  Application.Quit();
	}

	//change the menu no need to script


}
