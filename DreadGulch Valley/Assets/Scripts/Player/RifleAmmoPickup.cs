using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleAmmoPickup : MonoBehaviour
{
    public GameObject ammoPickup;

    private GameObject player;
    private GameObject ammoPickupSound;
    private PlayerHealth playerAmmo;

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
            playerAmmo.hasRifle = true;
            playerAmmo.PUArtist += 1;
            playerAmmo.IncreaseRifleAmmoCount(Random.Range(12, 24));
            ammoPickupSound = GameObject.FindGameObjectWithTag("ammoSound");
            ammoPickupSound.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
