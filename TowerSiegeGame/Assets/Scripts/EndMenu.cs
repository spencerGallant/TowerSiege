using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    private GameObject endMenu;
    private TextMeshProUGUI endText;
    private GameObject castle;
    private GameObject player;
    private bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        endMenu = transform.Find("endMenu").gameObject;
        endText = endMenu.transform.Find("endText").gameObject.GetComponent<TextMeshProUGUI>();
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
            displayEndMenu("CONGRATULATIONS\nYou destroyed the castle.");
        }

        // End the game if the player dies.
        if (!player.activeSelf)
        {
            displayEndMenu("GAME OVER\nYou died.");
        }

        // End the game if time runs out.
        if (gameObject.GetComponent<StartRound>().timeUp())
        {
            displayEndMenu("GAME OVER\nTime ran out.");
        }
    }

    public void retry()
    {
        reloading = true;
        Time.timeScale = 1f;
        player.GetComponent<Player>().unfreeze();
        SceneManager.LoadSceneAsync("MainScene");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
    }

    public void quit()
    {
        Application.Quit();
    }

    // Display the end menu and set the end text.
    private void displayEndMenu(string endMessage)
    {
        if (!reloading)
        {
            Time.timeScale = 0f;
            player.GetComponent<Player>().freeze();
        }
        endMenu.SetActive(true);
        endText.SetText(endMessage);
    }
}
