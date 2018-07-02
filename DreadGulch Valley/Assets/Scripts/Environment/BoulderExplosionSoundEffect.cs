using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderExplosionSoundEffect : MonoBehaviour
{
    public GameObject player;

    private PlayerHealth playerHasDynamite;
    private AudioSource boom;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHasDynamite = player.GetComponent<PlayerHealth>();
        boom = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerHasDynamite.hasDynamite == true)
            { 
                boom.Play();
                playerHasDynamite.hasDynamite = false;
            }
        }
    }
}