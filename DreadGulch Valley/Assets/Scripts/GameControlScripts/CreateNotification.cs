using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNotification : MonoBehaviour
{
    public string message;
    private NotificationsManager noteManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject nm = GameObject.Find("NotificationText");
            if (nm == null)
                return;

            noteManager = nm.GetComponent<NotificationsManager>();

            if (noteManager == null)
                return;

            noteManager.SetNotification(message);
        }
    }
}