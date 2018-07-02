using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipPartPickupState : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth shipPart;
    private ShipPartAndPowerCoreFlags shipPartAndPowerCoreFlags;
    private Scene scene;

    private AudioSource shipPartSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shipPart = player.GetComponent<PlayerHealth>();

		shipPartSound = GameObject.FindGameObjectWithTag("shipPartSound").GetComponent<AudioSource>();

        shipPartAndPowerCoreFlags = player.GetComponent<ShipPartAndPowerCoreFlags>();

        //Grabs the current active scene info
        scene = SceneManager.GetActiveScene();

        //test to see if the current scene's ship part has been picked up and if so sets the ship part to not be active
        if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasShipPart1 == true)
        {
            gameObject.SetActive(false);
        }
        if (scene.name == "Canyon" && shipPartAndPowerCoreFlags.hasShipPart2 == true)
        {
            gameObject.SetActive(false);
        }
        if (scene.name == "Mines" && shipPartAndPowerCoreFlags.hasShipPart3 == true)
        {
            gameObject.SetActive(false);
        }
        if (scene.name == "GraveYard" && shipPartAndPowerCoreFlags.hasShipPart4 == true)
        {
            gameObject.SetActive(false);
        }
        if (scene.name == "Town" && shipPartAndPowerCoreFlags.hasShipPart5 == true)
        {
            gameObject.SetActive(false);
        }
        if (scene.name == "Saloon" && shipPartAndPowerCoreFlags.hasShipPart6 == true)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            shipPart.hasShipPart += 1;

			shipPartSound.Play();

            if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasShipPart1 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart1 = true;
            }
            else if (scene.name == "Canyon" && shipPartAndPowerCoreFlags.hasShipPart2 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart2 = true;
            }
            else if (scene.name == "Mines" && shipPartAndPowerCoreFlags.hasShipPart3 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart3 = true;
            }
            else if (scene.name == "GraveYard" && shipPartAndPowerCoreFlags.hasShipPart4 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart4 = true;
            }
            else if (scene.name == "Town" && shipPartAndPowerCoreFlags.hasShipPart5 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart5 = true;
            }
            else if (scene.name == "Saloon" && shipPartAndPowerCoreFlags.hasShipPart6 == false)
            {
                shipPartAndPowerCoreFlags.hasShipPart6 = true;
            }
        }
    }
}
