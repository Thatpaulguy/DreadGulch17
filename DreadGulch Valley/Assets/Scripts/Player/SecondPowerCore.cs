// script for hidden powercore on crash site level

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondPowerCore : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth Powercore0;
    private ShipPartAndPowerCoreFlags shipPartAndPowerCoreFlags;
    private Scene scene;
    private AudioSource shieldChargeSound;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Powercore0 = player.GetComponent<PlayerHealth>();   // may not be necessary

        shipPartAndPowerCoreFlags = player.GetComponent<ShipPartAndPowerCoreFlags>();

        shieldChargeSound = GameObject.FindGameObjectWithTag("shieldChargeSound").GetComponent<AudioSource>();

        //Grabs the current active scene info
        scene = SceneManager.GetActiveScene();

        if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasPowercore0 == true)
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
            Powercore0.hasPowercore0 += 1;
            Powercore0.currentShield += 75;
            Powercore0.playerShieldSlider.value = Powercore0.CalculateRemainingShield();

            shieldChargeSound.Play();
            if (scene.name == "CrashSite" && shipPartAndPowerCoreFlags.hasPowercore0 == false)
            {
                shipPartAndPowerCoreFlags.hasPowercore0 = true;
            }
        }
    }
}