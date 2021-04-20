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

    public GameObject sticks;
    public GameObject dummyStick;

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
            setDummySticks();

        }
        else // Submerged
        {
            slider.value -= oxyDrain * Time.deltaTime;
            wc.submerge();
            setRealSticks();
        }
    }

    public void checkIfDowned()
    {
        if(slider.value <= 0f)
        {
            print("Drowned");
        }
    }

    private void setRealSticks()
    {
        dummyStick.SetActive(false);
        sticks.SetActive(true);
    }

    private void setDummySticks()
    {
        sticks.SetActive(false);
        dummyStick.SetActive(true);
    }
}
