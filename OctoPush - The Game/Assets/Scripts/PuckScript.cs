using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if ((collision.gameObject.GetComponent<puckGate>() as puckGate) != null) // Checks if the trigger the puck has entered is a puck gate
        {
            print("Entered puck gate");

            collision.gameObject.GetComponent<puckGate>().puckEntered();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if ((collision.gameObject.GetComponent<puckGate>() as puckGate) != null) // Checks if the trigger the puck has entered is a puck gate
        {
            //print("Entered puck gate");

            collision.gameObject.GetComponent<puckGate>().puckLeft();
        }
    }

}
