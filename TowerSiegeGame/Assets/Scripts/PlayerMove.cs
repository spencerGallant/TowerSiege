using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	public float speed;
    // Start is called before the first frame update
	void Start()
	{

	}

	void Update()
	{
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
}
