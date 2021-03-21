using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float swimSpeed;
    public float sprintSpeed;
    //Vector3 currentSpeed = new Vector3(0f, 0f, 0f);
    
    private float currentSpeed;

    //float targetSpeed;

    float acceleration = 2.5f;

    public float turnSpeed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool moved = false;

        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        } else
        {
            currentSpeed = swimSpeed;
        }

        float xMove = 0.0f;
        float yMove = 0.0f;

        if(Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            //rb.velocity = new Vector2(currentSpeed* Input.GetAxis("Horizontal"), rb.velocity.y);
            //transform.position += new Vector3(Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime, 0.0f, 0.0f);
            xMove = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            //rb.velocity = new Vector2(rb.velocity.x, Input.GetAxis("Vertical") * currentSpeed);
            //transform.position += new Vector3(0.0f, Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime, 0.0f);
            yMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
        }

        if(xMove != 0 || yMove != 0)
        {
            rb.MovePosition(new Vector2(transform.position.x + xMove, transform.position.y + yMove));
        }



    }
}
