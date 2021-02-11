using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundloop : MonoBehaviour
{

    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed, Space.World);

        //check if the platform went past  on y the axis
        if(transform.position.y > 32.5f)
        {
            //teleport the platform to - on the axis
            transform.position = new Vector3(transform.position.x, -32.5f,0);
        }


    }
}

