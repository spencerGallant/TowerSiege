using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().SetText(health.ToString());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
