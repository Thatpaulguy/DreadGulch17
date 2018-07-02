using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignInformation : MonoBehaviour
{
    PlayerHealth readingSigns;
    public GameObject player;
    public GameObject signText;
    bool myTrigger = false;
    
	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            readingSigns = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            signText.SetActive(true);

            if (myTrigger == false)
            {
                readingSigns.SignCount += 1;
                myTrigger = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            signText.SetActive(false);
        }
    }
}