/*
 * Spawn units at the specified time interval.
 * Attach this script to a SpawnButton Object and set Button Index approprately.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnButton : MonoBehaviour
{
    public int buttonIndex;
    public float interval;

    private GameObject gameController;
    private GameObject spawnPoint;
    private bool spawning;
    private float timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        spawnPoint = GameObject.Find("SpawnPoints/SpawnPoint" + buttonIndex);

        spawning = false;
        timeRemaining = interval;
    }

    // Update is called once per frame
    void Update()
    {
        bool queueEmpty = gameController.GetComponent<UnitQueues>().IsEmpty(buttonIndex);
        if (spawning && !queueEmpty)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                GameObject unit = gameController.GetComponent<UnitQueues>().Dequeue(buttonIndex);
                GameObject unitClone = Instantiate(unit, spawnPoint.transform.position, Quaternion.identity);
                unitClone.GetComponent<Unit>().SetSpawnIndex(buttonIndex);
                timeRemaining = interval;
            }
        }
    }

    // On-click: Start/stop spawning units if the round has started.
    public void ToggleSpawn()
    {
        if (gameController.GetComponent<RoundTimer>().RoundStarted())
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
}