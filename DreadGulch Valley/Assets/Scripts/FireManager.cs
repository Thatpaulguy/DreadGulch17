using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour
{
	private GameObject player;
	private AudioSource fireSound;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		fireSound = GameObject.FindGameObjectWithTag("fireSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == player)
		{
			fireSound.Play();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
			fireSound.volume = 20f / dist;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject == player)
		{
			fireSound.Stop();
		}
	}
}
