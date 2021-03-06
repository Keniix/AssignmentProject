﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour

{
    public Rigidbody rb;
    private float time = 0.0f;
    private bool isMoving = false;
    private bool isJumpPressed = false;
    public Animator anim;
    
    [SerializeField]
    private bool _isSpeedBoostActive = false;



    Vector3 characterScale;
    float characterScaleX;
    
    //body to stay upright
    float lockPos = 0;

    public float moveSpeed = 5f;
    [SerializeField]
    public float _speedMultiplier = 2f;
    private Score _score;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _score = GameObject.Find("Canvas").GetComponent<Score>();

        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
        
        //for animation 
        anim = GetComponent <Animator>();
    
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


        if(Input.GetKeyDown("space"))
        {
            anim.Play("player jump");
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
        //make character jump
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 8f), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        //character dies when touching somethign with the tag collider, call game over scene
        if(other.tag == "Collider")
        {
            if(_score != null)
            {
                _score.persistHighScore();
                SceneManager.LoadScene(3);
            }
            
        }
    }

    public void SpeedBoostActive()
    {
        _isSpeedBoostActive = true;
        moveSpeed *= _speedMultiplier; 
        StartCoroutine(SpeedBoostPowerDownRoutine());
    }

    IEnumerator SpeedBoostPowerDownRoutine()
    {
        yield return new WaitForSeconds(5f);
        moveSpeed /= _speedMultiplier;
        _isSpeedBoostActive = false;
    }


}  