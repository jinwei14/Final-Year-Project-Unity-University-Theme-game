﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    //get the nav mesh agent component
    NavMeshAgent navMeshAgent;
    //need to know the game object that we need to chase
    Transform target;

    // Use this for initialization
    void Start()
    {
        //reference of the path finder agent
        navMeshAgent = GetComponent<NavMeshAgent>();
        //give the reference of out player
        target = GameObject.FindGameObjectWithTag("Player").transform;

        StartCoroutine(UpdateRoute());
    }

    // Update is called once per frame
    void Update()
    {
        //go the player position
        //however consider the efficiency of the game
       // navMeshAgent.SetDestination(target.position);
    }

    IEnumerator UpdateRoute()
    {
        float refreshRate = 0.7f;

        while (target != null) {
            //this make sure the target is on the ground
            Vector3 destination = new Vector3(target.position.x, 0, target.position.z);

            navMeshAgent.SetDestination(destination);

            yield return new WaitForSeconds(refreshRate);
        }

    }
}
