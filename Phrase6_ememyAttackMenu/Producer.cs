using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{

	
	//drag enemy object into this
    public Enemy enemyInstance;
    //arry that hold the round
    public Round[] arrRound;

	int enemyRemaindingToProduce;
    int enemyRemaining;
    float nextRoundTime;
    Round roundNow;
    int roundNo = 0;

	void Start ()
	{
		NextRound ();
	}

	void Update ()
	{

		if (enemyRemaindingToProduce > 0 && Time.time > nextRoundTime) 
		{
			enemyRemaindingToProduce--;
			nextRoundTime = Time.time + roundNow.timebetweenSpawnens;

			Enemy spawnedEnemy = Instantiate (enemyInstance, Vector3.zero, Quaternion.identity) as Enemy;
			spawnedEnemy.Dying += OnEnemyDeath;
		}
	}

	void OnEnemyDeath ()
	{

		enemyRemaining--;

		//detect if we need to go to the next round
		if (enemyRemaining == 0 && roundNo - 1 < arrRound.Length) 
		{
			NextRound ();
		}
	}

	//start the next round of the enemy
    void NextRound()
    {
		roundNo++;
		if (roundNo - 1 < arrRound.Length) 
		{
			roundNow = arrRound [roundNo - 1];
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
