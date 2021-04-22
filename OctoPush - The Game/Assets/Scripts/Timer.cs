using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float currentTime;
    public bool on;

    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
        if(GetComponent<Text>())
        {
            text = GetComponent<Text>();
        }
        currentTime = 0f;
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            currentTime += Time.deltaTime;
            updateUI();
        }
    }

    public string getTime()
    {
        return currentTime.ToString();
    }

    private void updateUI()
    {
        if(text)
        {
            text.text = (Mathf.Round(currentTime * 100)/100).ToString();
        }
    }

    public float getCurrentTime()
    {
        return currentTime;
    }
}
