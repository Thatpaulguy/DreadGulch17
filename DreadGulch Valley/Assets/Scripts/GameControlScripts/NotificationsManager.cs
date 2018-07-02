using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationsManager : MonoBehaviour
{
    public float DisplayTime = 4;

    private float timer;
    private Text notificationText;

    void Start()
    {
        notificationText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (notificationText != null && notificationText.text != "" && timer >= DisplayTime)
            notificationText.text = "";
    }

    public void SetNotification(string message)
    {
        notificationText.text = message;
        timer = 0f;
    }
}