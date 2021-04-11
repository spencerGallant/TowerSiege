using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartRound : MonoBehaviour
{
    public float time;

    private TextMeshProUGUI timerText;
    private float timeLeft;
    private bool timerStarted;

    // Start is called before the first frame update
    void Start()
    {
        timerText = transform.Find("timerText").gameObject.GetComponent<TextMeshProUGUI>();
        timerStarted = false;
        timeLeft = time;
        setTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                setTimerText();
            }
            else
            {
                timeLeft = 0;
                setTimerText();
                timerStarted = false;
            }
        }
    }

    public void startTimer()
    {
        if (!timerStarted)
        {
            timeLeft = time;
        }
        timerStarted = true;
    }

    public bool timeUp()
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

    private void setTimerText()
    {
        timerText.SetText("Time: " + timeLeft.ToString("0"));
    }
}
