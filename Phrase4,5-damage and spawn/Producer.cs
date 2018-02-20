using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{

    //drag enemy object into this
    public Enemy enemyInstance;
    //arry that hold the round
    public Round[] arrRound;

    int enemyToProduce;
    int enemyRemaining;
    float nextRoundTime;
    Round roundNow;
    int roundNo;

    private void Start()
    {
        NextRound();
    }
    private void Update()
    {
        if (enemyToProduce > 0 && Time.time > nextRoundTime)
        {
            enemyToProduce--;
            nextRoundTime = Time.time + roundNow.timeBetweenSpawns;

            Enemy newEnemy = Instantiate(enemyInstance, Vector3.zero, Quaternion.identity) as Enemy;

            //each time we initiate a enemy we will add the event
            newEnemy.Dying += whenEnemyDead;
        }
    }

    //when ever enemy dead this function will be triggered.
    void whenEnemyDead()
    {
        print("one enemy dead");
        enemyRemaining--;
        //all the enemy in this round dead and it is not the end of the round array
        if (enemyRemaining == 0 && roundNo - 1 < arrRound.Length)
        {
            NextRound();
        }


    }

    //start the next round of the enemy
    void NextRound()
    {
        //first it goes from 0 to 1;
        roundNo++;
        if (roundNo - 1 < arrRound.Length)
        {
            roundNow = arrRound[roundNo - 1];

            enemyToProduce = roundNow.enemyCount;
            enemyRemaining = roundNow.enemyCount;
        }



    }

    //can ensure the attribute pop up in the inspector
    [System.Serializable]
    public class Round
    {
        //number of the enemy
        public int enemyCount;
        //time between each round
        public float timeBetweenSpawns;

    }
}
