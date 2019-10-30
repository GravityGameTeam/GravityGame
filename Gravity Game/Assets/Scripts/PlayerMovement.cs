using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class PlayerMovement : MonoBehaviour
{
    //basic ground movement
    public float gravityForce;
    public float movementForce;
    public float maxMovementSpeed;
    [Range(0,1)]public float groundFrictionLevel;

    private float movementDirection;
    private Rigidbody2D rb;
    
    //gravity
    private int gAxis;
    private readonly int Y = 0;
    private readonly int X = 1;
    private Vector2 DOWN;
    private Vector2 UP;
    private Vector2 LEFT;
    private Vector2 RIGHT;
    
    //jump variables
    public float jumpForce;

    private bool canJump;
    private bool isGrounded;
    
    
    
    //Start
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DOWN = new Vector2(0, -gravityForce);
        UP = new Vector2(0, gravityForce);
        LEFT = new Vector2(-gravityForce, 0);
        RIGHT = new Vector2(gravityForce, 0);
        Physics2D.gravity = DOWN;
    }

    //Gets movement
    void Update()
    {
        GetMove();

        SwitchGravity();
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

        //SlowMovement();

        if (gAxis == Y)
        {
            SlowX();
        }
        else
        {
            SlowY();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            gameObject.SetActive(false);
            Respawn();
            gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    //Gets user input:
    //Detects movement based on 
    private void GetMove()
    {
        movementDirection = Input.GetAxis(gAxis == Y ? "Horizontal" : "Vertical");
        
        if (isGrounded && (gAxis == Y && AlmostEqual(rb.velocity.y, 0) || gAxis == X && AlmostEqual(rb.velocity.x, 0)))
        {
            canJump = true;
        }

        if (canJump)
        {
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
    }

    private void SwitchGravity()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = UP;
            gAxis = Y;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = DOWN;
            gAxis = Y;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = LEFT;
            gAxis = X;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = RIGHT;
            gAxis = X;
        }
    }

    private void Jump(int xYeet, int yYeet)
    {
        //rb.velocity = new Vector2(rb.velocity.x, 0);
        Vector2 jumpForceToAdd = new Vector2(jumpForce * xYeet, jumpForce * yYeet);
        rb.AddForce(jumpForceToAdd, ForceMode2D.Impulse);
        canJump = false;
    }

    //constrains movement speed on x-axis if gravity's on the y
    private void Slow()
    {
        Vector2 velocity = rb.velocity;
        
        if ((gAxis == Y ? velocity.x : velocity.y) > maxMovementSpeed)
        {
            velocity.x = maxMovementSpeed;
        }
        else if ((gAxis == Y ? rb.velocity.x: rb.velocity.y) < -maxMovementSpeed)
        {
            rb.velocity = new Vector2(-maxMovementSpeed, rb.velocity.y);
        }

        if (movementDirection == 0)
        {
            velocity.x *= groundFrictionLevel;
            rb.velocity = velocity;
        }
    }
    
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
            Vector2 velocity = rb.velocity;
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
            Vector2 velocity = rb.velocity;
            velocity.y *= groundFrictionLevel;
            rb.velocity = velocity;
        }
    }
    
    /*
    private void SlowMovement()
    {
        float currentVelocity = gAxis == Y ? rb.velocity.x : rb.velocity.y;
        Debug.Log("Axis: " + gAxis + ", current ground velocity: " + currentVelocity);
        
        if (currentVelocity > maxMovementSpeed)
        {
            Debug.Log("Ground velocity > 7");
            rb.velocity = gAxis == Y ? new Vector2(maxMovementSpeed, rb.velocity.y) : new Vector2(rb.velocity.x, maxMovementSpeed);
            Debug.Log("New velocity: " + rb.velocity);
        }
        else if (currentVelocity < -maxMovementSpeed)
        {
            Debug.Log("Ground velocity < -7");
            rb.velocity = gAxis == Y ? new Vector2(-maxMovementSpeed, rb.velocity.y) : new Vector2(rb.velocity.x, -maxMovementSpeed);
            Debug.Log("New velocity: " + rb.velocity);
        }

        if (AlmostEqual(movementDirection, 0))
        {
            velocity = rb.velocity;
            velocity = gAxis == Y ? new Vector2(velocity.x * groundFrictionLevel, velocity.y) : new Vector2(velocity.y, velocity.y * groundFrictionLevel);
            rb.velocity = velocity;
        }
    }
    */

    private void Respawn()
    {
        rb.transform.position = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
        gAxis = Y;
        Physics2D.gravity = DOWN;
    }
    
    private bool AlmostEqual(float a, float b)
    {
        if (Math.Abs(a - b) < 0.00001f)
        {
            return true;
        }

        return false;
    }

    /*IEnumerator StartDelay()
    {
        var countdown = new Countdown();
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        yield return 0;
        countdown.Start();
        Time.timeScale = 1;


    }*/
}