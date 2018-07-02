using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuToCrashSite : MonoBehaviour {

    private GameObject player;
    private SceneCheck playerscene;
    private PlayerMovement movement;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscene = player.GetComponent<SceneCheck>();
        movement = player.GetComponent<PlayerMovement>();

        playerscene.IsInCrashsite = true;

        if (playerscene.IsInCrashsite)
        {
            player.transform.position = gameObject.transform.position;

            movement.enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
