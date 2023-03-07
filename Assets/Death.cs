using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Rigidbody2D mainCharRb;
    public Rigidbody2D enemyCharRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        if(character.attachedRigidbody == enemyCharRb)
        {
            mainCharRb.transform.position = new Vector3(0,-3,1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
