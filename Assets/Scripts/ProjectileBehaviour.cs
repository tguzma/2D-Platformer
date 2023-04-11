using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ProjectileBehaviour : MonoBehaviour
{
    public float ProjectileSpeed = 25f;
    public bool IsHeadingRight;

    private float CreationTime;
    private Transform projectile;

    void Start()
    {
        CreationTime = Time.timeSinceLevelLoad;
        projectile = GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Update()
    {
        projectile.position += IsHeadingRight ?
            projectile.right * Time.deltaTime * ProjectileSpeed : 
            -projectile.right * Time.deltaTime * ProjectileSpeed;

        if (Time.timeSinceLevelLoad - CreationTime > 2.0f)
        {
            Destroy(projectile.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {
            Destroy(collision.gameObject, 0.05f);
        }
        if (collision.gameObject.GetComponent<BossBehaviour>() != null)
        {
            var boss = collision.gameObject.GetComponent<BossBehaviour>();

            if (boss.healthPoints > 10)
            {
                boss.healthPoints -= 10;
                boss.healthBar.localScale = new Vector2(boss.healthBar.localScale.x - 0.1f, boss.healthBar.localScale.y);
            }
            else
            {
                boss.SpawnNextLevelObject();
                Destroy(collision.gameObject, 0.05f);
            }
        }

        if (collision.gameObject.GetComponent<Death>() != null)
        {
            var death = collision.gameObject.GetComponent<Death>();
            GameObject.Find("DreadBoss").GetComponent<BossBehaviour>().ResetHealth();

            death.Respawn();
        }

        Destroy(gameObject);
    }
}
