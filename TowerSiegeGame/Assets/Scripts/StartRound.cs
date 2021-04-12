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

    public int gold;
    public int income;
    public int incomeTime;

    public TextMeshProUGUI goldText;
    public float currentGold;
    private float incomeTimer = 60;


    // Start is called before the first frame update
    void Start()
    {
        timerText = transform.Find("timerText").gameObject.GetComponent<TextMeshProUGUI>();
        timerStarted = false;
        timeLeft = time;
        setTimerText();

        goldText = transform.Find("currency").gameObject.GetComponent<TextMeshProUGUI>();
        currentGold = gold;
        setGoldText();
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
            if (timeLeft < incomeTimer)
            {
                incomeTimer -= incomeTime;
                addIncome();
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

    public void addIncome()
    {
        //Debug.Log("in add income");
        currentGold += income;
        setGoldText();
    }

    public bool buyUnit(int x)
    {
        if (currentGold - x < 0)
        {
            return false;
        }
        currentGold -= x;
        setGoldText();
        return true;
    }

    private void setGoldText()
    {
        goldText.SetText("Gold: " + currentGold.ToString("0"));
    }
}
