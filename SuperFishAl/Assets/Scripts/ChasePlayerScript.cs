﻿using UnityEngine;
using System.Collections;

public class ChasePlayerScript : MonoBehaviour
{
    private int MoveSpeed = 4;
    private int MaxDist = 10;
    private int MinDist = 5;
    private Transform player;

	// Use this for initialization
	void Start () {
	    player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
    private void Update()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
    }
}