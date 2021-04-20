using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathingScript : MonoBehaviour
{

    public float maxOxygen = 10f;

    public float oxyDrain;


    public Slider slider;
    public WaterController wc;

    private void Start()
    {
        slider.maxValue = maxOxygen;
        slider.value = maxOxygen;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // Above water
        {
            slider.value += oxyDrain * Time.deltaTime;
            wc.surface();
        }
        else // Submerged
        {
            slider.value -= oxyDrain * Time.deltaTime;
            wc.submerge();
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
