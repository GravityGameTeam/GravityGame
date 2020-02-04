using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform[] points;
    private Vector2 newPosition;
    private bool readyToMove = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        newPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ChangePosition();
    }

    private void ChangePosition()
    {
        foreach (Transform point in points)
        {
            //
        }
    }
}
