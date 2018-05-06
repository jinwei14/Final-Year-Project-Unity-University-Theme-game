using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Producer : MonoBehaviour
{

//this array list will store all the point that can produce the enemy 
	private  List<Vector3> producePoint;
 
	private int produceIndex = 0;
	
	//drag enemy object into this
    public Enemy enemyInstance;
    //arry that hold the round
    public Round[] arrRound;

	int enemyRemaindingToProduce;
    int enemyRemaining;
    float nextRoundTime;
    Round roundNow;
    public int roundNo = 0;

	public event System.Action newWave;
//	public event System.Action winning;
	void Start ()
	{

		producePoint = new  List<Vector3>();

		NextRound ();

		//adding up the point that produce the enemy 
		//this point is the front of the Harold Cohen Library
		producePoint.Add(new Vector3(2,0,8));

		//this point is at the front of the guild 
		producePoint.Add(new Vector3(4,0,-15));

		//this point is at the front of the Metropolitan Cathedral
		producePoint.Add(new Vector3 (-13,0,-15));	

		//this will adding the front location of the Abercromby Square Park
		producePoint.Add(new Vector3(20,0 , -20));
	}

	void Update ()
	{

		if (enemyRemaindingToProduce > 0 && Time.time > nextRoundTime) 
		{
			enemyRemaindingToProduce--;
			nextRoundTime = Time.time + roundNow.timebetweenSpawnens;


			Enemy spawnedEnemy = Instantiate (enemyInstance,producePoint[produceIndex], Quaternion.identity) as Enemy;
			//once the enemy dead it will launch this method OnEnemyDeath
			spawnedEnemy.Dying += OnEnemyDeath;
		}
	}

	void OnEnemyDeath()
	{

		enemyRemaining--;

		//detect if we need to go to the next round
		if (enemyRemaining == 0 && roundNo  < arrRound.Length)
		{
			NextRound();
		}
		else if (enemyRemaining == 0 && roundNo  >= arrRound.Length)
		{
			//there is no next round, you win!
			Debug.Log("win!!");
			//here can be replaced by system event
			SceneManager.LoadScene("Win");
		}
	}

	//start the next round of the enemy
    void NextRound()
	{
	   
		//each round will produce the random numebr between 0 to 3 (prodeuce point in the array)
		produceIndex = Random.Range(0, 3);
		roundNo++;
		if (roundNo - 1 < arrRound.Length)
		{
		//it is time to notify the Ingame UI script
			newWave();
			roundNow = arrRound[roundNo - 1];
			enemyRemaindingToProduce = roundNow.enemyCount;
			enemyRemaining = enemyRemaindingToProduce;
		}



	}

	[System.Serializable]
	public class Round
	{
		public int enemyCount;
		public float timebetweenSpawnens;

	}
}







