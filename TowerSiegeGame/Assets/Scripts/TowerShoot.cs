using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public GameObject projectile;
    public float interval;

    private float timeRemaining;
    private GameObject[] units;

    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = interval;
    }

    // Update is called once per frame
    void Update()
    {
        units = GameObject.FindGameObjectsWithTag("Unit");
        if (units.Length == 0)
        {
            timeRemaining = interval;
        } 
        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        } 
        else
        {
            GameObject projectileClone = Instantiate(projectile, transform.position, Quaternion.identity);
            ProjectileMove projectileMove = projectileClone.GetComponent<ProjectileMove>();
            projectileMove.target = ClosestUnit();
            timeRemaining = interval;
        }
    }

    // Returns the position of the closest unit to the tower. Returns an uninitialized Vector3 if no units are present.
    Vector3 ClosestUnit()
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
}
