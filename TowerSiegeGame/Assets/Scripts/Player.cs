using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public int health;
	public float speed;
	public float debuffCooldown;
	public float debuffRange;
	public float debuffDuration;

	private GameObject gameController;
	private GameObject[] towers;
	private TextMeshPro healthText;
	private float debuffTimer;
	private bool frozen;
	private bool debuffReady;

	// Start is called before the first frame update
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");

		frozen = false;
		debuffReady = true;
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
				Vector3 position = this.transform.position;
				position.x = position.x - speed;
				this.transform.position = position;
			}
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
			{
				Vector3 position = this.transform.position;
				position.x = position.x + speed;
				this.transform.position = position;
			}
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			{
				Vector3 position = this.transform.position;
				position.y = position.y + speed;
				this.transform.position = position;
			}
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			{
				Vector3 position = this.transform.position;
				position.y = position.y - speed;
				this.transform.position = position;
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

	// Use the player ability.
	private void Debuff()
    {
		Debug.Log("debuff used");
		towers = GameObject.FindGameObjectsWithTag("Tower");
		foreach (GameObject tower in towers)
        {
			if (InRange(tower, debuffRange))
            {
				tower.GetComponent<Tower>().SlowShooting(debuffDuration);
            }
        }
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
}