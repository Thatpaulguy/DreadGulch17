using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmoPickup : MonoBehaviour
{
    public GameObject ammoPickup;
    
    GameObject player;

    GameObject ammoPickupSound;

    PlayerHealth playerAmmo;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAmmo = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerAmmo.hasShotgun = true;
            playerAmmo.PUArtist += 1;
            playerAmmo.IncreaseShotgunAmmoCount(Random.Range(12, 24));
            ammoPickupSound = GameObject.FindGameObjectWithTag("ammoSound");
            ammoPickupSound.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
