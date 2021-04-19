/*
 * Display the end menu.
 * Keep this script attached to the GameController object.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public GameObject endMenu;
    public GameObject endText;

    private GameObject gameController;
    private GameObject castle;
    private GameObject player;
    private bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        castle = GameObject.FindGameObjectWithTag("Castle");
        player = GameObject.FindGameObjectWithTag("Player");
        reloading = false;
    }

    // Update is called once per frame
    void Update()
    {
        // End the game if the castle is destroyed.
        if (!castle.activeSelf)
        {
            DisplayEndMenu("CONGRATULATIONS\nYou destroyed the castle.");
        }

        // End the game if the player dies.
        if (!player.activeSelf)
        {
            DisplayEndMenu("GAME OVER\nYou died.");
        }

        // End the game if the player otherwise lost.
        if (Lost())
        {
            DisplayEndMenu("GAME OVER\nYou ran out of money and units.");
        }
    }

    public void Retry()
    {
        reloading = true;
        Time.timeScale = 1f;
        player.GetComponent<Player>().Unfreeze();
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
    }

    public void Quit()
    {
        Application.Quit();
    }

    // Check if the player lost.
    private bool Lost()
    {
        if (!(gameController.GetComponent<Money>().HasMoney() || gameController.GetComponent<UnitQueues>().UnitsQueued()))
        {
            GameObject[] units = GameObject.FindGameObjectsWithTag("Unit");
            if (units.Length == 0)
            {
                return true;
            }
        }

        return false;
    }

    // Display the end menu and set the end text.
    private void DisplayEndMenu(string endMessage)
    {
        if (!reloading)
        {
            Time.timeScale = 0f;
            player.GetComponent<Player>().Freeze();
        }
        endMenu.SetActive(true);
        endText.GetComponent<TextMeshProUGUI>().SetText(endMessage);
    }
}