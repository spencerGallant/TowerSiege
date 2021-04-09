﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public static bool isPaused = false;
	public GameObject pauseMenuUI;
	public GameObject pauseIcon;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
        	if(isPaused) Resume();
        	else Pause();
        }
    }

    public void Resume() {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
    	isPaused = false;
    	pauseIcon.SetActive(true);
    }

    public void Pause() {
    	pauseMenuUI.SetActive(true);
    	Time.timeScale = 0f;
    	isPaused = true;
    	pauseIcon.SetActive(false);
    }

    public void Quit() {
    	SceneManager.LoadScene("TitleScreen");
    }
}
