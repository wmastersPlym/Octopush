using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PuckHuntManager : MonoBehaviour
{

    public Text ui;

    public Timer timer;
    public CountDown countdown;
    public GameObject player;
    public FinishedUIController CompleateUI;
    public GameObject DrownedUI;

    //public int numberOfPucks;

    public TargetScript target;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        init();

        getHighScore();
    }


    void init()
    {

        //setHighScore(0);
        player.GetComponent<BreathingScript>().drownedEvent.AddListener(drowned);

        CompleateUI.hide();
        DrownedUI.SetActive(false);

        countdown.CountDownFinished.AddListener(startGame);
        player.GetComponent<BreathingScript>().controlsEnabled = false;
        player.GetComponent<PlayerController>().controlsEnabled = false;

        target.ChangeInPuckCount.AddListener(updateUI);
        timer.countDownFinished.AddListener(gameFinished);


        //print("Total pucks within target: " + target.numberOfPucks);
        updateUI();
    }


    void updateUI()
    {
        ui.text = "Total pucks within target: " + target.numberOfPucks + "";
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
        int finishPucks = target.numberOfPucks;

        // Display finished UI
        CompleateUI.display();
        CompleateUI.updateUI(finishPucks, getHighScore());


        if (finishPucks > getHighScore())
        {
            setHighScore(finishPucks);
        }
    }


    int getHighScore()
    {
        int hs = PlayerPrefs.GetInt("highScorePuckHunt");
        if (hs > 0)
        {
            return hs;
        }
        else
        {
            return 0;
        }
    }

    void setHighScore(int hs)
    {
        PlayerPrefs.SetInt("highScorePuckHunt", hs);
    }


    public void drowned()
    {
        player.GetComponent<BreathingScript>().controlsEnabled = false;
        player.GetComponent<PlayerController>().controlsEnabled = false;
        timer.on = false;
        DrownedUI.active = true;
    }
}
