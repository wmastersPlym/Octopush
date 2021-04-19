using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private Vector3 mousePos;
    public float moveSpeed = 3.0f;

    

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
        GetComponent<Rigidbody2D>().MovePosition(mousePos);
        
        
    }
}
