using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TargetScript : MonoBehaviour
{

    public UnityEvent ChangeInPuckCount;

    public int numberOfPucks;

    private void Start()
    {
        numberOfPucks = 0;
    }



    public void addPuck()
    {
        numberOfPucks++;
        ChangeInPuckCount.Invoke();

        // Plays audio
        GetComponent<AudioSource>().Play();
    }

    public void removePuck()
    {

        numberOfPucks--;
        ChangeInPuckCount.Invoke();
    }
}
