using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour {

    GameObject player;

    Animator anim;



	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Square");

        anim = player.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("isWalking", true);
        }

	}
}
