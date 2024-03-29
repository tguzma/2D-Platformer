using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public Transform basePlatform;
    private Rigidbody2D rb;
    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (basePlatform == null) Debug.Log(transform.name);
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
        ScoreHandler.Died();
        
        if (ScoreHandler.IsArcade())
        {
            ScoreHandler.SetCollectedToZero();
            SceneManager.LoadScene(1, LoadSceneMode.Single);
        }
        else
        {
            rb.transform.position = respawnPosition;
        }
    }
}
