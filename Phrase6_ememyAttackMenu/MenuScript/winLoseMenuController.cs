using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winLoseMenuController : MonoBehaviour {

	//load the corresponding scene

	//Application.LoadLevel() is older way
	public void LoadLevel(string name)
	{
		SceneManager.LoadScene(name);
	}

	//quit the programe
	public void QuitGame()
	{
	  Debug.Log("QUITT");
	  Application.Quit();
	}
}
