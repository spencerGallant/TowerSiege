using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QueueUnit : MonoBehaviour
{
    public Text unitCountText;
    
    private int unitCount;
    private int cost;

    public GameObject startRound;
    public GameObject spawnUnits;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Queue()
    {
        Debug.Log("in queue");
        /*
        cost = spawnUnits.GetComponent<SpawnUnits>().getCost();
        if (!startRound.GetComponent<StartRound>().buyUnit(cost))
        {
            return;
        }
        */

        unitCount = Int32.Parse(unitCountText.text);
        unitCount++;
        unitCountText.text = unitCount.ToString();
    }
}
