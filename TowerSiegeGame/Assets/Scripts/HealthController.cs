using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private static int playerHealth;
    [SerializeField] private PlayerMove PlayerMove;

    public void Start()
    {
        playerHealth = 20;
        Debug.Log("Health set to " + playerHealth);
    }

    public void UpdateHealth(int x)
    {
        playerHealth = playerHealth - x;

        Debug.Log("Health = " + playerHealth);

        if (playerHealth == 0)
        {
            Debug.Log("in deactivate"); 
            //PlayerMove.DeactivatePlayer();
        }
    }
}
