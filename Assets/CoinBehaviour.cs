using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    private bool collected = false;

    void OnTriggerEnter2D(Collider2D character)
    {
        if (!collected && character.gameObject.GetComponent<CharacterBehaviour>() != null)
        {
            ScoreHandler.Collected();
            collected = true;
            Destroy(transform.gameObject);

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
            }
        }
    }
}
