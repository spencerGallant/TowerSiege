using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnUnits : MonoBehaviour
{
    public Text unitCountText;
    public float interval;
    public GameObject unit;
    public GameObject spawn;

    private int unitCount;
    private bool spawning;
    private float timeRemaining;
    private Vector3 spawnPos;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        timeRemaining = interval;
        spawnPos = spawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // eventually have gameObjects of different units, for now it's just knights
        // will also have multiple unit counts
        unitCount = Int32.Parse(unitCountText.text);
        if (spawning && unitCount > 0)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            } 
            else
            {
                Instantiate(unit, spawnPos, Quaternion.identity);
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
