using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public int health;
	public float speed;

	private GameObject gameController;
	private TextMeshPro healthText;
	private bool frozen;

	// Start is called before the first frame update
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController");

		frozen = false;

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
}