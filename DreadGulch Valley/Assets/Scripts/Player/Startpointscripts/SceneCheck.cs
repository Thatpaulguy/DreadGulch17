using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour
{
    public bool IsInCrashsite = true;
    public bool IsInCanyon = false;
    public bool IsInMines = false;
    public bool IsInTown = false;
    public bool IsInSaloon = false;
    public bool IsInMinigame = false;
    public bool IsInGraveyard = false;
    public bool IsInMainMenu = false;
    public bool UIOff = false;
    public bool getScene = false;

    public Scene scene;

    public GameObject player;

    public GameObject playerUI;
    

    public Dictionary<string, bool> ItemStatus = new Dictionary<string, bool>();

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerUI = GameObject.FindGameObjectWithTag("MainUI");

        scene = SceneManager.GetActiveScene();

        ItemStatus.Add("CanyonBoulder", false);
        ItemStatus.Add("CanyonDynamite", false);
        ItemStatus.Add("SaloonEntrance", false);
        ItemStatus.Add("TownDynamite", false);
        ItemStatus.Add("SaloonBackRoom", false);

    }
	
	// Update is called once per frame
	void Update ()
    {

        scene = SceneManager.GetActiveScene();

        Debug.Log(scene.name);

        if (scene.name == "_MainMenu" && IsInMainMenu == true && UIOff == false) 
        {
            playerUI.SetActive(false);
            UIOff = true;
        }
        else if (scene.name != "_MainMenu" && scene.name != "FlyBy" && UIOff == true)
        {
            playerUI.SetActive(true);
            IsInMainMenu = false;
            UIOff = false;
        }
        else if (scene.name == "FlyBy")
        {
            playerUI.SetActive(false);
        }
    }
}