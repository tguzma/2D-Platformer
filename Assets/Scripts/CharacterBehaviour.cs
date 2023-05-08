using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterBehaviour : MonoBehaviour
{
    public float jumpAmount;
    public float moveAmount;
    public Sprite jumpSprite;
    public Sprite stillSprite;
    public ProjectileBehaviour projectile;
    public Transform projectileOffsetLeft;
    public Transform projectileOffsetRight;

    private Rigidbody2D rb;
    private SpriteRenderer spi;
    private float projectileCoolDown = 1.0f;
    private const float gravityScale = 10;
    private const float fallingGravityScale = 25;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
        moveAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {        
        HandleMovement();
        HandleShooting();
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.position += new Vector2(-moveAmount, 0);
            spi.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.position += new Vector2(moveAmount, 0);
            spi.flipX = false;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && rb.IsTouchingLayers())
        {
            spi.sprite = jumpSprite;
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (rb.position.y < -30)
        {
            transform.gameObject.GetComponent<Death>().Respawn();
        }

        float velocityY = rb.velocity.y;

        if (velocityY >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (velocityY < 0)
        {
            spi.sprite = stillSprite;
            rb.gravityScale = fallingGravityScale;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    private void HandleShooting()
    {
        projectileCoolDown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && projectileCoolDown < 0)
        {
            projectileCoolDown = 1.0f;
            Instantiate(projectile, projectileOffsetLeft.position, transform.rotation).IsHeadingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && projectileCoolDown < 0)
        {
            projectileCoolDown = 1.0f;
            Instantiate(projectile, projectileOffsetRight.position, transform.rotation).IsHeadingRight = true;
        }
    }
}
