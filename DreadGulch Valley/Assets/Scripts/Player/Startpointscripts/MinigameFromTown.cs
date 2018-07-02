using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameFromTown : MonoBehaviour
{
    private GameObject player;
    private SceneCheck playerscene;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerscene = player.GetComponent<SceneCheck>();
        if (playerscene.IsInTown)
        {
            player.transform.position = gameObject.transform.position;
            playerscene.IsInTown = false;
            playerscene.IsInMinigame = true;
        }
    }

    // Update is called once per frame
    void Update ()
    { }
}