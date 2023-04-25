using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spi;
    public GameObject platform;
    public GameObject obstacle;
    public float moveAmount;
    public bool walksLeft;
    private float leftEdge;
    private float rightEdge;
    private bool? isObstacleLeft = null;

    // Start is called before the first frame update
    void Start()
    {
        float scaleX = platform.GetComponent<Collider2D>().bounds.size.x;
        float posX = platform.transform.position.x;
        float obstaclePos = 0;

        if (obstacle != null) 
        { 
            obstaclePos = obstacle.transform.position.x;
            isObstacleLeft = obstaclePos < transform.position.x;
        }

        leftEdge = posX - (scaleX / 2) + scaleX / 20;
        rightEdge = posX + (scaleX / 2) - scaleX / 20;

        if (isObstacleLeft.HasValue)
        {
            if (isObstacleLeft.Value)
            {
                leftEdge = obstaclePos + 5;
            }
            else
            {
                rightEdge = obstaclePos - 5;
            }
        }

        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null)
        {
            return;
        }

        float pos = rb.position.x;

        if (pos < leftEdge)
        {
            walksLeft = false;
        }
        if (pos > rightEdge)
        {
            walksLeft = true;
        }

        if (walksLeft)
        {
            rb.position += new Vector2(-moveAmount, 0);
            spi.flipX = true;
        }
        else
        {
            rb.position += new Vector2(moveAmount, 0);
            spi.flipX = false;
        }
    }
}
