using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkManager : MonoBehaviour
{
	private GameObject player;
	private AudioSource sparksHigh;
	private AudioSource sparksLow;

	private float timerHigh;
	private float timerLow;

	private bool go = true;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		sparksHigh = GameObject.FindGameObjectWithTag("sparkHighVoltageSound").GetComponent<AudioSource>();
		sparksLow = GameObject.FindGameObjectWithTag("sparkLowVoltageSound").GetComponent<AudioSource>();

		timerHigh = 1f;
		timerLow = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (timerHigh <= 0)
		{
			float dist = Vector3.Distance (gameObject.transform.position, player.transform.position);
			sparksHigh.volume = 20f / dist;
			sparksHigh.Play();

			timerHigh = Random.Range(300, 900);
		}

		if (timerLow <= 0)
		{
			float dist = Vector3.Distance (gameObject.transform.position, player.transform.position);
			sparksLow.volume = 20f / dist;
			sparksLow.Play();

			timerLow = Random.Range(120, 500);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player)
		{
			float dist = Vector3.Distance(gameObject.transform.position, player.transform.position);

			sparksHigh.volume = 1f / dist;
			sparksLow.volume = 1f / dist;

			--timerHigh;
			--timerLow;
		}
	}
}
