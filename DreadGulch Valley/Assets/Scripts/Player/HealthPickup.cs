using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;

    GameObject eatingSound;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.HealDamage(30);
            eatingSound = GameObject.FindGameObjectWithTag("eatingSound");
            eatingSound.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
            playerHealth.PUArtist += 1;
        }
    }
}
