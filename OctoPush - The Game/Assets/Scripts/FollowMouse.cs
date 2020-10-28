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
        if (Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
            GetComponent<Rigidbody2D>().MovePosition(mousePos);
        }
        if (Input.GetMouseButton(1))
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 1f));
        }

    }
}
