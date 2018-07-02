using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth cactus;
   // public AudioClip[] hitClips;            //   remarked out because they interfered with damage and cactus hits.
   // private AudioSource cactusAudio;

    public int DamagePerHit = 10;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cactus = player.GetComponent<PlayerHealth>();
       // hitClips = Resources.LoadAll<AudioClip>("Audio/Hits");
      //  cactusAudio = GetComponent<AudioSource>();
    }
	
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject == player)
        {
            cactus.currentHealth -= 10;
            cactus = player.GetComponent<PlayerHealth>();
            cactus.playerHealthSlider.value = cactus.CalculateRemainingHealth();
         // cactusAudio.PlayOneShot(hitClips[0]);
            cactus.hitCactus += 1;
        }
    }
}