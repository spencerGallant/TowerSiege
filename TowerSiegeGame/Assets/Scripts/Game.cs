using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject gameEndUI;

    private GameObject castle;

    // Start is called before the first frame update
    void Start()
    {
        castle = GameObject.FindGameObjectWithTag("Castle");
    }

    // Update is called once per frame
    void Update()
    {
        if (castle.GetComponent<Castle>().isDestroyed())
        {
            gameEndUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
