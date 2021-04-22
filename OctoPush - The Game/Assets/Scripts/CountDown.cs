using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    public UnityEvent CountDownFinished = new UnityEvent();

    public float countDownTime;
    public bool on;

    public Text text;

    private float currentTime;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = countDownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            if(currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                updateUI();
            } else
            {
                CountDownFinished.Invoke();
                removeUI();
            }
            
        }
    }

    private void updateUI()
    {
        if (text)
        {
            text.text = (Mathf.Round(currentTime * 10) / 10).ToString();
        }
    }

    private void removeUI()
    {
        if(text)
        {
            text.gameObject.SetActive(false);
        }
    }
}
