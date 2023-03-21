using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Death : MonoBehaviour
{
    public List<GameObject> killingObjects;
    public float respawnX;
    public float respawnY;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        if(killingObjects.Contains(character.gameObject))
        {
            rb.transform.position = new Vector3(respawnX,respawnY,1);
        }
    }
}
