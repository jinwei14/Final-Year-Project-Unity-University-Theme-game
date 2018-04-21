using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour
{


	//reference to the loading screen
	public GameObject loadingScreen;
	public GameObject customizedScreen;

	//the progress text of the loading screen
	public Slider progressBar;

	//the progress text of the loading screen
	public Text progressPercent;

	//output text after hit the play button
	public Text outputText;

	public InputField enemyField;
	public InputField playerField;

	public static string enemyName;
	public static string playerName;
	//function that can be called from other script or a button to load the level
	public void LoadLevel(string sceneName)
	{

		enemyName = enemyField.text; 
			playerName = playerField.text;
//		if (enemyName.Equals(null) && enemyName.Equals(null))
//		{
//			Debug.Log("enemy is " + enemyName + "player is " + playerName);
//		}

		if (sceneName == "Game" && enemyName.Length > 0 && enemyName.Length > 0)
		{
			
			//set the loading scree active to be true 
			loadingScreen.SetActive(true);
			customizedScreen.SetActive(false);
			//start the coroutine of loading the scene
			StartCoroutine(LoadAsynchronously(sceneName));
		}
		else
		{
			outputText.text = "please enter both names! ";

		}
	}

	IEnumerator LoadAsynchronously(string sceneName)
	{
		
		//load the scene with the name sceneName
		//async would not bock the main thread and return a operation variable

		//mention here unity will load the scene up to .9f this is because that 
		//unity will load the scene by 1. loading 0--0.9 and 2. activation 0.9 -- 1   
		AsyncOperation oper = SceneManager.LoadSceneAsync(sceneName);



		//clear the text
		progressPercent.text = " ";
		//only loading down
		//when loading small scene this is very fast
		while (!oper.isDone)
		{
		    
			
			//no value in between  
			//Debug.Log(percent);

			progressBar.value = oper.progress;
			Debug.Log(oper.progress);
			int percent = Mathf.RoundToInt( oper.progress * 100f);/// (.9f);

			progressPercent.text = percent  + "%";

			yield return null;

		}

	}

}
