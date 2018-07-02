using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth shovel;

	private AudioSource shovelSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shovel = player.GetComponent<PlayerHealth>();

		shovelSound = GameObject.FindGameObjectWithTag("shovelSound").GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            shovel.hasShovel = true;

			shovelSound.Play();
        }
    }
}