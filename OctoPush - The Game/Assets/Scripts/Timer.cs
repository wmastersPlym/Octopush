using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{

    private float currentTime;
    public bool on;

    public bool countdown;
    public float countDownTime;

    public Text text;

    public UnityEvent countDownFinished = new UnityEvent();

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
            if(!countdown)
            {
                currentTime += Time.deltaTime;
                updateUI();
            } else
            {
                countDownTime -= Time.deltaTime;
                updateUI();
                checkFinished();
            }
            
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
            if(!countdown)
            {
                text.text = (Mathf.Round(currentTime * 100) / 100).ToString();
            } else
            {
                text.text = (Mathf.Round(countDownTime * 100) / 100).ToString();
            }
                
        }
    }

    public float getCurrentTime()
    {
        if (!countdown)
        {
            return currentTime;
        }
        else
        {
            return countDownTime;
        }
        
    }

    public void checkFinished()
    {
        if(countDownTime <= 0.0f)
        {
            countDownFinished.Invoke();
        }
    }
}
