using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingScript : MonoBehaviour
{

    public float maxOxygen = 10f;

    public float oxyDrain;


    public Slider slider;

    private void Start()
    {
        slider.maxValue = maxOxygen;
        slider.value = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            slider.value += oxyDrain * Time.deltaTime;
        }
        else
        {
            slider.value -= oxyDrain * Time.deltaTime;
        }
    }

    public void checkIfDowned()
    {
        if(slider.value <= 0f)
        {
            print("Drowned");
        }
    }
}
