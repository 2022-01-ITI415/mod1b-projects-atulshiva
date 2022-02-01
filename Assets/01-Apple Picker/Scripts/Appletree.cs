using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appletree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speed = 1f;
    public float LeftAndRightEdge = 20f;
    public float chanceToChangeDirection = 0.02f;
    public float secondsBetweenAppleDrop = 1f;

    void Start()
        
    {
        
    }

    void Update()
    {
        //Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing direction
        if (pos.x < -LeftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > LeftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }
    void FixedUpdate()
    {
        if ( Random.value < chanceToChangeDirection)
        {
            speed *= -1; // Change direction   
        }

    }
}
