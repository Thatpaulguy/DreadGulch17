using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTimeScale : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth playerHealth;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ResetTime()
    {
        Time.timeScale = 1;
    }
}