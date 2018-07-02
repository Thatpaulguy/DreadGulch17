using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOreSwitch : MonoBehaviour
{
    public GameObject oreCart;

    private GameObject player;
    private Animation oreCartAnim;
    private Animation leverAnim;
    private int used = 0;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oreCartAnim = oreCart.GetComponent<Animation>();
        leverAnim = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && used != 1)
        {
            leverAnim.Play();
            oreCartAnim.Play();
            AudioSource sound = oreCart.GetComponent<AudioSource>();
            if (sound != null)
                sound.Play();
            used = 1;
        }
    }
}