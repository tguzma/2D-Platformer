using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D targetObject;
    public float cameraOffsetY;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(targetObject.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, targetObject.position.y + cameraOffsetY);
    }
}
