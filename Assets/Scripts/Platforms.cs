﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public float moveSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);

        //check if the platform went past  on y the axis
        if(transform.position.y > 14.7f)
        {
            //teleport the platform to - on the axis
            transform.position = new Vector3(transform.position.x, -45f,0);
        }
    }
}