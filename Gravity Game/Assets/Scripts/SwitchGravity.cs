using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class SwitchGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool top;

    private static int Y = 0;
    private static int X = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Physics2D.gravity = new Vector2(0f, 30f);
            GetComponent<PlayerMovement>().ChangeAxis(Y);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Physics2D.gravity = new Vector2(0f, -30f);
            GetComponent<PlayerMovement>().ChangeAxis(Y);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Physics2D.gravity = new Vector2(-30f, 0);
            GetComponent<PlayerMovement>().ChangeAxis(X);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Physics2D.gravity = new Vector2(30f, 0f);
            GetComponent<PlayerMovement>().ChangeAxis(X);
        }
    }

    /*
    private void Rotation()
        {
        if (!top)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }
        else
        {
            transform.eulerAngles = Vector3.zero;
        }

        top = !top;
    }
    */
}