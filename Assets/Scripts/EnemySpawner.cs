﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    float randX;
    float randY;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range (-20f,20f);
            randY = Random.Range (-24,-50);
            whereToSpawn = new Vector2 (randX, transform.position.y);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);
            Instantiate(enemy, new Vector3(randX, randY, 0), Quaternion.AngleAxis(180, Vector3.up)); 
        }
    }
}
