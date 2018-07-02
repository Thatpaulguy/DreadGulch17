using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlideScript : MonoBehaviour
{
    public float doorSpeed = 1.0f;
    public float openDistance = 1.0f;

    private bool isOpening = false;
    private float currDistance = 0.0f;

	private AudioSource vaultDoorSound;

	private void Start()
	{
		vaultDoorSound = GameObject.FindGameObjectWithTag("vaultDoorSound").GetComponent<AudioSource>();
	}

    public void Update()
    {
        if (isOpening && currDistance < openDistance)
        {
            float doorMove = (doorSpeed - .5f) * Time.deltaTime;
            float doorRotate = -(doorSpeed*Time.deltaTime*10);
            transform.Translate(doorMove, 0.0f, 0.0f);
            transform.Rotate(0.0f, doorRotate, 0.0f);
            currDistance += doorSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			vaultDoorSound.Play();
            isOpening = true;
        }
    }
}