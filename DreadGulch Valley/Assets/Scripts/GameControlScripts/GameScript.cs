using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour
{
    GameObject player;
    public GameObject minigameover;
    PlayerHealth playerAmmo;

    public Transform target;
    private Vector3 newPosition;

    private Card[] cards = new Card[52];

    bool pressed, go;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAmmo = player.GetComponent<PlayerHealth>();
        target = player.GetComponent<Transform>().transform;
        newPosition.y = 0.0f;

        pressed = false;
        go = true;

        //Loop through all cards and create new
        for (int i = 0; i < 52; ++i)
        {
            cards[i] = new Card();
        }

        //Load cards
        string[] suit = { "C", "S", "H", "D" };
        string value;
        string[] royal = { "A", "J", "Q", "K" };
        int val = 2;
        int pos = 0;

        for (int j = 0; j < 4; ++j)
        {
            for (int k = 0; k < 9; ++k)
            {
                value = val.ToString() + suit[j];
                cards[pos].cardName = value;
                cards[pos].value = val;
                ++val;
                ++pos;
            }
            val = 2;
        }

        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                value = royal[i] + suit[j];
                cards[pos].cardName = value;
                cards[pos].value = 11;
                ++pos;
            }
        }
    }

    void SelectCard()
    {
        int yourVal, myVal;
        yourVal = myVal = 0;

        int cardNum = Random.Range(0, 52);
        GameObject.FindGameObjectWithTag("yourCard").GetComponent<Text>().text = cards[cardNum].cardName;
        yourVal = cards[cardNum].value;

        cardNum = Random.Range(0, 52);
        GameObject.FindGameObjectWithTag("myCard").GetComponent<Text>().text = cards[cardNum].cardName;
        myVal = cards[cardNum].value;

        if (yourVal > myVal)
        {

            GameObject.FindGameObjectWithTag("winLoss").GetComponent<Text>().text = "You win!";
            if (playerAmmo.currentGun == 0)
            {
                playerAmmo.pistolAmmoCount += (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.pistolAmmoCount.ToString();
                if (playerAmmo.pistolAmmoCount > 50)
                {
                    playerAmmo.pistolAmmoCount = 50;
                }
            }
            else if (playerAmmo.currentGun == 1)
            {
                playerAmmo.shotgunAmmoCount += (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.shotgunAmmoCount.ToString();
                if (playerAmmo.shotgunAmmoCount > 50)
                {
                    playerAmmo.shotgunAmmoCount = 50;
                }
            }
            else
            {
                playerAmmo.rifleAmmoCount += (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.rifleAmmoCount.ToString();
                if (playerAmmo.rifleAmmoCount > 50)
                {
                    playerAmmo.rifleAmmoCount = 50;
                }
            }

        }
        else if (yourVal < myVal)
        {
            GameObject.FindGameObjectWithTag("winLoss").GetComponent<Text>().text = "You lose!";
            if (playerAmmo.currentGun == 0)
            {
                playerAmmo.pistolAmmoCount -= (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.pistolAmmoCount.ToString();

                if (playerAmmo.pistolAmmoCount <= 0)
                {
                    playerAmmo.pistolAmmoCount = 0;
                    playerAmmo.pistolAmmoCount += 6;  // made this amount six because button click also is trigger to fire leaving you with five
                    playerAmmo.hasGambled = true;
                    minigameover.SetActive(true);
                }
            }
            else if (playerAmmo.currentGun == 1)
            {
                playerAmmo.shotgunAmmoCount -= (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.shotgunAmmoCount.ToString();
                if (playerAmmo.shotgunAmmoCount <= 0)
                {
                    playerAmmo.shotgunAmmoCount = 0;
                    playerAmmo.shotgunAmmoCount += 6;  // made this amount six because button click also is trigger to fire leaving you with five
                    playerAmmo.hasGambled = true;
                    minigameover.SetActive(true);
                }
            }
            else
            {
                playerAmmo.rifleAmmoCount -= (Random.Range(3, 10));
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.rifleAmmoCount.ToString();
                if (playerAmmo.rifleAmmoCount <= 0)
                {
                    playerAmmo.rifleAmmoCount = 0;
                    playerAmmo.rifleAmmoCount += 6;  // made this amount six because button click also is trigger to fire leaving you with five
                    playerAmmo.hasGambled = true;
                    minigameover.SetActive(true);
                }
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("winLoss").GetComponent<Text>().text = "Draw!";
            if (playerAmmo.currentGun == 0)
            {
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.pistolAmmoCount.ToString();
            }
            else if (playerAmmo.currentGun == 1)
            {
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.shotgunAmmoCount.ToString();
            }
            else
            {
                GameObject.FindGameObjectWithTag("AmmoCount").GetComponent<Text>().text = playerAmmo.rifleAmmoCount.ToString();
            }
        }

        pressed = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            playerAmmo.hasGambled = true;
            LoadSceneByIndex(5);
        }

        if (pressed && go)
        {
            SelectCard();
            go = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            go = true;
        }
    }

    public class Card
    {
        public string cardName;
        public int value;
    }

    public void LoadSceneByIndex(int Index)
    {
        Time.timeScale = 1;

        Debug.Log("Click!!!");
        //a function that loads the scene with the index it was passed
        SceneManager.LoadScene(Index);
    }
}