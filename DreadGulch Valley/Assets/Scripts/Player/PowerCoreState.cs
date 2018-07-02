using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerCoreState : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth powerCore;
    private ShipPartAndPowerCoreFlags shipPartAndPowerCoreFlags;
    private Scene scene;
    private AudioSource shieldChargeSound;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            powerCore = player.GetComponent<PlayerHealth>();

            shipPartAndPowerCoreFlags = player.GetComponent<ShipPartAndPowerCoreFlags>();
        }

        shieldChargeSound = GameObject.FindGameObjectWithTag("shieldChargeSound").GetComponent<AudioSource>();

        // Grabs the current active scene info
        scene = SceneManager.GetActiveScene();

        if (shipPartAndPowerCoreFlags != null)
        {
            // test to see if the current scene's power core has been picked up and if so sets the power core to not be active

            if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasPowerCore1 == true)
            {
                gameObject.SetActive(false);
            }
            if (scene.name == "Canyon" && shipPartAndPowerCoreFlags.hasPowerCore2 == true)
            {
                gameObject.SetActive(false);
            }
            if (scene.name == "Mines" && shipPartAndPowerCoreFlags.hasPowerCore3 == true)
            {
                gameObject.SetActive(false);
            }
            if (scene.name == "GraveYard" && shipPartAndPowerCoreFlags.hasPowerCore4 == true)
            {
                gameObject.SetActive(false);
            }
            if (scene.name == "Town" && shipPartAndPowerCoreFlags.hasPowerCore5 == true)
            {
                gameObject.SetActive(false);
            }
            if (scene.name == "Saloon" && shipPartAndPowerCoreFlags.hasPowerCore6 == true)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            powerCore.hasPowerCore += 1;
            powerCore.currentShield += 75;
            powerCore.playerShieldSlider.value = powerCore.CalculateRemainingShield();

			shieldChargeSound.Play();
            
            if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasPowerCore1 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore1 = true;
            }
            else if (scene.name == "Canyon" && shipPartAndPowerCoreFlags.hasPowerCore2 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore2 = true;
            }
            else if (scene.name == "Mines" && shipPartAndPowerCoreFlags.hasPowerCore3 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore3 = true;
            }
            else if (scene.name == "GraveYard" && shipPartAndPowerCoreFlags.hasPowerCore4 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore4 = true;
            }
            else if (scene.name == "Town" && shipPartAndPowerCoreFlags.hasPowerCore5 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore5 = true;
            }
            else if (scene.name == "Saloon" && shipPartAndPowerCoreFlags.hasPowerCore6 == false)
            {
                shipPartAndPowerCoreFlags.hasPowerCore6 = true;
            }
        }
    }
}