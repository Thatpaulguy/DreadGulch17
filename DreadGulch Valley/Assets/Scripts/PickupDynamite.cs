using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDynamite : MonoBehaviour
{
    private GameObject player;
    private PlayerHealth getDynamite;
	private AudioSource dynamiteSound;
    private NotificationsManager noteManager;

    private void Start()
	{
        player = GameObject.FindGameObjectWithTag("Player");
        getDynamite = player.GetComponent<PlayerHealth>();
		dynamiteSound = GameObject.FindGameObjectWithTag("dynamiteSound").GetComponent<AudioSource>();
        if(getDynamite.hasDynamite == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!other.gameObject.GetComponent<PlayerHealth>().hasDynamite)
            {
                dynamiteSound.Play();
                getDynamite.hasDynamite = true;
                if (player.GetComponent<SceneCheck>().IsInCanyon)
                    player.GetComponent<SceneCheck>().ItemStatus["CanyonDynamite"] = true;
                else if (player.GetComponent<SceneCheck>().IsInTown)
                    player.GetComponent<SceneCheck>().ItemStatus["TownDynamite"] = true;
                Destroy(gameObject);
            }
            else
            {
                GameObject nm = GameObject.Find("NotificationText");
                if (nm == null)
                    return;

                noteManager = nm.GetComponent<NotificationsManager>();

                if (noteManager == null)
                    return;

                noteManager.SetNotification("You've already got the dynamite. Use it before you try picking up more!");
            }
        }
    }

    public void IsPickedUp()
    {
        if (player.GetComponent<SceneCheck>().IsInCanyon && player.GetComponent<SceneCheck>().ItemStatus["CanyonDynamite"])
            Destroy(gameObject);
        if (player.GetComponent<SceneCheck>().IsInTown && player.GetComponent<SceneCheck>().ItemStatus["TownDynamite"])
            Destroy(gameObject);
    }
}
