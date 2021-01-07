using System.Collections;
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

        //check if the player went past 14.7f on y the axis
        if(transform.position.y > 17f)
        {
            //teleport the player to -14.7f on the axis
            transform.position = new Vector3(transform.position.x, -17f,0);
        }
    }
}
