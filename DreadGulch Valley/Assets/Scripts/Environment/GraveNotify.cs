using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveNotify : MonoBehaviour 
{
    private GameObject player;
    private PlayerHealth shovel;

    public string message1;
    public string message2;

    private NotificationsManager noteManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shovel = player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        { 
            if (shovel.hasShovel == true)
            {
                GameObject nm = GameObject.Find("NotificationText");
                if (nm == null)
                    return;

                noteManager = nm.GetComponent<NotificationsManager>();

                if (noteManager == null)
                    return;

                noteManager.SetNotification(message2);
            }
            else
            {
                GameObject nm = GameObject.Find("NotificationText");
                if (nm == null)
                    return;

                noteManager = nm.GetComponent<NotificationsManager>();

                if (noteManager == null)
                    return;

                noteManager.SetNotification(message1);
            }
        }
    }
}