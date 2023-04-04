using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public GameObject character;
    public GameObject nextLevelObject;
    public Transform healthBar;
    public float healthPoints = 100.0f;
    private Rigidbody2D rb;
    private SpriteRenderer spi;
    public ProjectileBehaviour projectile;
    public List<Transform> projectileOffsetsLeft;
    public List<Transform> projectileOffsetsRight;
    private const float baseCoolDown = 1.0f;
    private const float lowHealthCoolDown = 0.5f;
    private float projectileCoolDown = baseCoolDown;
    private bool isFacingLeft = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
    }

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
        Instantiate(nextLevelObject,rb.transform);
    }
}
