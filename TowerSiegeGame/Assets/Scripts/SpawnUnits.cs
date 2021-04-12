using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class SpawnUnits : MonoBehaviour
{
    public Text unitCountText;
    public static GameObject currentUnitType;
    public List<GameObject> units = new List<GameObject>();

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
    public int cost;

    private int unitCount;
    private bool spawning;
    private float timeRemaining;

    public GameObject startRound;


    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        timeRemaining = interval;
        currentUnitType = peasant;
        peasantButton.GetComponent<Image>().color = Color.green;

    }

    // Update is called once per frame
    void Update()
    {
        unitCount = Int32.Parse(unitCountText.text);
        if (spawning && unitCount > 0)
        {
            // Debug.Log("spawning");
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            } 
            else
            {
                GameObject unitClone = Instantiate(units[0], spawnPoint.transform.position, Quaternion.identity);
                units.RemoveAt(0);
                unitClone.GetComponent<Unit>().setSpawnIndex(spawnIndex);
                unitCount -= 1;
                unitCountText.text = unitCount.ToString();
                timeRemaining = interval;
            }
        }
    }

    public void ToggleSpawn()
    {
        spawning = !spawning;
        if (spawning)
        {
            GetComponent<Image>().color = Color.green;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }

    public void AddUnit() {
        units.Add(currentUnitType);
    }

    public int getCost()
    {
        return cost;
    }

    public void SpawnVassal() {
        currentUnitType = vassal;
        vassalButton.GetComponent<Image>().color = Color.green;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnKnight() {
        currentUnitType = knight;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.green;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnMercenary() {
        currentUnitType = mercenary;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.green;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnFootLancer() {
        currentUnitType = footLancer;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.green;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnArcher() {
        currentUnitType = footArcher;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.green;
        artisanButton.GetComponent<Image>().color = Color.white;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnArtisan() {
        currentUnitType = artisan;
        vassalButton.GetComponent<Image>().color = Color.white;
        knightButton.GetComponent<Image>().color = Color.white;
        mercenaryButton.GetComponent<Image>().color = Color.white;
        footLancerButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.white;
        artisanButton.GetComponent<Image>().color = Color.green;
        peasantButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnPeasant() {
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
