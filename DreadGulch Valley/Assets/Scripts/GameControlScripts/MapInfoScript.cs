using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfoScript : MonoBehaviour
{
    public GameObject player;

    private LevelMapInfo levelMapInfo;

    public GameObject infoCanvas;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        levelMapInfo = player.GetComponent<LevelMapInfo>();

        if (levelMapInfo.hasCanyonMap == true)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            infoCanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
