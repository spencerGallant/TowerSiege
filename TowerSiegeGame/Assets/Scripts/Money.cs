/*
 * Keep track of the player's money.
 * Keep this script attatched to the GameController object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    // public int income;

    private TextMeshProUGUI moneyText;

    // Start is called before the first frame update
    void Start()
    {
        moneyText = GameObject.Find("Canvas/MoneyText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update the money text.
        moneyText.SetText("Money: " + money);
    }

    // Check if the player can afford purchasing the unit.
    public bool CanAfford(GameObject unit)
    {
        if (unit.GetComponent<Unit>().cost > money)
        {
            return false;
        }

        return true;
    }

    /*
    // Increment money by the income amount.
    public void GiveIncome()
    {
        money += income;
    }
    */

    // Decrement money by the unit cost.
    public void DeductFunds(GameObject unit)
    {
        money -= unit.GetComponent<Unit>().cost;
    }
}