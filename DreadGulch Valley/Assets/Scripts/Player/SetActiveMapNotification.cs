using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveMapNotification : MonoBehaviour
{
    public GameObject player;
    private LevelMapInfo levelMapInfo;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        levelMapInfo = player.GetComponent<LevelMapInfo>();

        if (levelMapInfo.hasCanyonMap == true)
        {
            gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}