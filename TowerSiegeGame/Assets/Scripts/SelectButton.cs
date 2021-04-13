/*
 * Select a unit to buy.
 * Attach this script to a Set[unit type] object and drag the appropriate prefab onto the inspector field.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public GameObject unit;

    private GameObject gameController;
    private Image[] allButtons;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        allButtons = transform.parent.GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // On-click: Set the selected unit in UnitQueues and update the button colors.
    public void SelectUnit()
    {
        gameController.GetComponent<UnitQueues>().SelectUnit(unit);

        foreach (Image image in allButtons)
        {
            if (image.gameObject == transform.parent.gameObject)
            {
                continue;
            }
            image.color = Color.white;
        }
        gameObject.GetComponent<Image>().color = Color.green;
    }
}
