using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMapScript : MonoBehaviour
{
    public GameObject levelMapCameraImage;
    public GameObject player;
    public LevelMapInfo playerMaps;
    private Scene scene;

    // Use this for initialization
    void Start ()
    {
        scene = SceneManager.GetActiveScene();
        player = GameObject.FindGameObjectWithTag("Player");
        playerMaps = player.GetComponent<LevelMapInfo>();
        levelMapCameraImage.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        DisplayMap();
	}

    void DisplayMap()
    {
        if (Input.GetKeyDown(KeyCode.M) && playerMaps.hasCanyonMap == true && playerMaps.mapActive == true)
        {
            //if the m key has been pressed this frame the map should be displayed
            levelMapCameraImage.SetActive(true);
            
            //sets the passage of time to zero (effectively pausing the game)
            Time.timeScale = 0;

            playerMaps.mapActive = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && playerMaps.hasCanyonMap == true && playerMaps.mapActive == false)
        {
            //if the m key has been pressed this frame the map should be hidden

            levelMapCameraImage.SetActive(false);

            //resets the normal passage of time (effectively unpausing the game)
            Time.timeScale = 1;

            playerMaps.mapActive = true;
        }
    }
}