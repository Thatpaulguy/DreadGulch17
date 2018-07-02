using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAlienBob : MonoBehaviour {

    GameObject player;

    PlayerHealth playerStats;

    LevelMapInfo playerMapInfo;

    SceneCheck playerScene;

    ShipPartAndPowerCoreFlags playerPartsInfo;

    Achievements playerAchievements;

    public GameObject lostPanel;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        playerStats = player.GetComponent<PlayerHealth>();

        playerMapInfo = player.GetComponent<LevelMapInfo>();

        playerScene = player.GetComponent<SceneCheck>();

        playerPartsInfo = player.GetComponent<ShipPartAndPowerCoreFlags>();

        playerAchievements = player.GetComponent<Achievements>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetBob()
    {
        playerStats.currentHealth = 150;
        playerStats.playerHealthSlider.value = playerStats.currentHealth;

        playerStats.currentShield = 100;
        playerStats.playerShieldSlider.value = playerStats.currentShield;

        playerStats.pistolAmmoCount = 20;
        playerStats.pistolAmmoPanelText.text = " " + playerStats.pistolAmmoCount.ToString();

        playerStats.rifleAmmoCount = 0;
        playerStats.rifleAmmoPanelText.text = " " + playerStats.rifleAmmoCount.ToString();

        playerStats.shotgunAmmoCount = 0;
        playerStats.shotgunAmmoPanelText.text = " " + playerStats.shotgunAmmoCount.ToString();

        playerStats.currentGun = 0;
        playerStats.AmmoCount = playerStats.pistolAmmoCount;
        playerStats.SignCount = 0;
        playerStats.hitCactus = 0;
        playerStats.PUArtist = 0;
        playerStats.pickupsText.text = " " + playerStats.PUArtist.ToString();

        playerStats.enemyDies = 0;
        playerStats.bandkilledText.text = " " + playerStats.enemyDies.ToString();

        playerStats.hasPowerCore = 0;
        playerStats.hasPowercore0 = 0;
        playerStats.hasShipPart = 0;
        playerStats.hasBuried = false;
        playerStats.hasDynamite = false;
        playerStats.hasShovel = false;
        playerStats.hasGambled = false;
        playerStats.hasAllWeapons = false;
        playerStats.hasReadAllSigns = false;
        playerStats.hasShotgun = false;
        playerStats.hasRifle = false;
        playerStats.hasDetonated = false;
        //playerStats.inventoryBar = null;


        playerPartsInfo.hasPowercore0 = false;
        playerPartsInfo.hasPowerCore1 = false;
        playerPartsInfo.hasPowerCore2 = false;
        playerPartsInfo.hasPowerCore3 = false;
        playerPartsInfo.hasPowerCore4 = false;
        playerPartsInfo.hasPowerCore5 = false;
        playerPartsInfo.hasPowerCore6 = false;
        playerPartsInfo.hasShipPart1 = false;
        playerPartsInfo.hasShipPart2 = false;
        playerPartsInfo.hasShipPart3 = false;
        playerPartsInfo.hasShipPart4 = false;
        playerPartsInfo.hasShipPart5 = false;
        playerPartsInfo.hasShipPart6 = false;

        playerScene.IsInCrashsite = false;
        playerScene.IsInCanyon = false;
        playerScene.IsInMines = false;
        playerScene.IsInGraveyard = false;
        playerScene.IsInMinigame = false;
        playerScene.IsInTown = false;
        playerScene.IsInSaloon = false;
        playerScene.IsInMainMenu = true;

        playerMapInfo.mapActive = false;
        playerMapInfo.hasCanyonMap = false;

        playerAchievements.CantHide = false;
        playerAchievements.OneOn = false;
        playerAchievements.Guns = false;
        playerAchievements.Hums = false;
        playerAchievements.Bands = false;
        playerAchievements.Grave = false;
        playerAchievements.Collects = false;
        playerAchievements.Signs = false;
        playerAchievements.Parts = false;
        playerAchievements.Gambles = false;
        playerAchievements.SelfInf = false;
        playerAchievements.PUArt = false;
        playerAchievements.Boom = false;

        lostPanel.SetActive(false);

    }

}
