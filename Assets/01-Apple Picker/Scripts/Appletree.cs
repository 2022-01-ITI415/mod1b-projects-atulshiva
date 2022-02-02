using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appletree : MonoBehaviour
{
    public static float bottomY = -20f;
    public GameObject applePrefab;
    public float speed = 10f;
    public float LeftAndRightEdge = 20f;
    public float chanceToChangeDirection = 0.02f;
    public float secondsBetweenAppleDrop = 1f;

    void Start()
        
    {
        Invoke("DropApple", 2f);
    }
        void DropApple()
    { // b
        GameObject apple = Instantiate<GameObject>(applePrefab
        ); // c
        apple.transform.position =
        transform.position; // d
        Invoke("DropApple", secondsBetweenAppleDrop
        ); // e
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
