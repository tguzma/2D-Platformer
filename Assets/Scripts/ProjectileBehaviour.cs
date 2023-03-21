using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ProjectileBehaviour : MonoBehaviour
{
    public float ProjectileSpeed = 50f;
    public bool IsHeadingRight;

    // Start is called before the first frame update
    void Update()
    {
        transform.position += IsHeadingRight ? 
            transform.right * Time.deltaTime * ProjectileSpeed : 
            -transform.right * Time.deltaTime * ProjectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>() != null)
        {
            Debug.Log("hit!");
            Destroy(collision.gameObject, 0.05f);
        }
        Destroy(gameObject);
    }
}
