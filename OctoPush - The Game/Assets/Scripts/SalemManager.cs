using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SalemManager : MonoBehaviour
{

    public Text ui;

    public Timer timer;
    public CountDown countdown;
    public GameObject player;
    public FinishedUIController CompleateUI;
    public GameObject DrownedUI;
    
    public int numberOfGatesPassed;
    public int maxGates;

    private puckGate[] gates;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        init();

        getHighScore();
    }


    void init()
    {
        player.GetComponent<BreathingScript>().drownedEvent.AddListener(drowned);

        CompleateUI.hide();
        DrownedUI.active = false;

        countdown.CountDownFinished.AddListener(startGame);
        player.GetComponent<BreathingScript>().controlsEnabled = false;
        player.GetComponent<PlayerController>().controlsEnabled = false;

        GameObject[] gatesgm = GameObject.FindGameObjectsWithTag("PuckGate");

        gates = new puckGate[gatesgm.Length];

        for (int i = 0; i < gatesgm.Length; i++) // Fill array of puck gate scripts
        {
            gates[i] = gatesgm[i].GetComponent<puckGate>();
        }

        foreach (puckGate gate in gates)
        {
            gate.PuckPassed.AddListener(gatePassed);
        }

        print("Total puck gates: " + gates.Length);
        numberOfGatesPassed = 0;
        maxGates = gates.Length;
        updateUI();
    }

    void gatePassed()
    {
        print("Gate Passed");
        numberOfGatesPassed++;
        updateUI();
        checkFinished();
    }

    void updateUI ()
    {
        ui.text = "Gates Passed: " + numberOfGatesPassed.ToString() + "/" + maxGates.ToString();
    }

    void checkFinished()
    {
        if(numberOfGatesPassed >= maxGates)
        {
            gameFinished();
            //print("Finished");
        }
    }

    void startGame()
    {
        timer.on = true;
        player.GetComponent<BreathingScript>().controlsEnabled = true;
        player.GetComponent<PlayerController>().controlsEnabled = true;
    }

    void gameFinished()
    {
        timer.on = false;
        float finishTime = timer.getCurrentTime();

        // Display finished UI
        CompleateUI.display();
        CompleateUI.updateUI(finishTime, getHighScore());


        if(finishTime < getHighScore())
        {
            setHighScore(finishTime);
        }
    }

   
    float getHighScore()
    {
        float hs = PlayerPrefs.GetFloat("highScore");
        if (hs > 0f)
        {
            return hs;
        }
        else
        {
            return 999.99f;
        }
    }

    void setHighScore(float hs)
    {
        PlayerPrefs.SetFloat("highScore", hs);
    }


    public void drowned()
    {
        player.GetComponent<BreathingScript>().controlsEnabled = false;
        player.GetComponent<PlayerController>().controlsEnabled = false;
        timer.on = false;
        DrownedUI.active = true;
    }
}
