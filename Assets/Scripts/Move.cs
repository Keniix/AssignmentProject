using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour

{
    public Rigidbody rb;
    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;

    Vector3 characterScale;
    float characterScaleX;
    
    //body to stay upright
    float lockPos = 0;

    public float moveSpeed = 5f;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();


        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    
    
    }

    // Update is called once per frame
    void Update()

    {
        // Flip the Character:
        if (Input.GetAxis("Horizontal") > 0) 
        {
            characterScale.x = -characterScaleX;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = characterScaleX;
        }
            transform.localScale = characterScale;

        Jump();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;
        //body to stay upright
        transform.rotation = Quaternion.Euler (lockPos, lockPos, lockPos);

        isJumpPressed = Input.GetButtonDown("Jump");

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

        if(transform.position.y > 13.5f)
        {
            SceneManager.LoadScene(0);
        }
    }

    //for smoother jump
    void FixedUpdate()
    {
        if (isJumpPressed)
        {
            // the character is going to move upwards in 50 units per second
            rb.velocity = new Vector3(0, 50, 0);
            isMoving = true;
            Debug.Log("jump");
        }

        if (isMoving)
        {
            // when the character has moved for 50 seconds, report its position
            time = time + Time.fixedDeltaTime;
            if (time > 50.0f)
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
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 6f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Collider")
        {
            SceneManager.LoadScene(0);
        }
    }


}  