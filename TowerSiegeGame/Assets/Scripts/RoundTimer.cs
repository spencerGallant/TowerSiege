/*
 * Keep track of time left in the round.
 * Keep this script attached to the GameController object and set attributes as desired.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundTimer : MonoBehaviour
{
    public int time;
    public int incomeTime;

    private TextMeshProUGUI timerText;
    private bool timerStarted;
    private float timeLeft;
    private float incomeTimer;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GameObject.Find("Canvas/TimerText").GetComponent<TextMeshProUGUI>();

        timerStarted = false;
        timeLeft = time;
        incomeTimer = time;
        SetTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                timerStarted = false;
            }
            SetTimerText();

            if (timeLeft < incomeTimer)
            {
                incomeTimer -= incomeTime;
                gameObject.GetComponent<Money>().GiveIncome();
            }
        }
    }

    // On-click: Start the timer.
    public void StartTimer()
    {
        timerStarted = true;
    }

    public bool RoundStarted()
    {
        return timerStarted;
    }

    public bool TimeUp()
    {
        if (timeLeft > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetTimerText()
    {
        timerText.SetText("Time: " + timeLeft.ToString("0"));
    }
}