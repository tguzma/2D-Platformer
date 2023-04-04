using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer spi;
    public float jumpAmount;
    public float moveAmount;
    public Sprite jumpSprite;
    public Sprite stillSprite;
    public ProjectileBehaviour projectile;
    public Transform projectileOffsetLeft;
    public Transform projectileOffsetRight;

    private const float gravityScale = 10;
    private const float fallingGravityScale = 25;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spi = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocityY = rb.velocity.y;

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
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Instantiate(projectile, projectileOffsetLeft.position, transform.rotation).IsHeadingRight = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Instantiate(projectile, projectileOffsetRight.position, transform.rotation).IsHeadingRight = true;
        }


        if (velocityY >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (velocityY < 0)
        {
            spi.sprite = stillSprite;
            rb.gravityScale = fallingGravityScale;
        }
    }
}