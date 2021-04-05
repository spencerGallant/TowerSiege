using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnits : MonoBehaviour
{
    public Text unitCountText;
    public GameObject unit;
    public GameObject spawnPoint;
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
                GameObject unitClone = Instantiate(unit, spawnPoint.transform.position, Quaternion.identity);
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
}
