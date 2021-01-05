using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour

{
    public Rigidbody rb;
    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;
    
    //body to stay upright
    float lockPos = 0;

    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        //body to stay upright
        transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);

        isJumpPressed = Input.GetButtonDown("Jump");
    }

    //for smoother jump
    void FixedUpdate()
    {
        if (isJumpPressed)
        {
            // the cube is going to move upwards in 50 units per second
            rb.velocity = new Vector3(0, 400, 0);
            isMoving = true;
            Debug.Log("jump");
        }

        if (isMoving)
        {
            // when the cube has moved for 50 seconds, report its position
            time = time + Time.fixedDeltaTime;
            if (time > 400.0f)
            {
                Debug.Log(gameObject.transform.position.y + " : " + time);
                time = 0.0f;
            }
        }
    }


    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
    
        }
    }
}






    