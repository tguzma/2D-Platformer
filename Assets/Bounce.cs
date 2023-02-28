using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Bounce : MonoBehaviour
{
    public float bounceAmount;
    public Sprite jumpSprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D character)
    {
        character.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceAmount, ForceMode2D.Impulse);
        character.GetComponent<SpriteRenderer>().sprite = jumpSprite;
    }
}
