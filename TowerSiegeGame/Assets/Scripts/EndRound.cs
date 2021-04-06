using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame() {
        SceneManager.LoadScene("EndScreen");
    }

    public void QuitGame() {
    	Application.Quit();
    }
}
