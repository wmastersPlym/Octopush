using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandToMouse : MonoBehaviour
{
    Rigidbody2D rb;

    float force = 100.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print(targetPos);
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        Vector2 dir = targetPos - pos;
        //transform.position = Vector2.MoveTowards(pos, targetPos, force * Time.deltaTime);
        
        //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 180;
        //print(angle);


        rb.velocity = new Vector2(0f, 0f);

        //float xcomponent = Mathf.Cos(angle * Mathf.PI / 180) * force;
        //float ycomponent = Mathf.Sin(angle * Mathf.PI / 180) * force;

        rb.AddForce(dir * force);
    }
}
