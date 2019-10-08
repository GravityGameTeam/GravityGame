using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //basic ground movement
    public float movementForce;
    public float maxMovementSpeed;
    [Range(0,1)]public float groundFrictionLevel;

    private float movementDirection;
    private Vector2 velocity;
    private Rigidbody2D rb;
    
    //gravity
    private int gAxis = 0;
    private static int Y = 0;
    private static int X = 1;
    private static Vector2 DOWN = new Vector2(0, -30);
    private static Vector2 UP = new Vector2(0, 30);
    private static Vector2 LEFT = new Vector2(-30, 0);
    private static Vector2 RIGHT = new Vector2(30, 0);
    
    //jump variables
    public float jumpForce;

    private bool canJump = false;
    private bool isGrounded = false;
    
    //Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Gets movement
    void Update()
    {
        GetMove();
    }

    //Creates a force and changes it based on the gravity axis, then applies it
    //Changes the ground movement speed so you can't be Sonic
    void FixedUpdate()
    {
        Vector2 forceToAdd = new Vector2();
        
        if (gAxis == Y)
        {
            forceToAdd = new Vector2(movementForce * movementDirection, 0);
        }
        else if (gAxis == X)
        {
            forceToAdd =  new Vector2(0, movementForce * movementDirection);
        }
        
        rb.AddForce(forceToAdd);

        if (gAxis == Y)
        {
            SlowX();
        }
        else if (gAxis == X)
        {
            SlowY();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Entered ground");
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Exited ground");
            isGrounded = false;
        }
    }

    //Gets user input.
    private void GetMove()
    {
        if (gAxis == Y)
        {
            movementDirection = Input.GetAxis("Horizontal");
        } 
        else if (gAxis == X)
        {
            movementDirection = Input.GetAxis("Vertical");
        }

        Debug.Log("Getting jump input");
        GetJump();
    }

    private void GetJump()
    {
        Debug.Log("Grounded: " + isGrounded + " and velocity: " + rb.velocity.y);
        
        if (isGrounded && (gAxis == Y && rb.velocity.y == 0 || gAxis == X && rb.velocity.x == 0))
        {
            Debug.Log("Can jump");
            canJump = true;
        }
        else
        {
            Debug.Log("Can't jump");
        }

        if (Physics2D.gravity == DOWN && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump(0, 1);
        }
        if (Physics2D.gravity == UP && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Jump(0, -1);
        }
        if (Physics2D.gravity == LEFT && Input.GetKeyDown(KeyCode.RightArrow))
        {
            Jump(1, 0);
        }
        if (Physics2D.gravity == RIGHT && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Jump(-1, 0);
        }
    }

    private void Jump(int xYeet, int yYeet)
    {
        if (canJump)
        {
            Debug.Log("Yeeting");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            Vector2 jumpForceToAdd = new Vector2(jumpForce * xYeet, jumpForce * yYeet);
            rb.AddForce(jumpForceToAdd, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    //constrains movement speed on x-axis if gravity's on the y
    private void SlowX()
    {
        if (rb.velocity.x > maxMovementSpeed)
        {
            rb.velocity = new Vector2(maxMovementSpeed, rb.velocity.y);
        }
        else if (rb.velocity.x < -maxMovementSpeed)
        {
            rb.velocity = new Vector2(-maxMovementSpeed, rb.velocity.y);
        }

        if (movementDirection == 0)
        {
            velocity = rb.velocity;
            velocity.x *= groundFrictionLevel;
            rb.velocity = velocity;
        }
    }
    
    //constrains movement speed on y-axis if gravity's on x
    private void SlowY()
    {
        if (rb.velocity.y > maxMovementSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, maxMovementSpeed);
        }
        else if (rb.velocity.y < -maxMovementSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, -maxMovementSpeed);
        }

        if (movementDirection == 0)
        {
            velocity = rb.velocity;
            velocity.y *= groundFrictionLevel;
            rb.velocity = velocity;
        }
    }

    //called by SwitchGravity to alter the gravity axis
    public void ChangeAxis(int newAxis)
    {
        gAxis = newAxis;
    }
}