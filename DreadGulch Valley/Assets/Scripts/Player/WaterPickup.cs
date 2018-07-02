using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;

    GameObject drinkingSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerHealth.HealDamage(15);
            drinkingSound = GameObject.FindGameObjectWithTag("drinkingSound");
            drinkingSound.GetComponent<AudioSource>().Play();
            playerHealth.PUArtist += 1;
            gameObject.SetActive(false);
        }
    }
}
