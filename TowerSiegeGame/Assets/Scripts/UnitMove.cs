using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float speed;
    public int spawnIndex; // Set by SpawnUnits.cs when the unit is instantiated.

    private Vector2[] waypoints;
    private int numWaypoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        numWaypoints = GameObject.Find("waypoints" + spawnIndex).transform.childCount;
        waypoints = new Vector2[numWaypoints];
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("waypoints" + spawnIndex + "/waypoint" + i).transform.position;
        }
        waypointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypointIndex == numWaypoints) 
        {
            Destroy(gameObject);
            return;
        }
        Vector2 currWaypoint = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currWaypoint, speed * Time.deltaTime);
        if (transform.position.x == currWaypoint.x && transform.position.y == currWaypoint.y)
        {
            waypointIndex++;
        }
    }
}
