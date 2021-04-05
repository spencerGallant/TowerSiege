using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    public float speed;
    // object must know this automatically when spawning
    public int numWaypoints;
    public int spawnPointIndex;

    private Vector2[] waypoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = new Vector2[numWaypoints];
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("waypoints0/waypoint" + i).transform.position;
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
