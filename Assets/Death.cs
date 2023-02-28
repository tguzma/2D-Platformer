using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D character)
    {
        character.transform.position = new Vector3(0,-3,1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
