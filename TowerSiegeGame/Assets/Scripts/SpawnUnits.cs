using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SpawnUnits : MonoBehaviour
{
    public Text unitCountText;
    public static GameObject currentUnitType;
    public List<GameObject> units = new List<GameObject>();

    public GameObject knight;
    public GameObject archer;
    public Button knightButton;
    public Button archerButton;

    
    public GameObject spawnPoint ;
    public float interval;
    public int spawnIndex;

    private int unitCount;
    private bool spawning;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        timeRemaining = interval;
        currentUnitType = knight;
        knightButton.GetComponent<Image>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Support more than one unit type.
        unitCount = Int32.Parse(unitCountText.text);
        if (spawning && unitCount > 0)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            } 
            else
            {
                GameObject unitClone = Instantiate(units[0], spawnPoint.transform.position, Quaternion.identity);
                units.RemoveAt(0);
                UnitMove unitMove = unitClone.GetComponent<UnitMove>();
                // Set the spawnIndex field of the unit's UnitMove.cs so that it knows which waypoints to go to.
                unitMove.spawnIndex = spawnIndex;
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

    public void SpawnKnights() {
        currentUnitType = knight;
        knightButton.GetComponent<Image>().color = Color.green;
        archerButton.GetComponent<Image>().color = Color.white;
    }

    public void SpawnArcher() {
        currentUnitType = archer;
        knightButton.GetComponent<Image>().color = Color.white;
        archerButton.GetComponent<Image>().color = Color.green;
    }
}
