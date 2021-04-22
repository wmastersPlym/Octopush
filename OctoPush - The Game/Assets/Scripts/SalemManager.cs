using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalemManager : MonoBehaviour
{

    public Text ui;

    public Timer timer;
    public CountDown countdown;

    public GameObject player;
    
    public int numberOfGatesPassed;
    public int maxGates;

    private puckGate[] gates;


    // Start is called before the first frame update
    void Start()
    {
        init();
    }


    void init()
    {
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
    }
   
}
