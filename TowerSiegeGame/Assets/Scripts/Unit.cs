using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    public int health;
    public float speed;
    public int damage;
    public int cost;

    private TextMeshPro healthText;
    private int spawnIndex;
    private Vector2[] waypoints;
    private int numWaypoints;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Store the waypoint transform coordinates in waypoints[].
        numWaypoints = GameObject.Find("waypoints" + spawnIndex).transform.childCount;
        waypoints = new Vector2[numWaypoints];
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("waypoints" + spawnIndex + "/waypoint" + i).transform.position;
        }

        // Set the first waypoint index to zero.
        waypointIndex = 0;

        // Set the health text.
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        healthText.SetText(health.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the unit if it has reached its last waypoint.
        if (waypointIndex == numWaypoints) 
        {
            Destroy(gameObject);
            return;
        }

        // Get the current waypoint coordinates from waypoints[] and move toward them.
        Vector2 currWaypoint = waypoints[waypointIndex];
        transform.position = Vector2.MoveTowards(transform.position, currWaypoint, speed * Time.deltaTime);

        // Increment the current waypoint index if the current waypoint has been reached.
        if (transform.position.x == currWaypoint.x && transform.position.y == currWaypoint.y)
        {
            waypointIndex++;
        }
    }

    // Damage the castle and destroy unit on collision.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Castle"))
        {
            collision.gameObject.GetComponent<Castle>().takeDamage(damage);
            Destroy(gameObject);
        }
    }

    // Set the spawn index to determine which waypoints the unit follows.
    public void setSpawnIndex(int index)
    {
        spawnIndex = index;
    }

    // Decrease the health of the unit and destroy if its health reaches or goes below zero.
    public void takeDamage(int damage)
    {
        health -= damage;
        healthText.SetText(health.ToString());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
