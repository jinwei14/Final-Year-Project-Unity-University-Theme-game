using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    public Text overText;
    //image object 
	public GameObject fadeImageObj;
	//public Image fadeImage;
	public GameObject gameOverText;

	//the rectangle of the banner 
	public GameObject  waveBanner;
	public Text waveTitle;
	public Text enemyNumber;

	//the reference to the producer/ spowner 
	Producer producer;

	public static bool gamePause = false;

	GameObject player;
	public GameObject settingUI;



	// Use this for initialization
	void Start()
	{
		FindObjectOfType<Player>().Dying += OnGameOver;
		player = GameObject.FindGameObjectWithTag("Player");
	}


	void Awake()
	{
	  producer = FindObjectOfType<Producer>();
	  producer.newWave += newWave;


	}

	void Update()
	{
		//if the user click the ESC button the game will be paused
		if (Input.GetKeyDown(KeyCode.Escape))
		{
		   OnPauseGame();
		}
	}

	//runs when the new wave start
	void newWave()
	{
		waveBanner.SetActive(true);
		waveTitle.text = "Round: " + producer.roundNo;
		enemyNumber.text = "Enemys: "+ producer.arrRound[producer.roundNo-1].enemyCount;

		StartCoroutine(LateCall());
	}

	IEnumerator LateCall()
     {
 
         yield return new WaitForSeconds(3);
 
		waveBanner.SetActive(false);
         //Do Function here...
     }
	
	// Update is called once per fram

	void OnGameOver()
	{
	//  RIP --jinwei zhang  
		fadeImageObj.SetActive(true);
		StartCoroutine(Fade(Color.clear, Color.black));
		gameOverText.SetActive(true);

	}

	IEnumerator Fade(Color start, Color end)
	{

		Image fadeImage = fadeImageObj.GetComponent<Image>();
		float speed = 0.5f;
		float percent = 0;
		while (percent < 1)
		{
			percent +=	Time.deltaTime * speed;
			fadeImage.color = Color.Lerp(start, end, percent);

			yield return null;

		}

	}



	//this will control the pause the game UI
	public void OnPauseGame()
	{   //if the game is not posed
		if (!gamePause)
		{

		//make the player disable
		player.SetActive(false);
		  settingUI.SetActive(true);
		  //slow motion of the game or you can set to 0 to pause
		  Time.timeScale = 0f;

		  gamePause = true;
		}
      

	}

	//method called when close the pause game
	public void OnResumeGame()
	{
		//make the player disable
		player.SetActive(true);

		//set the setting UI disable
		settingUI.SetActive(false);

		//recover the time
		Time.timeScale = 1f;
		gamePause = false;
	}

	//mute all the audio or revover back
	public void MuteMusic()
	{
		GameObject backgroundMusic = GameObject.FindGameObjectWithTag("MainCamera");
		AudioSource BGM = backgroundMusic.GetComponent<AudioSource>();
		BGM.mute = !BGM.mute;
	}

	public void LoadFAQ()
	{

		Application.OpenURL("https://github.com/jinwei14/Final-Year-Project-Unity-University-Theme-game");
	}







}
