using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartRound : MonoBehaviour
{
    public Text timer;
    public float time;

    private float timeLeft;
    private bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        timerStarted = false;
        timeLeft = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                SetTimerText();
            }
            else
            {
                timeLeft = time;
                SetTimerText();
                timerStarted = false;
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    void SetTimerText()
    {
        timer.text = "Time: " + timeLeft.ToString("0");
    }
}
