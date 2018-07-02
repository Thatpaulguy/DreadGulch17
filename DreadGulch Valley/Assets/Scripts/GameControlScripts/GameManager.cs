using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance = null;

    public delegate void GameEnded();
    public static event GameEnded GameOver;

    private GameObject player;

    private PlayerHealth shipPart;

    private PlayerMovement movement;

    public GameObject winScreen;

    public GameObject lossScreen;


    void Awake()
    {

        //the initialization of the GameManager instance
        //if (_instance == null)
        //{

        //    _instance = this;

        //}
        //else if (_instance != this)
        //{

        //    Destroy(gameObject);

        //}

        DontDestroyOnLoad(gameObject);

    }


    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        shipPart = player.GetComponent<PlayerHealth>();

        movement = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {

        if (shipPart.hasShipPart == 6)
        {
            winScreen.SetActive(true);
            movement.enabled = false;
            Time.timeScale = 0;
            //GameOver();

        }
        else if (shipPart.currentHealth <= 0)
        {
            lossScreen.SetActive(true);
            movement.enabled = false;
            Time.timeScale = 0;
        }

    }


}

