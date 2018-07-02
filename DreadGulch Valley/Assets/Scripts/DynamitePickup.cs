using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DynamitePickup : MonoBehaviour
{
    public GameObject notificationsManager;

    private NotificationsManager noteManager;
	private AudioSource dynamiteSound;
    private PlayerHealth playerHealth;

    private void Start()
	{
		dynamiteSound = GameObject.FindGameObjectWithTag("dynamiteSound").GetComponent<AudioSource>();

        playerHealth = GameObject.FindObjectOfType<PlayerHealth>();

        if (playerHealth.hasDynamite == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			dynamiteSound.Play();
            
            playerHealth.hasDynamite = true;
            gameObject.SetActive(false);

            GameObject nm = GameObject.Find("NotificationText");
            if (nm == null)
                return;

            noteManager = nm.GetComponent<NotificationsManager>();

            if (noteManager == null)
                return;

            if (SceneManager.GetActiveScene().buildIndex == 3)
                    noteManager.SetNotification("You collected the dynamite! Now blow up the rocks to get into the mines.");
                if (SceneManager.GetActiveScene().buildIndex == 5)
                    noteManager.SetNotification("You collected the dynamite! Now get to the bank and blow the vault open.");
        }
    }
}