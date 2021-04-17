using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tower : MonoBehaviour
{
    public GameObject projectile;
    public float interval;
    public float range;
    public int health;

    private float timeRemaining;
    private GameObject[] units;
    private Vector3 targetPos;
    private TextMeshPro healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();
        healthText.SetText(health.ToString());

        DrawCircle();

        timeRemaining = interval;
    }

    // Update is called once per frame
    void Update()
    {
        units = GameObject.FindGameObjectsWithTag("Unit");
        if (units.Length == 0 || !InRange(ClosestUnit()))
        {
            timeRemaining = interval;
        } 
        else if (timeRemaining > 0)
        {
            targetPos = ClosestUnit();
            timeRemaining -= Time.deltaTime;
        } 
        else
        {
            GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);
            projectileClone.GetComponent<Projectile>().setTarget(targetPos);
            timeRemaining = interval;
        }
    }

    // Take damage when touched by a unit.
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.SetText(health.ToString());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Returns the position of the closest unit to the tower.
    private Vector3 ClosestUnit()
    {
        Vector3 closest = new Vector3();
        float shortestDist = Mathf.Infinity;
        foreach (GameObject currUnit in units)
        {
            Vector3 difference = currUnit.transform.position - transform.position;
            float distance = difference.sqrMagnitude;
            if (distance < shortestDist)
            {
                closest = currUnit.transform.position;
                shortestDist = distance;
            }
        }

        return closest;
    }

    // Check if a unit's position is within range.
    private bool InRange(Vector3 unitPos)
    {
        Vector3 difference = unitPos - transform.position;
        float distance = difference.sqrMagnitude;
        if (distance < range * range)
        {
            return true;
        }
        return false;
    }

    // Draw a circle around the tower to represent the range.
    private void DrawCircle()
    {
        int vertexNumber = 50;

        LineRenderer line = gameObject.GetComponent<LineRenderer>();
        line.material.color = Color.red;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        line.loop = true;
        float angle = 2 * Mathf.PI / vertexNumber;
        line.positionCount = vertexNumber;

        for (int i = 0; i < vertexNumber; i++)
        {
            Matrix4x4 rotationMatrix = new Matrix4x4(new Vector4(Mathf.Cos(angle * i), Mathf.Sin(angle * i), 0, 0),
                                                     new Vector4(-1 * Mathf.Sin(angle * i), Mathf.Cos(angle * i), 0, 0),
                                       new Vector4(0, 0, 1, 0),
                                       new Vector4(0, 0, 0, 1));
            Vector3 initialRelativePosition = new Vector3(0, range, 0);
            line.SetPosition(i, transform.position + rotationMatrix.MultiplyPoint(initialRelativePosition));
        }
    }

    // Set the health text.
    private void SetHealthText()
    {

    }
}
