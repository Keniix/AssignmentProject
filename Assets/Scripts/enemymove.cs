using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public bool MoveRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else 
        {
            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
        }

        //check if the player went past 23.1f on x the axis
        if(transform.position.x > 23.1f)
        {
            //teleport the player to -23.1f on the axis
            transform.position = new Vector3(-23.1f,transform.position.y,0);
        }

        //check if player went past -23.1f on the x axis
        else if (transform.position.x < -23.1f)
        {
            //teleport the player to 23.1f on the x axis
            transform.position = new Vector3(23.1f,transform.position.y,0);
        } 
    }
}
