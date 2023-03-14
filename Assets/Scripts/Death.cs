using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Rigidbody2D mainCharRb;
    public List<Rigidbody2D> enemyCharRb;
    public float respawnX;
    public float respawnY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        if(character.attachedRigidbody == enemyCharRb.Any())
        {
            mainCharRb.transform.position = new Vector3(respawnX,respawnY,1);
        }
    }
}
