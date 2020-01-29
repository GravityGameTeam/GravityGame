using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour //biggest class in the game, fuck
{
    public GameObject countdownObject; //what's it for? IDK
    
    //basic ground movement and forces
    public float gravityForce;
    public float movementForce;
    public float maxMovementSpeed;
    [Range(0,1)]public float groundFrictionLevel;

    private float movementDirection;
    private Rigidbody2D rb;
    
    //gravity
    private bool antigrav = false; //zones where gravity can't change
    private int gAxis; //0 or 1, X or Y, controls conditional statements that alter movement based on grav direction
    private readonly int Y = 0; //statics used for the above
    private readonly int X = 1;
    private Vector2 DOWN; //statics for grav direction, not assigned yet, just in case we change gravityForce
    private Vector2 UP;
    private Vector2 LEFT;
    private Vector2 RIGHT;

    //jump variables
    public float jumpForce;
    private bool isGrounded; //can only jump if it's true
    
    void Start()
    {
        gameObject.SetActive(false);
        rb = GetComponent<Rigidbody2D>();

        DOWN = new Vector2(0, -gravityForce); //initializes gravity statics and sets it to down
        UP = new Vector2(0, gravityForce);
        LEFT = new Vector2(-gravityForce, 0);
        RIGHT = new Vector2(gravityForce, 0);
        //Physics2D.gravity = DOWN; //note that gravity is initialized remotely from the Countdown class.

        this.transform.position = PlayerData.spawnPoint; //sends you to spawn point
        gameObject.SetActive(true);
    }

    //Gets movement
    void Update()
    {
        GetMove(); //gets all movement
        SwitchGravity(); //checks if gravity's changing and alters it
    }

    //Loads after Update, converts values from GetMove to forces
    void FixedUpdate()
    {
        //Creates a force and changes it based on the gravity axis, then applies it
        Vector2 forceToAdd = gAxis == Y ? new Vector2(movementForce * movementDirection, 0) : new Vector2(0, movementForce * movementDirection);
        rb.AddForce(forceToAdd);
        
        //Changes the ground movement speed so you can't be Sonic
        Slow();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) //if not touching ground, you can't jump
        {
            isGrounded = false;
        }
    }
    
    private void OnCollisionStay2D(Collision2D other) //handles all collisions
    {
        if (other.gameObject.CompareTag("Spike")) //kills you if you hit a spike
        {
            gameObject.SetActive(false);
            Respawn();
            gameObject.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Ground")) //lets you jump if touching ground
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) //uses triggers to check for zones
    {
        if (other.gameObject.CompareTag("Antigrav")) //if you enter antigrav, prevent grav switching
        {
            Debug.Log("Entered antigrav");
            antigrav = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Antigrav")) //if you leave antigrav, allow grav switching
        {
            Debug.Log("Exited antigrav");
            antigrav = false;
        }
    }

    //Gets user input
    private void GetMove() //gets horizontal input
    {
        movementDirection = Input.GetAxis(gAxis == Y ? "Horizontal" : "Vertical"); //only accepts movement input on axis perpendicular to gAxis, then stores it
        
        //jump functions
        if (isGrounded && AlmostEqual((gAxis == Y ? rb.velocity.y : rb.velocity.x), 0)) //to jump, must be grounded, and must have 0 velocity in direction of gAxis
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
    
    //Gets WASD input, not forces, and alters gravity
    private void SwitchGravity()
    {
        if (!antigrav) //won't work in antigrav zones
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Physics2D.gravity = UP; //uses static Vector2
                gAxis = Y; //changes gAxis
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
    }
    
    private void Jump(int xYeet, int yYeet) //jump takes x and y force parameters so you can jump in any direction with the same function.
    {
        //you multiply the jump force by the parameters. 0 means no movement in that direction, 1 means + movement, -1 means - movement. It's converted into a force and applied.
        rb.AddForce(new Vector2(jumpForce * xYeet, jumpForce * yYeet), ForceMode2D.Impulse);
    }

    private void Slow() //prevents infinite acceleration, but only on axis perpendicular to gravity so falling isn't slowed
    {
        float velocity = gAxis == Y ? rb.velocity.x : rb.velocity.y; //gets only the x or y component of the player's current velocity
        
        if (velocity > maxMovementSpeed) //then constrains the magnitude of that component
        {
            velocity = maxMovementSpeed;
        }
        else if (velocity < -maxMovementSpeed)
        {
            velocity = -maxMovementSpeed;
        }
        
        if (movementDirection == 0) //if no force is being applied by arrow keys, apply friction
        {
            velocity *= groundFrictionLevel;
        }

        rb.velocity = gAxis == Y ? new Vector2(velocity, rb.velocity.y) : new Vector2(rb.velocity.x, velocity); //puts removed component back into velocity vector.
    }
    
    private void Respawn() //called upon spike contact
    {
        //sends you back to spawn, resets all vectors to default
        rb.transform.position = PlayerData.spawnPoint;
        rb.velocity = new Vector2(0, 0);
        gAxis = Y;
        Physics2D.gravity = DOWN;
    }

    public void ResetGravity()
    {
        Physics2D.gravity = DOWN;
        gAxis = Y;
    }
    
    private bool AlmostEqual(float a, float b) //compares floats
    {
        if (Math.Abs(a - b) < 0.00001f)
        {
            return true;
        }

        return false;
    }
}