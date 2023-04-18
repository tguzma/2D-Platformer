using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform basePlatform;
    private Rigidbody2D rb;
    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float scaleX = basePlatform.GetComponent<Collider2D>().bounds.size.x;
        float posX = basePlatform.position.x;
        float posY = basePlatform.position.y;

        respawnPosition = new Vector3(posX - (scaleX / 2) + scaleX / 10, posY + 10f, 1);
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        if (character.gameObject.GetComponent<EnemyMovement>() != null ||
            character.gameObject.GetComponent<BossBehaviour>() != null ||
            character.gameObject.name.Contains("spike"))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        rb.transform.position = respawnPosition;
    }
}
