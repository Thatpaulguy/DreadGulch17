// script for counting and displaying achievement status

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievements : MonoBehaviour
{
    private GameObject player;
    private GameObject achieve;
    private GameObject achieveMessage;
    private PlayerHealth playerHealth;
    private Achievements achievementList;
    private RifleAmmoPickup rifle;
    private ShotgunAmmoPickup shotgun;
    private EnemyBase enemyDeath;
    private ShipPartAndPowerCoreFlags shipPartAndPowerCoreFlags;
    public bool CantHide = false;
    public bool OneOn = false;
    public bool Guns = false;
    public bool Hums = false;
    public bool Bands = false;
    public bool Grave = false;
    public bool Collects = false;
    public bool Signs = false;
    public bool Parts = false;
    public bool Gambles = false;
    public bool SelfInf = false;
    public bool PUArt = false;
    public bool Boom = false;
    public string message;
    public float timer;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
            achievementList = player.GetComponent<Achievements>();
        }
    }

    // Update is called once per frame
    void Update ()
    {
        timer += Time.deltaTime;

        if (playerHealth.hasPowerCore >= 6 && achievementList.OneOn == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.OneOn = true;
            Debug.Log("One on Every Level");
            playerHealth.AchievementText.text = "Achievement: One on Every Level";
        }

        else if (playerHealth.hasPowercore0 >= 1 && achievementList.CantHide == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.CantHide = true;
            Debug.Log("Can't Hide from Me");
            playerHealth.AchievementText.text = "Achievement: Can't Hide from Me";
        }

        else if (playerHealth.hasShipPart >= 1 && achievementList.Parts == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Parts = true;
            Debug.Log("Parts is Parts");
            playerHealth.AchievementText.text = "Achievement: Parts is Parts";
        }

        else if (playerHealth.enemyDies >= 100 && achievementList.Hums == true && achievementList.Bands == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Bands = true;
            Debug.Log("Bandit Slayer");
            playerHealth.AchievementText.text = "Achievement: Bandit Slayer";
        }

        else if (playerHealth.enemyDies >= 50 && achievementList.Guns == true && achievementList.Hums == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Hums = true;
            Debug.Log("Humdinger");
            playerHealth.AchievementText.text = "Achievement: Humdinger";
        }

        else if (playerHealth.enemyDies >= 25 && achievementList.Guns == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Guns = true;
            Debug.Log("Gunslinger");
            playerHealth.AchievementText.text = "Achievement: Gunslinger";
        }


        else if (playerHealth.hitCactus >= 1 && achievementList.SelfInf == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);                 // remarked out to test running into cactus in crashsite
            achievementList.SelfInf = true;
            Debug.Log("Self Inflicted");
            playerHealth.AchievementText.text = "Achievement: Self Inflicted";
        }

        else if (playerHealth.PUArtist >= 100 && achievementList.PUArt == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.PUArt = true;
            Debug.Log("Pickup Artist");
            playerHealth.AchievementText.text = "Achievement: Pickup Artist";
        }

        else if (playerHealth.hasGambled == true && achievementList.Gambles == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Gambles = true;
            Debug.Log("Gambler");
            playerHealth.AchievementText.text = "Achievement: Gambler";
        }

        else if (playerHealth.hasBuried == true && achievementList.Grave == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Grave = true;
            Debug.Log("Grave Digger");
            playerHealth.AchievementText.text = "Achievement: Grave Digger";
        }

        else if (playerHealth.hasDetonated == true && achievementList.Boom == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Boom = true;
            Debug.Log("Boom Goes the Dynamite");
            playerHealth.AchievementText.text = "Achievement: Boom Goes the Dynamite";
        }

        else if (playerHealth.SignCount >= 15 && achievementList.Signs == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Signs = true;
            Debug.Log("I Saw the Signs");
            playerHealth.AchievementText.text = "Achievement: I Saw the Signs";
        }

        else if (playerHealth.hasRifle ==  true && playerHealth.hasShotgun == true &&  achievementList.Collects == false)
        {
            timer = 0;
            playerHealth.AchievementPanel.SetActive(true);
            achievementList.Collects = true;
            Debug.Log("Collector");
            playerHealth.AchievementText.text = "Achievement: Collector";
        }

        else if (timer > 5)
        {
            playerHealth.AchievementPanel.SetActive(false);
        }
    }
}