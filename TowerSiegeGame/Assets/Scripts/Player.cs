using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
	public int health;
	public float speed;

	private TextMeshPro healthText;

    // Start is called before the first frame update
	void Start()
	{
		// Set the health text.
		healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
		healthText.SetText(health.ToString());
	}

	// Update is called once per frame
	void Update()
	{
		// Control the player's movement.
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x - speed;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			Vector3 position = this.transform.position;
			position.x = position.x + speed;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			Vector3 position = this.transform.position;
			position.y = position.y + speed;
			this.transform.position = position;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			Vector3 position = this.transform.position;
			position.y = position.y - speed;
			this.transform.position = position;
		}
	}

	// Take damage and deactivate if health falls below zero.
	public void takeDamage(int damage)
    {
		health -= damage;
		healthText.SetText(health.ToString());
		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
