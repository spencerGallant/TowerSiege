using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    [SerializeField] public int arrowDamage;
    [SerializeField] private HealthController HealthController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("in On trigger");

        if (collision.CompareTag("Player"))
        {
            HealthController.UpdateHealth(arrowDamage);
        }
    }
}
