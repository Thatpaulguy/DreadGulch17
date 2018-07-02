using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firedamage : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth firedam;

    public int DamagePerHit = 10;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        firedam = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            firedam.currentHealth -= 10;
            firedam = player.GetComponent<PlayerHealth>();
            firedam.playerHealthSlider.value = firedam.CalculateRemainingHealth();
        }
    }
}