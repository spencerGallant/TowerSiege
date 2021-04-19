﻿/*
 * Contain information about a unit.
 * Attach this script to a unit prefab and set attributes as desired.
 * Note: To add waypoints, follow the pattern in the hierarcy exactly. Units will traverse the waypoints in order.
 */

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
    public float attackFreq;

    private TextMeshPro healthText;
    private Vector2[] waypoints;
    private int spawnIndex;
    private int numWaypoints;
    private int waypointIndex;
    private float attackTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Store the waypoint transform coordinates in waypoints[].
        numWaypoints = GameObject.Find("Waypoints" + spawnIndex).transform.childCount;
        waypoints = new Vector2[numWaypoints];
        for (int i = 0; i < numWaypoints; i++)
        {
            waypoints[i] = GameObject.Find("Waypoints" + spawnIndex + "/Waypoint" + i).transform.position;
        }

        // Set the first waypoint index to zero.
        waypointIndex = 0;

        // Set the health text.
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        SetHealthText();

        attackTimer = attackFreq;
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

        // animator stuff
        // if (transform.position.x > 0) {
        //     GetComponent<Animator>().SetTrigger("Right");
        // } else if (transform.position.x < 0) {
        //     GetComponent<Animator>().SetTrigger("Left");
        // } else if (transform.position.y > 0) {
        //     GetComponent<Animator>().SetTrigger("Up");
        // } else {
        //     GetComponent<Animator>().SetTrigger("Down");
        // }
    }

    // Set the spawn index to determine which waypoints the unit follows.
    public void SetSpawnIndex(int index)
    {
        spawnIndex = index;
    }

    // Decrease the health of the unit and destroy if its health reaches or goes below zero.
    public void TakeDamage(int damage)
    {
        health -= damage;
        SetHealthText();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Increase the unit health.
    public void IncreaseHealth()
    {
        health *= 2;
        SetHealthText();
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }

    // Set the health text.
    private void SetHealthText()
    {
        healthText.SetText(health.ToString());
    }

    // Inflict damage when touching a tower or the castle.
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        else
        {
            if (collision.gameObject.tag == "Castle")
            {
                collision.gameObject.GetComponent<Castle>().TakeDamage(damage);
            }
            if (collision.gameObject.tag == "Tower")
            {
                collision.gameObject.GetComponent<Tower>().TakeDamage(damage);
            }
            attackTimer = attackFreq;
        }
    }
}