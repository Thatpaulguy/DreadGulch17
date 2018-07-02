using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanyonMapPickupScript : MonoBehaviour
{
    //private PlayerHealth playerHealth;

	private AudioSource mapSound;

    public GameObject player;
    private LevelMapInfo levelMapInfo;

    // Use this for initialization
    void Start ()
    {
        //playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

		mapSound = GameObject.FindGameObjectWithTag("mapSound").GetComponent<AudioSource>();

        player = GameObject.FindGameObjectWithTag("Player");

        levelMapInfo = player.GetComponent<LevelMapInfo>();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelMapInfo.hasCanyonMap = true;

            levelMapInfo.mapActive = true;

            //playerHealth.hasMap = true;

            mapSound.Play();
            gameObject.SetActive(false);
        }
    }
}
