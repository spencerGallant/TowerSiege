using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class UpgradeUnits : MonoBehaviour
{
    public Text unitCountText;
    public static GameObject currentUnitType;
    public List<GameObject> units = new List<GameObject>();

    public GameObject player;
    public GameObject vassal;
    public GameObject knight;
    public GameObject mercenary;
    public GameObject footLancer;
    public GameObject footArcher;
    public GameObject artisan;
    public GameObject peasant;

    public Button vassalButton;
    public Button knightButton;
    public Button mercenaryButton;
    public Button footLancerButton;
    public Button archerButton;
    public Button artisanButton;
    public Button peasantButton;

    public GameObject spawnPoint;
    public float interval;
    public int spawnIndex;
    // public int cost;

    private int unitCount;
    private bool spawning;
    private float timeRemaining;

    public GameObject startRound;
    public GameObject queueButton;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpgradePlayer() {
        int unitCost = currentUnitType.GetComponent<Unit>().cost;
        bool unitBought = startRound.GetComponent<StartRound>().buyUnit(unitCost);
        if (unitBought)
        {
            units.Add(currentUnitType);
            queueButton.GetComponent<QueueUnit>().Queue();
        }
    }

    /*
    public int getCost()
    {
        return cost;
    }
    */

    public void UpgradeVassal() {
        currentUnitType = vassal;
        vassalButton.GetComponent<Image>().color = Color.green;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeKnight() {
        currentUnitType = knight;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.green;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeMercenary() {
        currentUnitType = mercenary;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.green;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeFootLancer() {
        currentUnitType = footLancer;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.green;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeArcher() {
        currentUnitType = footArcher;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.green;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradeArtisan() {
        currentUnitType = artisan;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.green;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void UpgradePeasant() {
        currentUnitType = peasant;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.green;
    }
}