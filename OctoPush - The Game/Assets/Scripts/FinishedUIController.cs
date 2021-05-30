using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishedUIController : MonoBehaviour
{

    public Text timeText;
    public Text hsText;
    public Text newHS;


    public void display()
    {
        for(int i=0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void hide()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void updateUI(float time, float highScore)
    {
        timeText.text = "Time: " + time.ToString();
        hsText.text = "HighScore: " + highScore.ToString();
        if(time < highScore)
        {
            newHS.enabled = true;
        } else
        {
            newHS.enabled = false;
        }
    }
}
