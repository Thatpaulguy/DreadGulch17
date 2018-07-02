// playerhealth contains all variables for Bob character

using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    // a reference variable to the player health and ammo bars
    public Slider playerHealthSlider;
    public Slider playerShieldSlider;                  // added sheild slider 
    public GameObject pistolAmmoPanel;
    public Text pistolAmmoPanelText;
    public GameObject rifleAmmoPanel;
    public Text rifleAmmoPanelText;
    public GameObject shotgunAmmoPanel;
    public Text shotgunAmmoPanelText;
    public GameObject MapPanel;
    public GameObject inventoryBar;
    public GameObject icons;
    public GameObject AchievementPanel;
    public Text AchievementText;
    public Text TallyCountText;
    public Text bandkilledText;
    public Text pickupsText;
    public Text shipPartText;

    public int hasPowerCore = 0;
    public int hasPowercore0 = 0;
    public int hasShipPart = 0;
    public bool hasBuried = false;
    public bool hasDynamite = false;
    public bool hasShovel = false;
    public bool hasGambled = false;
    public bool hasAllWeapons = false;
    public bool hasReadAllSigns = false;
    public bool hasShotgun = false;
    public bool hasRifle = false;
    public bool hasDetonated = false;
    public int enemyDies = 0;
    public int PUArtist = 0;
    public int hitCactus = 0;
    public int SignCount = 0;
    
    // a variable to hold the player's maximum health value
    public const float maxTotalHealth = 200;
    public const float maxTotalShield = 300;            //  added sheild max amount 
    public int maxAmmo = 50;

    // a variable to hold the player's current health and ammo
    public float currentHealth;
    public float currentShield;
    public int pistolAmmoCount;
    public int rifleAmmoCount = 0;
    public int shotgunAmmoCount = 0;
    public int AmmoCount;

    // sets which gun is currently equipped
    // 0 = pistol
    // 1 = shotgun
    // 2 = rifle
    public int currentGun = 0;
    public GameObject[] guns;
    

    // Use this for initialization
    void Start()
    {
        // initializes the player's current health value to the maximum health value
        currentHealth = maxTotalHealth - (maxTotalHealth / 4);
        currentShield = maxTotalShield - ((maxTotalShield / 3) * 2);
        
        // initializes the health bar value
        playerHealthSlider.value = CalculateRemainingHealth();
        playerShieldSlider.value = CalculateRemainingShield();

        pistolAmmoCount = Random.Range(12, 24);
        pistolAmmoPanelText.text = " " + pistolAmmoCount.ToString();
        rifleAmmoPanelText.text = " " + rifleAmmoCount.ToString();
        shotgunAmmoPanelText.text = " " + shotgunAmmoCount.ToString();
        
        ChangeGun(currentGun);
    }
	
	// Update is called once per frame
	void Update ()
    {
        // test changing weapons
        if (Input.GetKeyDown(KeyCode.Alpha1))
            ChangeGun(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            ChangeGun(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            ChangeGun(2);    

        if (currentGun == 0)
        {
            pistolAmmoPanel.SetActive(true);
            AmmoCount = pistolAmmoCount;
            pistolAmmoPanelText.text = " " + pistolAmmoCount.ToString();
            rifleAmmoPanel.SetActive(false);
            shotgunAmmoPanel.SetActive(false);
        }
        else if (currentGun == 1)
        {
            shotgunAmmoPanel.SetActive(true);
            AmmoCount = rifleAmmoCount;
            shotgunAmmoPanelText.text = " " + shotgunAmmoCount.ToString();
            rifleAmmoPanel.SetActive(false);
            pistolAmmoPanel.SetActive(false);
        }
        else if (currentGun == 2)
        {
            rifleAmmoPanel.SetActive(true);
            AmmoCount = shotgunAmmoCount;
            rifleAmmoPanelText.text = " " + rifleAmmoCount.ToString();
            shotgunAmmoPanel.SetActive(false);
            pistolAmmoPanel.SetActive(false);
        }



        bandkilledText.text = " " + enemyDies.ToString();
        pickupsText.text = " " + PUArtist.ToString();
        shipPartText.text = " " + hasShipPart.ToString();


    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "ShipPart")
    //    {
    //        GameObject icon = Instantiate(icons);
    //        icon.transform.SetParent(inventoryBar.transform);
    //    }
    //}

    // calculates the player current health value in a range of 0 to 1
    public float CalculateRemainingHealth()
    {
        return currentHealth / maxTotalHealth;
    }

    public float CalculateRemainingShield()                           
    {
        //added calculate remaining shield
        return currentShield / maxTotalShield;                 
    }

    // a function to subtract damage from the player's health
    public void TakeDamage(int damage)
    {
        // subtracts the passed amount of damage from the player
        if (currentShield < 1)
            currentHealth -= damage;
        else
            currentShield -= damage;


        // sets the player health slider to the player's current health value 
        playerShieldSlider.value = CalculateRemainingShield();
        playerHealthSlider.value = CalculateRemainingHealth();

        // tests if the player is dead and call the PlayerDied function if they are dead
        if (currentHealth <= 0)
        {
            PlayerDied();
        }
    }

    public void HealDamage(int heal)
    {
        // checked to make sure cannot go past max health
        if (currentHealth < maxTotalHealth)                        
        { 
            currentHealth += heal;
            playerHealthSlider.value = CalculateRemainingHealth();

            if (currentHealth > maxTotalHealth)
                currentHealth = maxTotalHealth;

            playerHealthSlider.value = CalculateRemainingHealth();
        }
    }

    public void HealShield(int shield)
    {
        currentShield += shield;
        playerShieldSlider.value = CalculateRemainingShield();
    }

    public void PlayerDied()
    {
        // Logs out to the console window that the player has died
        Debug.Log("You are dead!");
    }

    public void IncreaseAmmoCount(int increase)
    {
        pistolAmmoCount += increase;

        if (pistolAmmoCount > maxAmmo)
            pistolAmmoCount = maxAmmo;
       
        pistolAmmoPanelText.text = " " + pistolAmmoCount.ToString();
    }

    public void IncreaseRifleAmmoCount(int increase)
    {
        rifleAmmoCount += increase;

        if (rifleAmmoCount > maxAmmo)
            rifleAmmoCount = maxAmmo;
      
        rifleAmmoPanelText.text = " " + rifleAmmoCount.ToString();
    }

    public void IncreaseShotgunAmmoCount(int increase)
    {

        shotgunAmmoCount += increase;

        if (shotgunAmmoCount > maxAmmo)
            shotgunAmmoCount = maxAmmo;

       
        shotgunAmmoPanelText.text = " " + shotgunAmmoCount.ToString();
    }

    public void DecreaseAmmoCount(int decrease)
    {
        if (currentGun == 0) {
            pistolAmmoCount -= decrease;

            if (pistolAmmoCount < 0)
            {
                pistolAmmoCount = 0;
            }
        }
        else if (currentGun == 1)
        {
            shotgunAmmoCount -= decrease;

            if (shotgunAmmoCount < 0)
            {
                shotgunAmmoCount = 0;
            }
        }
        else if (currentGun == 2)
        {
            rifleAmmoCount -= decrease;

            if (rifleAmmoCount < 0)
            {
                rifleAmmoCount = 0;
            }
        }
    }

    public void ChangeGun(int newGun)
    {
        currentGun = newGun;

        PlayerAttack[] attacks = GetComponentsInChildren<PlayerAttack>();

        for (int i = 0; i < attacks.Length; i++)
        {
            if (attacks[i].gunID == currentGun)
            {
                GunSwitch activeGunScript = guns[i].GetComponent<GunSwitch>();
                activeGunScript.EnableGun();
            }
            else
            {
                GunSwitch inactiveGunScript = guns[i].GetComponent<GunSwitch>();
                inactiveGunScript.DisableGun();
            }
        }
    }
}