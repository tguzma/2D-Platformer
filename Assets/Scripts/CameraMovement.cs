using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Rigidbody2D targetObject;
    private float cameraOffsetY = -8;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(0, targetObject.position.y - cameraOffsetY);
    }
}
