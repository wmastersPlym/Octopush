using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class puckGate : MonoBehaviour
{

    public UnityEvent PuckPassed = new UnityEvent();

    public bool passed;
    public Color passedColour;
    public Color notPassedColour;

    private SpriteRenderer sr;
    public bool puckHasEntered;

    // Start is called before the first frame update
    void Start()
    {
        passed = false;
        puckHasEntered = false;
        sr = GetComponent<SpriteRenderer>();
        setColour();
    }


    public void puckEntered()
    {
        puckHasEntered = true;
    }

    public void puckLeft()
    {
        if(!passed)
        {
            passed = true;
            setColour();
            PuckPassed.Invoke();

        }
    }


    void setColour()
    {
        if (passed) {
            // Set passed colour
            sr.color = passedColour;
        } else
        {
            // Set no passed colour
            sr.color = notPassedColour;
        }
    }
}
