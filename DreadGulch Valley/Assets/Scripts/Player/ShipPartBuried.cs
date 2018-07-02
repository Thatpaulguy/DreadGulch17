// script for buried ship part in graveyard scene

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartBuried : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth shipPart;
    private EnemySpawner spawner;
    private NotificationsManager notify;
    private ShipPartAndPowerCoreFlags shipPartAndPowerCoreFlags;

    public GameObject icons;
    public GameObject inventoryBar;
   
	private AudioSource shovelDigSound;
	private AudioSource shipPartSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shipPart = player.GetComponent<PlayerHealth>();

        inventoryBar = GameObject.FindGameObjectWithTag("ShipPartPanel");

		shovelDigSound = GameObject.FindGameObjectWithTag("shovelDigSound").GetComponent<AudioSource>();
		shipPartSound = GameObject.FindGameObjectWithTag("shipPartSound").GetComponent<AudioSource>();
        shipPartAndPowerCoreFlags = player.GetComponent<ShipPartAndPowerCoreFlags>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (shipPart.hasShovel == true)
            {
                gameObject.SetActive(false);
                shipPart.hasShipPart += 1;
                shipPart.hasBuried = true;

                GameObject icon = Instantiate(icons);

                icon.transform.SetParent(inventoryBar.transform);
                shipPartAndPowerCoreFlags.hasShipPart4 = true;
                shovelDigSound.Play();
				shipPartSound.PlayDelayed(1f);
            }
        }
    }
}