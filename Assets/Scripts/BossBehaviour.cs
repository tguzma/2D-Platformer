using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject character;
    public GameObject nextLevelObject;
    public Transform healthBar;
    public ProjectileBehaviour projectile;
    public List<Transform> projectileOffsetsLeft;
    public List<Transform> projectileOffsetsRight;
    public float healthPoints = 100.0f;
    private const float baseCoolDown = 1.0f;
    private const float lowHealthCoolDown = 0.75f;
    private float projectileCoolDown = baseCoolDown;
    private bool isFacingLeft = true;

    // Update is called once per frame
    void Update()
    {
        projectileCoolDown -= Time.deltaTime;

        if (projectileCoolDown < 0 && isFacingLeft)
        {
            projectileCoolDown = healthPoints <= 30 ? lowHealthCoolDown : baseCoolDown;
            Instantiate(projectile, projectileOffsetsLeft[Random.Range(0, 3)].position, transform.rotation).IsHeadingRight = false;
        }
        if (projectileCoolDown < 0 && !isFacingLeft)
        {
            projectileCoolDown = healthPoints <= 30 ? lowHealthCoolDown : baseCoolDown;
            Instantiate(projectile, projectileOffsetsRight[Random.Range(0, 3)].position, transform.rotation).IsHeadingRight = true;
        }
    }

    public void SpawnNextLevelObject()
    {
        Instantiate(nextLevelObject, projectileOffsetsLeft[1].position, transform.rotation);
    }

    public void ResetHealth()
    {
        healthPoints = 100;
        healthBar.localScale = new Vector2(0.99f, healthBar.localScale.y);
    }
}
