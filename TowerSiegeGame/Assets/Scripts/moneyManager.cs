using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class moneyManager : MonoBehaviour
{
    public int gold;
    public int income;

    private TextMeshProUGUI goldText;
    private float currentGold;

    // Start is called before the first frame update
    void Start()
    {
        goldText = transform.Find("currency").gameObject.GetComponent<TextMeshProUGUI>();
        currentGold = gold;
        setGoldText();
    }

    public void addIncome()
    {
        Debug.Log("in add income");
        currentGold += income;
        setGoldText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setGoldText()
    {
        goldText.SetText("Time: " + currentGold.ToString("0"));
    }
}
