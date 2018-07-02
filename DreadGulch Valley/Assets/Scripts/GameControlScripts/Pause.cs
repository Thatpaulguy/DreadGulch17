using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    //a reference variable to the canvas pause panel
    public GameObject pausePanel;

    //a reference variable to the canvas button that unpauses the game
    public Button resumeButton;

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    //A function to pause the game
    public void PauseGame()
    {
        //tests if the p key has been pressed this frame to pause the game
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            //if the p key was pressed the pause panel is set to active
            pausePanel.SetActive(true);

            //sets the passage of time to zero (effectively pausing the game)
            Time.timeScale = 0;
        }
    }

    //a function to unpause the game
    public void UnPauseGame()
    {
        //resets time to the normal passage of time (effectively unpausing the game)
        Time.timeScale = 1;
    }
}
