using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager;
using UnityEngine;

public class StickController : MonoBehaviour
{

    public GameObject stickNormal;
    public GameObject stickFlipped;
    public GameObject stickSideways;

    public GameObject playerBody;

    private SpriteRenderer[] stickRenderes;
    private PolygonCollider2D[] stickHitboxes;
    private float fade = 0.6f;

    


    // Start is called before the first frame update
    void Start()
    {
        if(stickNormal == null || stickFlipped == null || stickSideways == null)
        {
            Debug.LogError("Not all stick game objects are set!"); 
        } else
        {
            stickRenderes = GetComponentsInChildren<SpriteRenderer>();
            stickHitboxes = GetComponentsInChildren<PolygonCollider2D>();
            print("Stick renderers: " + stickRenderes.Length);
            setStickNormal();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
            setStickSideways();
        } else if(Input.GetMouseButton(0)) {
            setStickNormal();
        }
        else if (Input.GetMouseButton(1)) {
            setStickFlipped();
        } else
        {
            makeSticksInactive();
        }


        // Fix rotation of stick to the same as the player body

        transform.rotation = playerBody.transform.rotation;
        transform.eulerAngles += new Vector3(0, 0, 180f);

        /*// TEMPORARY //
        Vector3 mousePos;

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        GetComponent<Rigidbody2D>().MovePosition(mousePos);
        //transform.position = Vector2.Lerp(transform.position, mousePos,  3f);
        */
    }


    private void makeSticksInactive()
    {
        makeHitBoxesInAvtive();
        fadeOut();
    }

    private void setStickNormal()
    {
        stickNormal.GetComponent<SpriteRenderer>().enabled = true;
        stickNormal.GetComponent<PolygonCollider2D>().enabled = true;

        stickFlipped.GetComponent<SpriteRenderer>().enabled = false;
        stickFlipped.GetComponent<PolygonCollider2D>().enabled = false;


        stickSideways.GetComponent<SpriteRenderer>().enabled = false;
        stickSideways.GetComponent<PolygonCollider2D>().enabled = false;

        fadeIn();
    }

    private void setStickFlipped()
    {
        stickNormal.GetComponent<SpriteRenderer>().enabled = false;
        stickNormal.GetComponent<PolygonCollider2D>().enabled = false;

        stickFlipped.GetComponent<SpriteRenderer>().enabled = true;
        stickFlipped.GetComponent<PolygonCollider2D>().enabled = true;


        stickSideways.GetComponent<SpriteRenderer>().enabled = false;
        stickSideways.GetComponent<PolygonCollider2D>().enabled = false;

        fadeIn();
    }

    private void setStickSideways()
    {
        stickNormal.GetComponent<SpriteRenderer>().enabled = false;
        stickNormal.GetComponent<PolygonCollider2D>().enabled = false;

        stickFlipped.GetComponent<SpriteRenderer>().enabled = false;
        stickFlipped.GetComponent<PolygonCollider2D>().enabled = false;


        stickSideways.GetComponent<SpriteRenderer>().enabled = true;
        stickSideways.GetComponent<PolygonCollider2D>().enabled = true;

        fadeIn();
    }

    private void fadeOut()
    {
        foreach (SpriteRenderer s in stickRenderes)
        {
            Color colour = s.color;
            colour.a = fade;
            s.color = colour;
        }
    }

    private void fadeIn()
    {
        foreach(SpriteRenderer s in stickRenderes)
        {
            Color colour = s.color;
            colour.a = 1f;
            s.color = colour;
        }
    }


    private void makeHitBoxesInAvtive()
    {
        foreach (PolygonCollider2D p in stickHitboxes)
        {
            p.enabled = false;
        }
    }

}
