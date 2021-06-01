using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float swimSpeed;
    public float sprintSpeed;
    public float friction;

    public bool controlsEnabled;

    //Vector3 currentSpeed = new Vector3(0f, 0f, 0f);
    
    private float currentSpeed;

    //float targetSpeed;

    //float acceleration = 2.5f;

    public float turnSpeed;

    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(controlsEnabled)
        {
            calculateMovement();
        }


    }

    private void calculateMovement()
    {
        // Sprinting
        if (Input.GetKey(KeyCode.LeftShift))  // If shift being held set current speed to sprint speed, else set it to normal speed
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = swimSpeed;
        }



        float xMove = 0.0f;
        float yMove = 0.0f;

        if (Input.GetAxisRaw("Horizontal") > 0.1f || Input.GetAxisRaw("Horizontal") < -0.1f) // Detects if A/D being held
        {
            xMove = turnSpeed * Input.GetAxisRaw("Horizontal") * -1f; // Calculates variable for turning using direction and turning speed

        }

        if (Input.GetAxisRaw("Vertical") > 0.1f || Input.GetAxisRaw("Vertical") < -0.1f)
        {
            yMove = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime; // Calculates variable for moving forwards and backwards
                                                                               // using the current speed
        }

        if (yMove != 0) // if trying to move
        {
            rb.velocity = (transform.up * yMove); // set velocity using the movement variable
            animator.SetBool("isSwimming", true);
        }
        else
        {
            rb.velocity = rb.velocity * friction; // else quickly reduce velocity down to 0
            animator.SetBool("isSwimming", false);
        }

        if (xMove != 0.0f)
        {
            rb.angularVelocity = xMove; // sets turning velocity using the turning variable
            animator.SetBool("isSwimming", true);
        }
        else
        {
            rb.angularVelocity = rb.angularVelocity * friction; // else quickly reduce turning velocity down to 0
        }
    }
}
