﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public int health;
	public float speed;
	public float buffCooldown;
	public float buffRange;
	public float debuffCooldown;
	public float debuffRange;
	public float debuffDuration;

	private GameObject gameController;
	private TextMeshPro healthText;
	private float buffTimer;
	private float debuffTimer;
	private bool buffReady;
	private bool debuffReady;
	private bool frozen;

	// Start is called before the first frame update
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");

		frozen = false;
		buffReady = true;
		debuffReady = true;
		buffTimer = 0f;
		debuffTimer = 0f;

		// Set the health text.
		healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
		healthText.SetText(health.ToString());
	}

	// Update is called once per frame
	void Update()
	{
		if (!frozen && gameController.GetComponent<RoundTimer>().RoundStarted())
		{
			// Control the player's movement.
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
			{
				//print("going left");
				Vector3 position = this.transform.position;
				position.x = position.x - speed;
				this.transform.position = position;
				
				GetComponent<Animator>().SetTrigger("Left");
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				//print("going right");
				Vector3 position = this.transform.position;
				position.x = position.x + speed;
				this.transform.position = position;

				GetComponent<Animator>().SetTrigger("Right");

			}
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				//print("going up");
				Vector3 position = this.transform.position;
				position.y = position.y + speed;
				this.transform.position = position;

				GetComponent<Animator>().SetTrigger("Up");

			}
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				//print("going down");
				Vector3 position = this.transform.position;
				position.y = position.y - speed;
				this.transform.position = position;

				GetComponent<Animator>().SetTrigger("Down");
			}

			// animator stuff
			// Vector2 dir = this.transform.position;
			// print(dir.x);
			// print(dir.y);
        	// GetComponent<Animator>().SetFloat("DirX", dir.x);
        	// GetComponent<Animator>().SetFloat("DirY", dir.y);

			// Buff cooldown.
			if (!buffReady)
			{
				if (buffTimer <= 0)
				{
					buffTimer = buffCooldown;
				}
				else
				{
					buffTimer -= Time.deltaTime;
					if (buffTimer <= 0)
					{
						buffReady = true;
						Debug.Log("buff ready");
					}
				}
			}

			// Debuff cooldown.
			if (!debuffReady)
            {
				if (debuffTimer <= 0)
                {
					debuffTimer = debuffCooldown;
				}
				else
                {
					debuffTimer -= Time.deltaTime;
					if (debuffTimer <= 0)
                    {
						debuffReady = true;
						Debug.Log("debuff ready");
                    }
                }
            }

			// Use buff.
			if (Input.GetKey(KeyCode.Alpha2))
			{
				if (buffReady)
				{
					Buff();
					buffReady = false;
				}
			}

			// Use debuff.
			if (Input.GetKey(KeyCode.Alpha1))
            {
				if (debuffReady)
                {
					Debuff();
					debuffReady = false;
				}
            }
		}
	}

	// Take damage and deactivate if health falls below zero.
	public void TakeDamage(int damage)
	{
		health -= damage;
		healthText.SetText(health.ToString());
		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
	}

	// Disable movement.
	public void Freeze()
	{
		frozen = true;
	}

	// Enable movement.
	public void Unfreeze()
	{
		frozen = false;
	}

	// Check if the game object is within range.
	private bool InRange(GameObject obj, float range)
	{
		Vector3 difference = obj.transform.position - transform.position;
		float distSqr = difference.sqrMagnitude;
		if (distSqr > range * range)
		{
			return false;
		}
		return true;
	}

	// Use the player buff ability.
	private void Buff()
	{
		Debug.Log("buff used");
		GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
		foreach (GameObject unit in units)
		{
			if (InRange(unit, buffRange))
			{
				unit.GetComponent<Unit>().IncreaseHealth();
			}
		}
	}

	// Use the player debuff ability.
	private void Debuff()
    {
		Debug.Log("debuff used");
		GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
		foreach (GameObject tower in towers)
        {
			if (InRange(tower, debuffRange))
            {
				tower.GetComponent<Tower>().SlowShooting(debuffDuration);
            }
        }
    }
}