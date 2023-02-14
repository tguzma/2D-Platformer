using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) transform.position += new Vector3(-0.1f, 0);
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) transform.position += new Vector3(0.1f, 0);
    }
}
